
namespace SimpleWebBrowser
{
    partial class WebBrowserForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowserForm));
            this.label1 = new System.Windows.Forms.Label();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnHomePage = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.WebBrowserMain = new System.Windows.Forms.WebBrowser();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnNewTab = new System.Windows.Forms.Button();
            this.btnAddFavorite = new System.Windows.Forms.Button();
            this.btnLoginRegister = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBookmarks = new System.Windows.Forms.ComboBox();
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter URL: ";
            // 
            // tbURL
            // 
            this.tbURL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbURL.Location = new System.Drawing.Point(86, 16);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(328, 22);
            this.tbURL.TabIndex = 1;
            this.tbURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbURL_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(420, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(663, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnForward
            // 
            this.btnForward.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnForward.Location = new System.Drawing.Point(582, 16);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 4;
            this.btnForward.Text = ">>";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnHomePage
            // 
            this.btnHomePage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnHomePage.Location = new System.Drawing.Point(744, 16);
            this.btnHomePage.Name = "btnHomePage";
            this.btnHomePage.Size = new System.Drawing.Size(75, 23);
            this.btnHomePage.TabIndex = 5;
            this.btnHomePage.Text = "Home";
            this.btnHomePage.UseVisualStyleBackColor = true;
            this.btnHomePage.Click += new System.EventHandler(this.btnHomePage_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(501, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // WebBrowserMain
            // 
            this.WebBrowserMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowserMain.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserMain.Name = "WebBrowserMain";
            this.WebBrowserMain.ScriptErrorsSuppressed = true;
            this.WebBrowserMain.Size = new System.Drawing.Size(1249, 590);
            this.WebBrowserMain.TabIndex = 7;
            this.WebBrowserMain.Url = new System.Uri("https://www.google.com/", System.UriKind.Absolute);
            this.WebBrowserMain.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowserMain_DocumentCompleted);
            this.WebBrowserMain.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowserMain_Navigated);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(3, 44);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1253, 606);
            this.tabControl.TabIndex = 8;
            this.tabControl.DoubleClick += new System.EventHandler(this.tabControl_DoubleClick);
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WebBrowserMain);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1245, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnNewTab
            // 
            this.btnNewTab.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNewTab.Location = new System.Drawing.Point(825, 16);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new System.Drawing.Size(75, 23);
            this.btnNewTab.TabIndex = 9;
            this.btnNewTab.Text = "New Tab";
            this.btnNewTab.UseVisualStyleBackColor = true;
            this.btnNewTab.Click += new System.EventHandler(this.btnNewTab_Click);
            // 
            // btnAddFavorite
            // 
            this.btnAddFavorite.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddFavorite.Location = new System.Drawing.Point(906, 16);
            this.btnAddFavorite.Name = "btnAddFavorite";
            this.btnAddFavorite.Size = new System.Drawing.Size(113, 24);
            this.btnAddFavorite.TabIndex = 10;
            this.btnAddFavorite.Text = "Add bookmark";
            this.btnAddFavorite.UseVisualStyleBackColor = true;
            this.btnAddFavorite.Click += new System.EventHandler(this.btnAddFavorite_Click);
            // 
            // btnLoginRegister
            // 
            this.btnLoginRegister.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoginRegister.Location = new System.Drawing.Point(1152, 24);
            this.btnLoginRegister.Name = "btnLoginRegister";
            this.btnLoginRegister.Size = new System.Drawing.Size(104, 39);
            this.btnLoginRegister.TabIndex = 11;
            this.btnLoginRegister.Text = "Log in / Register";
            this.btnLoginRegister.UseVisualStyleBackColor = true;
            this.btnLoginRegister.Click += new System.EventHandler(this.btnLoginRegister_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1051, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Bookmarks";
            // 
            // cbBookmarks
            // 
            this.cbBookmarks.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBookmarks.FormattingEnabled = true;
            this.cbBookmarks.Location = new System.Drawing.Point(1025, 17);
            this.cbBookmarks.Name = "cbBookmarks";
            this.cbBookmarks.Size = new System.Drawing.Size(121, 24);
            this.cbBookmarks.TabIndex = 13;
            this.cbBookmarks.SelectedValueChanged += new System.EventHandler(this.cbBookmarks_SelectedValueChanged);
            this.cbBookmarks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbBookmarks_MouseClick);
            // 
            // lblLoginUsername
            // 
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLoginUsername.Location = new System.Drawing.Point(1186, 8);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.Size = new System.Drawing.Size(40, 13);
            this.lblLoginUsername.TabIndex = 8;
            this.lblLoginUsername.Text = "Guest";
            // 
            // WebBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1258, 653);
            this.Controls.Add(this.lblLoginUsername);
            this.Controls.Add(this.cbBookmarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLoginRegister);
            this.Controls.Add(this.btnAddFavorite);
            this.Controls.Add(this.btnNewTab);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnHomePage);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WebBrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Web Browser";
            this.Load += new System.EventHandler(this.WebBrowserForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnHomePage;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.WebBrowser WebBrowserMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNewTab;
        private System.Windows.Forms.Button btnAddFavorite;
        private System.Windows.Forms.Button btnLoginRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoginUsername;
        public System.Windows.Forms.ComboBox cbBookmarks;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

