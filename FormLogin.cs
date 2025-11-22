using System;
using System.Windows.Forms;
using Npgsql;

namespace LONTAR
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            tbpw.UseSystemPasswordChar = true;
        }

        private bool ValidateLogin(string username, string password, out string userId)
        {
            userId = null;

            string connStr = "Host=localhost;Username=postgres;Password=jodie123;Database=LONTAR";
            string query = "SELECT id_admin FROM admin WHERE username = @username AND password = @password";

            using (var conn = new NpgsqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userId = reader["id_admin"].ToString().Trim();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kesalahan database: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false;
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            if (tbuser.Text == "" || tbpw.Text == "")
            {
                MessageBox.Show("Username & Password harus diisi!",
                    "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string username = tbuser.Text;
            string password = tbpw.Text;

            if (ValidateLogin(username, password, out string userId))
            {
                UserSession.IdAdminLogin = userId;

                MessageBox.Show("Login berhasil!", "Berhasil",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormHome home = new FormHome();
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("Username atau password salah!",
                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormRegister register = new FormRegister();
            register.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
