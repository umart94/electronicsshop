using System;
using System.Windows.Forms;
namespace VisualProgProject
{
    public partial class Form_Login : MetroFramework.Forms.MetroForm
    {
        public ControllerClass controllerclassobject;
        public Class_EmployeeDataDisplay empdisplayobject;
        public Form_Homepage form_homepageobject;
        public Form_Login()
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = true;
            InitializeComponent();
            controllerclassobject = new ControllerClass();
            empdisplayobject = new Class_EmployeeDataDisplay();
        }
        private void btn_login_Click_1(object sender, EventArgs e)
        {
            string username = usernametxtbox.Text;
            string password = passwordtxtbox.Text;
            if ((string.IsNullOrWhiteSpace(username)))
            {
                MetroFramework.MetroMessageBox.Show(this, "ERROR", "YOU DID NOT ENTER A USERNAME", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MetroFramework.MetroMessageBox.Show(this, "ERROR", "YOU DID NOT ENTER A Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!(string.IsNullOrWhiteSpace(username)) && (!string.IsNullOrWhiteSpace(password)))
            {
                string username2 = Convert.ToString(usernametxtbox.Text);
                string password2 = Convert.ToString(passwordtxtbox.Text);
                //string passwordhash = Class_EncryptDecrypt.sha256_hash(password);
                empdisplayobject = controllerclassobject.loginverify(username2, password2);
                if (String.IsNullOrEmpty(empdisplayobject.getUsername()))
                {
                    MetroFramework.MetroMessageBox.Show(this, "ERROR", "Incorrect Username and Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Hide();
                    Form_Homepage homepageformobject = new Form_Homepage(empdisplayobject);
                    homepageformobject.WindowState = FormWindowState.Maximized;
                    homepageformobject.Show();
                }
            }
        }
        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Dispose();
            //Application.Exit();
        }
    }
}