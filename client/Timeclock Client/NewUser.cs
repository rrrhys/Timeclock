using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Timeclock_Client
{
    public partial class NewUser : DevExpress.XtraEditors.XtraForm
    {
        public Guid? user_token = null;
        TimeclockDataInterface db = new DataLayer.WebApiDataLayer();
        public NewUser()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            InitializeComponent();
        }

        private void bNewUser_Click(object sender, EventArgs e)
        {

        }

        private bool validateUserDetails()
        {
            bool isValid = true;
            string error = "";
            try
            {
                var addr = new System.Net.Mail.MailAddress(tEmail.Text);
            }
            catch
            {
                isValid = false;
                error = "Please enter a valid email address.";
            }
            if (tPassword.Text != tPassword2.Text && rNewUser.Checked)
            {
                isValid = false;
                error = "Passwords entered do not match.";
            }
            if (tPassword.Text.Length < 6)
            {
                isValid = false;
                error = "Password must be 6+ characters.";
            }
            return isValid;
        }

        private void bSaveNewUser_Click(object sender, EventArgs e)
        {

            if (validateUserDetails())
            {
                if (rNewUser.Checked)
                {
                    this.user_token = db.CreateUser(tEmail.Text, tPassword.Text);
                    this.Close();
                }
                else
                {
                    var token = db.GetTokenForUser(tEmail.Text, tPassword.Text);
                    if (token != null)
                    {
                    //    db.underlyingContext.users
                        this.user_token = token.Value;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Could not find that user!");
                    }
                }

            }
        }

        private void rExistingUser_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void updateState()
        {
            if (rNewUser.Checked)
            {
                label1.Text = "Hi new user!";

                tPassword2.Visible = true;
                label4.Visible = true;
            }
            else
            {
                label1.Text = "Login to continue.";

                tPassword2.Visible = false;
                label4.Visible = false;
            }
        }

        private void rNewUser_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
