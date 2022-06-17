using System.Windows.Forms;

namespace GenshinServerSwitcher
{
    internal class MainForm : Form
    {
        private Button selectPath;
        private TextBox textBox1;
        private Label label1;
        private Button startGame;
        private Button switchServer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.switchServer = new System.Windows.Forms.Button();
            this.selectPath = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Button();
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
            // 
            // selectPath
            // 
            this.selectPath.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectPath.Location = new System.Drawing.Point(13, 40);
            this.selectPath.Name = "selectPath";
            this.selectPath.Size = new System.Drawing.Size(266, 27);
            this.selectPath.TabIndex = 1;
            this.selectPath.Text = "重选游戏路径";
            this.selectPath.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(266, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(163, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Test Server";
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(32)))));
            this.startGame.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startGame.Location = new System.Drawing.Point(13, 125);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(273, 58);
            this.startGame.TabIndex = 4;
            this.startGame.Text = "开始游戏";
            this.startGame.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(298, 195);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.selectPath);
            this.Controls.Add(this.switchServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "原神 服务器切换器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
