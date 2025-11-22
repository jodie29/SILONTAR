using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace LONTAR
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tbuser = new TextBox();
            tbpw = new TextBox();
            btlogin = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // tbuser
            // 
            tbuser.BackColor = Color.White;
            tbuser.BorderStyle = BorderStyle.None;
            tbuser.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            tbuser.Location = new Point(337, 229);
            tbuser.Multiline = true;
            tbuser.Name = "tbuser";
            tbuser.RightToLeft = RightToLeft.Yes;
            tbuser.Size = new Size(184, 25);
            tbuser.TabIndex = 0;
            tbuser.TextAlign = HorizontalAlignment.Center;
            // 
            // tbpw
            // 
            tbpw.BackColor = Color.White;
            tbpw.BorderStyle = BorderStyle.None;
            tbpw.Location = new Point(337, 308);
            tbpw.Multiline = true;
            tbpw.Name = "tbpw";
            tbpw.Size = new Size(184, 25);
            tbpw.TabIndex = 1;
            tbpw.UseSystemPasswordChar = true;
            // 
            // btlogin
            // 
            btlogin.BackColor = Color.Lime;
            btlogin.Location = new Point(392, 394);
            btlogin.Name = "btlogin";
            btlogin.Size = new Size(88, 35);
            btlogin.TabIndex = 2;
            btlogin.Text = "Login";
            btlogin.UseVisualStyleBackColor = false;
            btlogin.Click += btlogin_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = Color.Transparent;
            linkLabel1.DisabledLinkColor = Color.White;
            linkLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(587, 18);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(78, 20);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Registrasi";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.LoginAU;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(687, 450);
            Controls.Add(linkLabel1);
            Controls.Add(btlogin);
            Controls.Add(tbpw);
            Controls.Add(tbuser);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbuser;
        private TextBox tbpw;
        private Button btlogin;
        private LinkLabel linkLabel1;
    }
}
