using System;
using System.Drawing;
using System.Windows.Forms;

namespace LONTAR
{
    partial class FormRegister
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
            tbemail = new TextBox();
            tbnotelp = new TextBox();
            btregister = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // tbuser
            // 
            tbuser.Location = new Point(255, 136);
            tbuser.Name = "tbuser";
            tbuser.Size = new Size(191, 23);
            tbuser.TabIndex = 0;
            // 
            // tbpw
            // 
            tbpw.Location = new Point(255, 196);
            tbpw.Name = "tbpw";
            tbpw.Size = new Size(191, 23);
            tbpw.TabIndex = 1;
            // 
            // tbemail
            // 
            tbemail.Location = new Point(255, 258);
            tbemail.Name = "tbemail";
            tbemail.Size = new Size(191, 23);
            tbemail.TabIndex = 2;
            // 
            // tbnotelp
            // 
            tbnotelp.Location = new Point(255, 321);
            tbnotelp.Name = "tbnotelp";
            tbnotelp.Size = new Size(191, 23);
            tbnotelp.TabIndex = 3;
            // 
            // btregister
            // 
            btregister.BackColor = Color.Lime;
            btregister.Location = new Point(266, 352);
            btregister.Name = "btregister";
            btregister.Size = new Size(73, 31);
            btregister.TabIndex = 4;
            btregister.Text = "Register";
            btregister.UseVisualStyleBackColor = false;
            btregister.Click += btregister_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.Location = new Point(354, 352);
            button1.Name = "button1";
            button1.Size = new Size(73, 31);
            button1.TabIndex = 5;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += this.button1_Click;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.RegisAU;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(687, 450);
            Controls.Add(button1);
            Controls.Add(btregister);
            Controls.Add(tbnotelp);
            Controls.Add(tbemail);
            Controls.Add(tbpw);
            Controls.Add(tbuser);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRegister";
            Text = "Form Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbuser;
        private TextBox tbpw;
        private TextBox tbemail;
        private TextBox tbnotelp;
        private Button btregister;
        private Button button1;
    }
}
