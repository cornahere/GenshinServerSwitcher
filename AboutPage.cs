using System.Windows.Forms;

namespace GenshinServerSwitcher
{
    /// <summary>
    /// 关于页面
    /// </summary>
    internal class AboutPage : Form
    {
        private Label copyright;
        private Label licenseInfo;
        private LinkLabel osLink;
        private Label contactUs;
        private PictureBox pictureBox1;

        public AboutPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.copyright = new System.Windows.Forms.Label();
            this.licenseInfo = new System.Windows.Forms.Label();
            this.osLink = new System.Windows.Forms.LinkLabel();
            this.contactUs = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GenshinServerSwitcher.Properties.Resources.Corner_with_word;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // copyright
            // 
            resources.ApplyResources(this.copyright, "copyright");
            this.copyright.Name = "copyright";
            // 
            // licenseInfo
            // 
            resources.ApplyResources(this.licenseInfo, "licenseInfo");
            this.licenseInfo.Name = "licenseInfo";
            // 
            // osLink
            // 
            resources.ApplyResources(this.osLink, "osLink");
            this.osLink.Name = "osLink";
            this.osLink.TabStop = true;
            this.osLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenWebsite);
            // 
            // contactUs
            // 
            resources.ApplyResources(this.contactUs, "contactUs");
            this.contactUs.Name = "contactUs";
            // 
            // AboutPage
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.contactUs);
            this.Controls.Add(this.osLink);
            this.Controls.Add(this.licenseInfo);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 打开开源页面
        /// </summary>
        private void OpenWebsite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Hidden-Corner/GenshinServerSwitcher");
        }
    }
}
