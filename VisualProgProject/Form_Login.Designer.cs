namespace VisualProgProject
{
    partial class Form_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btn_login = new MetroFramework.Controls.MetroButton();
            this.usernametxtbox = new MetroFramework.Controls.MetroTextBox();
            this.passwordtxtbox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(175, 138);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(147, 25);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "Enter Username : ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(175, 203);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(136, 25);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Enter Password :";
            // 
            // btn_login
            // 
            this.btn_login.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_login.Location = new System.Drawing.Point(303, 283);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(172, 49);
            this.btn_login.TabIndex = 8;
            this.btn_login.Text = "Sign In";
            this.btn_login.UseSelectable = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click_1);
            // 
            // usernametxtbox
            // 
            // 
            // 
            // 
            this.usernametxtbox.CustomButton.Image = null;
            this.usernametxtbox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.usernametxtbox.CustomButton.Name = "";
            this.usernametxtbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.usernametxtbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernametxtbox.CustomButton.TabIndex = 1;
            this.usernametxtbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernametxtbox.CustomButton.UseSelectable = true;
            this.usernametxtbox.CustomButton.Visible = false;
            this.usernametxtbox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.usernametxtbox.Lines = new string[] {
        "umar"};
            this.usernametxtbox.Location = new System.Drawing.Point(367, 140);
            this.usernametxtbox.MaxLength = 32767;
            this.usernametxtbox.Name = "usernametxtbox";
            this.usernametxtbox.PasswordChar = '\0';
            this.usernametxtbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernametxtbox.SelectedText = "";
            this.usernametxtbox.SelectionLength = 0;
            this.usernametxtbox.SelectionStart = 0;
            this.usernametxtbox.ShortcutsEnabled = true;
            this.usernametxtbox.Size = new System.Drawing.Size(186, 23);
            this.usernametxtbox.TabIndex = 9;
            this.usernametxtbox.Text = "umar";
            this.usernametxtbox.UseSelectable = true;
            this.usernametxtbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernametxtbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // passwordtxtbox
            // 
            // 
            // 
            // 
            this.passwordtxtbox.CustomButton.Image = null;
            this.passwordtxtbox.CustomButton.Location = new System.Drawing.Point(164, 1);
            this.passwordtxtbox.CustomButton.Name = "";
            this.passwordtxtbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordtxtbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordtxtbox.CustomButton.TabIndex = 1;
            this.passwordtxtbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordtxtbox.CustomButton.UseSelectable = true;
            this.passwordtxtbox.CustomButton.Visible = false;
            this.passwordtxtbox.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.passwordtxtbox.Lines = new string[] {
        "umar111"};
            this.passwordtxtbox.Location = new System.Drawing.Point(367, 203);
            this.passwordtxtbox.MaxLength = 32767;
            this.passwordtxtbox.Name = "passwordtxtbox";
            this.passwordtxtbox.PasswordChar = '*';
            this.passwordtxtbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordtxtbox.SelectedText = "";
            this.passwordtxtbox.SelectionLength = 0;
            this.passwordtxtbox.SelectionStart = 0;
            this.passwordtxtbox.ShortcutsEnabled = true;
            this.passwordtxtbox.Size = new System.Drawing.Size(186, 23);
            this.passwordtxtbox.TabIndex = 10;
            this.passwordtxtbox.Text = "umar111";
            this.passwordtxtbox.UseSelectable = true;
            this.passwordtxtbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordtxtbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Form_Login
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1007, 706);
            this.Controls.Add(this.passwordtxtbox);
            this.Controls.Add(this.usernametxtbox);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.HelpButton = true;
            this.Name = "Form_Login";
            this.Text = "Electronics Shop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btn_login;
        private MetroFramework.Controls.MetroTextBox usernametxtbox;
        private MetroFramework.Controls.MetroTextBox passwordtxtbox;
    }
}

