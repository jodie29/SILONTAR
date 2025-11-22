using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LONTAR
{
    public partial class FormRegister : Form
    {
        // PENTING: Tentukan satu Connection String yang benar untuk seluruh operasi database
        // Saya menggunakan koneksi Register() karena diasumsikan itu yang terbaru
        private const string DatabaseConnectionString = "Host=localhost;Username=postgres;Password=jodiefer;Database=CANKULLIN";

        public FormRegister()
        {
            InitializeComponent();
            // Atur agar karakter password tidak terlihat (opsional, tapi disarankan)
            tbpw.UseSystemPasswordChar = true;
        }

        // ================================
        // EVENT TOMBOL REGISTER
        // ================================
        private void btregister_Click(object sender, EventArgs e)
        {
            try
            {
                // ... (Validasi kontrol awal tidak berubah) ...

                // Ambil input
                string username = tbuser.Text.Trim();
                string password = tbpw.Text.Trim();
                string email = tbemail.Text.Trim();
                string nohp = tbnotelp.Text.Trim();

                // Validasi input wajib
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nohp))
                {
                    MessageBox.Show("Semua kolom harus diisi!",
                        "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validasi nomor HP
                if (!Regex.IsMatch(nohp, @"^\d+$"))
                {
                    MessageBox.Show("Nomor HP harus berupa angka yang valid!",
                        "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // PERBAIKAN: Validasi password diubah agar tidak hanya angka dan minimal 8 karakter
                if (password.Length < 8)
                {
                    MessageBox.Show("Kata sandi harus terdiri dari minimal 8 karakter!",
                        "Kesalahan Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // HAPUS validasi Regex.IsMatch(password, @"^\d+$") yang sebelumnya salah/kurang aman

                // Generate ID admin
                string newAdminId = GenerateNewAdminId();
                if (string.IsNullOrEmpty(newAdminId))
                {
                    MessageBox.Show("Gagal membuat ID admin baru.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Proses register ke database
                // Catatan: Saya menggunakan username untuk kolom nama_admin, sesuai logika Anda sebelumnya
                bool isRegistered = Register(newAdminId, username, email, nohp, username, password);

                if (isRegistered)
                {
                    MessageBox.Show("Registrasi Berhasil!", "Berhasil",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Aksi yang benar: Sembunyikan form ini dan tampilkan FormLogin
                    this.Hide();
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                }
                else
                {
                    MessageBox.Show("Registrasi Gagal. Silahkan coba lagi!",
                        "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ======================================
        // MENGAMBIL ID ADMIN TERAKHIR
        // ======================================
        private string GetLastAdminId()
        {
            // PERBAIKAN: Menggunakan DatabaseConnectionString yang sudah disatukan
            string connStr = DatabaseConnectionString;
            string lastId = null;

            string query = "SELECT id_admin FROM admin WHERE id_admin LIKE 'adm%' " +
                            "ORDER BY CAST(SUBSTRING(id_admin FROM 4) AS INT) DESC LIMIT 1";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastId = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Menampilkan pesan error yang lebih informatif
                MessageBox.Show("Gagal mengambil ID admin terakhir. Cek koneksi DB. Error: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastId;
        }

        // ... (GenerateNewAdminId tidak ada perubahan) ...
        private string GenerateNewAdminId()
        {
            string lastId = GetLastAdminId();
            int newNumber = 1;

            if (!string.IsNullOrEmpty(lastId))
            {
                Match match = Regex.Match(lastId, @"^adm(\d+)$");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int existingNumber))
                {
                    newNumber = existingNumber + 1;
                }
            }

            return "adm" + newNumber.ToString();
        }


        // ======================================
        // REGISTER KE DATABASE
        // ======================================
        private bool Register(string idAdmin, string nama, string email, string nohp, string username, string password)
        {
            // PERBAIKAN: Menggunakan DatabaseConnectionString yang sudah disatukan
            string connStr = DatabaseConnectionString;

            string query = "INSERT INTO admin (id_admin, nama_admin, email, no_hp_admin, username, password) " +
                            "VALUES (@id_admin, @nama_admin, @email, @no_hp_admin, @username, @password)";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_admin", idAdmin);
                        cmd.Parameters.AddWithValue("@nama_admin", nama);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@no_hp_admin", nohp);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        int rows = cmd.ExecuteNonQuery();

                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Menampilkan pesan error yang lebih spesifik untuk kegagalan INSERT
                MessageBox.Show("Registrasi Gagal. Pastikan data unik seperti Username/Email belum terdaftar. Error: " + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        // ======================================
        // EVENT TOMBOL LOGIN (button1_Click)
        // ======================================
        private void button1_Click(object sender, EventArgs e) // Menggantikan private void btlogin_Click yang tidak terpakai
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.Show();
        }

        // Hapus atau abaikan method btlogin_Click yang lama karena tidak terhubung ke control manapun di designer
    }
}