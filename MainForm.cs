using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GenshinServerSwitcher
{
    internal class MainForm : Form
    {
        private Button selectPath;
        private TextBox pathText;
        private Label serverStatus;
        private Button startGame;
        private Button about;
        private Button switchServer;

        public MainForm()
        {
            InitializeComponent();
            pathText.Text = GetGamePath();
            CheckStatus();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.switchServer = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Button();
            this.pathText = new System.Windows.Forms.TextBox();
            this.serverStatus = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Button();
            this.about = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // switchServer
            // 
            this.switchServer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switchServer.Location = new System.Drawing.Point(12, 72);
            this.switchServer.Name = "switchServer";
            this.switchServer.Size = new System.Drawing.Size(145, 44);
            this.switchServer.TabIndex = 0;
            this.switchServer.Text = "切换服务器";
            this.switchServer.UseVisualStyleBackColor = true;
            this.switchServer.Click += new System.EventHandler(this.SwitchServer);
            // 
            // selectPath
            // 
            this.selectPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectPath.Location = new System.Drawing.Point(13, 40);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(218, 27);
            this.selectPath.TabIndex = 1;
            this.selectPath.Text = "重选游戏路径";
            this.selectPath.UseVisualStyleBackColor = true;
            this.selectPath.Click += new System.EventHandler(this.SelectPath);
            // 
            // pathText
            // 
            this.pathText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pathText.Location = new System.Drawing.Point(13, 13);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(299, 21);
            this.pathText.TabIndex = 2;
            // 
            // serverStatus
            // 
            this.serverStatus.AutoSize = true;
            this.serverStatus.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.serverStatus.Location = new System.Drawing.Point(163, 87);
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(151, 16);
            this.serverStatus.TabIndex = 3;
            this.serverStatus.Text = "没有检测到游戏文件";
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(32)))));
            this.startGame.Cursor = System.Windows.Forms.Cursors.Default;
            this.startGame.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startGame.Location = new System.Drawing.Point(13, 125);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(299, 58);
            this.startGame.TabIndex = 4;
            this.startGame.Text = "开始游戏";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.StartGame);
            // 
            // about
            // 
            this.about.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.about.Location = new System.Drawing.Point(237, 40);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 27);
            this.about.TabIndex = 5;
            this.about.Text = "关于";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.OpenAboutPage);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(324, 195);
            this.Controls.Add(this.about);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.serverStatus);
            this.Controls.Add(this.pathText);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.switchServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "原神 服务器切换器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// 尝试读取注册表以获取游戏根目录
        /// </summary>
        /// <returns></returns>
        private string GetGamePath()
        {
            RegistryKey localMachineRegistry
            = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                                      Environment.Is64BitOperatingSystem
                                          ? RegistryView.Registry64
                                          : RegistryView.Registry32);

            return string.IsNullOrEmpty("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\原神")
                ? string.Empty
                : localMachineRegistry.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\原神").GetValue("InstallPath").ToString();
        }

        /// <summary>
        /// 选择路径
        /// </summary>
        private void SelectPath(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathText.Text = dialog.SelectedPath;
                CheckStatus();
            }
        }

        /// <summary>
        /// 启动游戏
        /// </summary>
        private void StartGame(object sender, EventArgs e)
        {
            Process launcher = Process.Start($"{pathText.Text}\\launcher.exe");
            Environment.Exit(0);
        }

        /// <summary>
        /// 检查游戏服务器情况
        /// </summary>
        private void CheckStatus()
        {
            if (!System.IO.File.Exists($"{this.pathText.Text}\\config.ini"))
            {
                serverStatus.Text = "没有检测到游戏文件";
            }
            else
            {
                string status = INI.Read("launcher", "cps", string.Empty, $"{this.pathText.Text}\\config.ini");
                serverStatus.Text = (status == "mihoyo") ? "天空岛（米哈游）" : "世界树（B站）";
            }
        }

        /// <summary>
        /// 切换服务器
        /// </summary>
        private void SwitchServer(object sender, EventArgs e)
        {
            // 检查以确保游戏信息正常
            if (!System.IO.File.Exists($"{this.pathText.Text}\\config.ini"))
                return;

            string ini1 = $"{this.pathText.Text}\\config.ini";
            string ini2 = $"{this.pathText.Text}\\Genshin Impact Game\\config.ini";

            if (INI.Read("launcher", "cps", string.Empty, ini1) == "mihoyo")
            {
                // 将启动信息修改为 世界树
                INI.Write("launcher", "cps", "bilibili", ini1);
                INI.Write("launcher", "channel", "14", ini1);
                INI.Write("launcher", "sub_channel", "0", ini1);
                INI.Write("General", "cps", "bilibili", ini2);
                INI.Write("General", "channel", "14", ini2);
                INI.Write("General", "sub_channel", "0", ini2);
            }
            else
            {
                // 将启动信息修改为 天空岛
                INI.Write("launcher", "cps", "mihoyo", ini1);
                INI.Write("launcher", "channel", "1", ini1);
                INI.Write("launcher", "sub_channel", "1", ini1);
                INI.Write("General", "cps", "mihoyo", ini2);
                INI.Write("General", "channel", "1", ini2);
                INI.Write("General", "sub_channel", "1", ini2);
            }

            // 更改后更新服务器信息防止误导
            CheckStatus();
        }

        /// <summary>
        /// 打开“关于页”窗口
        /// </summary>
        private void OpenAboutPage(object sender, EventArgs e)
        {
            AboutPage about = new AboutPage();
            about.Size = new System.Drawing.Size(470, 160);
            about.Show();
        }
    }
}
