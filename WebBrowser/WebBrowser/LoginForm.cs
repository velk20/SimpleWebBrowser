using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace SimpleWebBrowser
{
    public partial class LoginForm : Form
    {
        WebBrowserForm webForm = new WebBrowserForm();
        public DialogResult res;
        public List<string> newList = new List<string>();
        public List<string> usernames = new List<string>();
        public List<string> passwords = new List<string>();
        public List<string> siteURLS = new List<string>();
        public List<string> fullInformation = new List<string>();
        string fullInfo;
        public List<string> currentUserURLSList = new List<string>();
        public readonly char seperator = ',';
        public readonly string filePath = "users.csv";
        public string currentLoggedUsername = "";
        public string nameUsername;
        public string passwordCurrent;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string currentUsername = tbUsername.Text;
            string currentPassword = tbPassword.Text;
            for (int i = 0; i < usernames.Count; i++)
            {
                if (currentUsername == usernames[i] && currentPassword == passwords[i])
                {
                    MessageBox.Show("Login success!","You login attempt was successfull!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    webForm.LOGED = true;
                    currentLoggedUsername = currentUsername;
                    this.Close();
                    res = DialogResult.OK;
                    using (FileStream red = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                    {
                        using (StreamReader reader = new StreamReader(red))
                        {
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                fullInfo = line;
                                string[] userInfo = line.Split(seperator).ToArray();
                                if (userInfo[0] == currentLoggedUsername)
                                {
                                    for (int j = 2; j < userInfo.Length; j++)
                                    {
                                        currentUserURLSList.Add(userInfo[j]);
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
                else
                {
                    webForm.LOGED = false;
                }
            }
            if (webForm.LOGED == false)
            {
                MessageBox.Show("Wrong username/password!","Your username or password ar incorrect",MessageBoxButtons.OK,MessageBoxIcon.Information);
                currentLoggedUsername = "";
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string currentUsername = tbUsername.Text;
            string currentPassword = tbPassword.Text;
            if (usernames.Contains(currentUsername))
            {
                MessageBox.Show("Username is taken!","Try to register with different username!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            usernames.Add(currentUsername);
            passwords.Add(currentPassword);
            fullInformation.Add(currentUsername + seperator + currentPassword);
            newList.Add(currentUsername + seperator + currentPassword);
            MessageBox.Show("Registration success!", "You have successful register you account!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(currentUsername + seperator + currentPassword);
                }
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] userInfo = line.Split(seperator);
                        fullInfo = line;
                        fullInformation.Add(fullInfo);
                        newList.Add(fullInfo);
                        usernames.Add(userInfo[0]);
                        passwords.Add(userInfo[1]);
                    }
                }
            }
        }

        private void ValidateInputs(TextBox tb, ErrorProvider ep)
        {
            if (tb.Text == "")
            {
                ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
               
                ep.Icon = Properties.Resources.iconfinder_sign_error_299045;
                ep.SetError(tb, "Field is empty!");

                tb.BackColor = Color.Red;
            }
            else
            {
                ep.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                ep.Icon = Properties.Resources.iconfinder_Checkmark_1891021;
                ep.SetError(tb, "Field is empty!");

                tb.BackColor = Color.Green;
            }
        }

        private void tbUsername_Validated(object sender, EventArgs e)
        {
            ValidateInputs(tbUsername, epUsername);
        }

       

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateInputs(tbPassword, epPassword);
        }
    }
}
