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
        public List<string> usernames = new List<string>();
        public List<string> passwords = new List<string>();
        public List<string> siteURLS = new List<string>();
        public List<string> fullInformation = new List<string>();
        string fullInfo;
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
                    MessageBox.Show("Login success!");
                    WebBrowserForm webForm = new WebBrowserForm();
                    webForm.LOGED = true;
                    currentLoggedUsername = currentUsername;

                    
                    this.Close();
                     res = DialogResult.OK;
                   
                }
                else if (i == usernames.Count)
                {
                    MessageBox.Show("Wrong username/password!");

                }

            }

            if (webForm.LOGED)
            {
                using (FileStream red = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(red))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            fullInfo = line;

                            string[] userInfo = line.Split(seperator);
                            if (fullInfo.Contains(currentLoggedUsername))
                            {


                                for (int j = 2; j < userInfo.Length; j++)
                                {
                                    siteURLS.Add(userInfo[j]);
                                    webForm.cbBookmarks.Items.Add(userInfo[j]);
                                }

                                for (int j = 0; j < siteURLS.Count; j++)
                                {
                                    webForm.cbBookmarks.Items.Add(siteURLS[j]);

                                }
                            }




                        }
                    }
                }
            }
            

           


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string currentUsername = tbUsername.Text;
            string currentPassword = tbPassword.Text;

            if (usernames.Contains(currentUsername))
            {
                MessageBox.Show("Username is taken!");
                return;
            }

            usernames.Add(currentUsername);
            passwords.Add(currentPassword);
            MessageBox.Show("Registration success!");

          

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
                        usernames.Add(userInfo[0]);
                        passwords.Add(userInfo[1]);

                       
                    }
                }
            }
        }
    }
}
