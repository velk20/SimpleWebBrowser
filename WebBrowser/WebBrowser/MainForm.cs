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
        LoginForm form = null;
        WebBrowser web = null;
        string homePage = "https://www.google.com";
        public bool LOGED = false;
        int onlyOnce = 0;
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
            tbURL.Text = web.Url.AbsoluteUri;
            tabControl.SelectedTab.Text = web.DocumentTitle;
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
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "http://" + address.Trim();
            }
            try
            {
                wb.Navigate(new Uri(address));
                
            }
            catch (System.UriFormatException)
            {
                MessageBox.Show("Invalid url!");
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
            web = new WebBrowser()
            { ScriptErrorsSuppressed = true };
            web.Parent = tab;
            web.Dock = DockStyle.Fill;
            web.Navigate(homePage);
            web.DocumentCompleted += Web_DocumentCompleted;
        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;

            tabControl.SelectedTab.Text = web.DocumentTitle;
            tbURL.Text = web.Url.AbsoluteUri;
        }

       
        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            //comments on button when mouse is on it
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(btnBack, "Go back");
            toolTip1.SetToolTip(btnForward, "Go forward");
            toolTip1.SetToolTip(btnHomePage, "Go to your home page");
            toolTip1.SetToolTip(btnLoginRegister, "If you login to an account you can use Bookmarks functionality!");
            toolTip1.SetToolTip(btnNewTab, "Add a new tab to your browser\nIf you want to remove tab just double click on the tab!");
            toolTip1.SetToolTip(btnRefresh, "Refresh page");
            toolTip1.SetToolTip(btnSearch, "Search with URL");

            WebBrowserMain.Navigate(homePage);
            WebBrowserMain.DocumentCompleted += WebBrowserMain_DocumentCompleted;
            cbBookmarks.Enabled = false;
            btnAddFavorite.Enabled = false;
            btnLoginRegister.ForeColor = Color.Green;
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
                cbBookmarks.Items.Add(web.Url.AbsoluteUri);
                using (FileStream read = new FileStream(form.filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter write = new StreamWriter(read))
                    {
                        for (int i = 0; i < form.fullInformation.Count; i++)
                        {
                            string user = form.fullInformation[i];
                            int index = i;
                            if (user.StartsWith(form.currentLoggedUsername))
                            {
                                form.fullInformation.RemoveAt(index);
                                form.fullInformation.Insert(index, form.newList[i] + form.seperator + web.Url.AbsoluteUri);
                                form.newList.RemoveAt(index);
                                form.newList.Insert(index, form.fullInformation[i] + form.seperator + web.Url.AbsoluteUri);
                            }
                        }
                    }
                    File.WriteAllLines(form.filePath, form.fullInformation);
                }
            }
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
                    btnLoginRegister.ForeColor = Color.Red;
                    cbBookmarks.Enabled = true;
                    btnAddFavorite.Enabled = true;
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
                cbBookmarks.Items.Clear();
                cbBookmarks.Enabled = false;
                btnAddFavorite.Enabled = false;
                btnLoginRegister.ForeColor = Color.Green;
                cbBookmarks.Text = "";
                onlyOnce = 0;
                return;
            }
        }
        private void cbBookmarks_SelectedValueChanged(object sender, EventArgs e)
        {
            //Get current web browser
            web = tabControl.SelectedTab.Controls[0] as WebBrowser;
            string cbURL = cbBookmarks.SelectedItem.ToString().Trim();
            Navigate(cbURL, web);
            
            cbBookmarks.Items.Clear();
            for (int j = 0; j < form.currentUserURLSList.Count; j++)
            {
                cbBookmarks.Items.Add(form.currentUserURLSList[j].ToString());
            }

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
        private void cbBookmarks_MouseClick(object sender, MouseEventArgs e)
        {
            if (onlyOnce < 1 && LOGED == true)
            {
                for (int j = 0; j < form.currentUserURLSList.Count; j++)
                {
                    cbBookmarks.Items.Add(form.currentUserURLSList[j].ToString());
                }
                onlyOnce++;
            }
            if (!LOGED)
            {
                MessageBox.Show("You need to log in to use bookmarks function!", "Need to log in first!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tbURL_DoubleClick(object sender, EventArgs e)
        {
            tbURL.SelectAll();
        }

        private void tbURL_Click(object sender, EventArgs e)
        {
            tbURL.Select();
        }
    }
}
