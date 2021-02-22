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
    public partial class WebBrowserForm : Form
    {
        TabPage tab = null;
        WebBrowser addedWebBrowser = null;
        LoginForm form = null;
        WebBrowser web = null;
        string homePage = "https://www.google.com";
        public bool LOGED = false;
        List<string> users = new List<string>();
        string currentLine;


        public WebBrowserForm()
        {
            InitializeComponent();


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoBack)
                {
                    web.GoBack();
                }
            }

        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                if (web.CanGoForward)
                {
                    web.GoForward();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Refresh();
            }

        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
            {
                web.Navigate(homePage);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            if (web != null)
                Navigate(tbURL.Text.Trim(), web);


        }



        private void Navigate(String address, WebBrowser wb)
        {
            if (String.IsNullOrEmpty(address)) return;

            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address.Trim();
            }
            try
            {
                wb.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void WebBrowserMain_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            tbURL.Text = WebBrowserMain.Url.ToString().Trim();
        }

        private void WebBrowserMain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {


            tabControl.SelectedTab.Text = WebBrowserMain.DocumentTitle;
        }

        private void btnNewTab_Click(object sender, EventArgs e)
        {
            NewTab();
        }

        private void NewTab()
        {
            tab = new TabPage();
            tab.Text = "New Tab";
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            addedWebBrowser = new WebBrowser()
            { ScriptErrorsSuppressed = true };
            addedWebBrowser.Parent = tab;
            addedWebBrowser.Dock = DockStyle.Fill;
            addedWebBrowser.Navigate(homePage);
            addedWebBrowser.DocumentCompleted += AddedWebBrowser_DocumentCompleted;
        }

        private void AddedWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            tabControl.SelectedTab.Text = addedWebBrowser.DocumentTitle;
            tbURL.Text = addedWebBrowser.Url.AbsoluteUri;

        }

        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            WebBrowserMain.Navigate(homePage);
            WebBrowserMain.DocumentCompleted += WebBrowserMain_DocumentCompleted;


        }

        private void tabControl_DoubleClick(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabControl.SelectedTab);

            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;

            tbURL.Text = web.Url.ToString();
        }



        private void btnAddFavorite_Click(object sender, EventArgs e)
        {

            if (!LOGED)

            {
                MessageBox.Show("You need to log in  to use bookmarks function!", "Need to log in first!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                form.fullInformation.Clear();
                cbBookmarks.Items.Add(web.Url.AbsoluteUri);
                using (FileStream read = new FileStream(form.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter write = new StreamWriter(read))
                    {






                        for (int i = 0; i < form.usernames.Count; i++)
                        {
                            form.fullInformation.Add(form.usernames[i] + form.seperator + form.passwords[i] + form.seperator + web.Url.AbsoluteUri.ToString());
                        }



                    }

                }
            }

            File.WriteAllLines(form.filePath, form.fullInformation);


        }



            

        

            private void btnLoginRegister_Click(object sender, EventArgs e)
            {
                if (!LOGED)

                {
                    form = new LoginForm();
                    DialogResult res = form.ShowDialog();

                    if (form.res == DialogResult.OK)
                    {
                        btnLoginRegister.Text = "Log out";
                        lblLoginUsername.Text = form.currentLoggedUsername;
                        LOGED = true;
                        return;
                    }
                }
                else if (LOGED)
                {
                    form.currentLoggedUsername = "";
                    btnLoginRegister.Text = "Log in / Register";
                    lblLoginUsername.Text = "Guest";
                    LOGED = false;
                    return;
                }
            }

            private void cbBookmarks_SelectedValueChanged(object sender, EventArgs e)
            {
                //Get current web browser
                web = tabControl.SelectedTab.Controls[0] as WebBrowser;

                string cbURL = cbBookmarks.SelectedItem.ToString();
                Navigate(cbURL, web);


            }

            private void tbURL_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)13)
                {
                    web = tabControl.SelectedTab.Controls[0] as WebBrowser;
                    if (web != null)
                    {
                        Navigate(tbURL.Text.Trim(), web);
                    }
                }
            }

            private void tabControl_MouseClick(object sender, MouseEventArgs e)
            {
                //Get current web browser
                web = tabControl.SelectedTab.Controls[0] as WebBrowser;

                tbURL.Text = web.Url.ToString();
            }
        }
}   
