namespace RowaConnect
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ProgramRun = new System.ComponentModel.BackgroundWorker();
            this.IpAdress_box = new System.Windows.Forms.TextBox();
            this.Port_box = new System.Windows.Forms.TextBox();
            this.Connect_TB = new System.Windows.Forms.Button();
            this.Clean_TB = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.TextBox();
            this.Unconnect_label = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Ip_label = new System.Windows.Forms.Label();
            this.Port_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Program_box = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Root = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProgramRun
            // 
            this.ProgramRun.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProgramRun_DoWork);
            // 
            // IpAdress_box
            // 
            this.IpAdress_box.Location = new System.Drawing.Point(82, 16);
            this.IpAdress_box.Name = "IpAdress_box";
            this.IpAdress_box.Size = new System.Drawing.Size(135, 23);
            this.IpAdress_box.TabIndex = 0;
            this.IpAdress_box.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // Port_box
            // 
            this.Port_box.Location = new System.Drawing.Point(322, 16);
            this.Port_box.Name = "Port_box";
            this.Port_box.Size = new System.Drawing.Size(100, 23);
            this.Port_box.TabIndex = 1;
            this.Port_box.Text = "7000";
            // 
            // Connect_TB
            // 
            this.Connect_TB.Image = ((System.Drawing.Image)(resources.GetObject("Connect_TB.Image")));
            this.Connect_TB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Connect_TB.Location = new System.Drawing.Point(478, 16);
            this.Connect_TB.Name = "Connect_TB";
            this.Connect_TB.Size = new System.Drawing.Size(133, 26);
            this.Connect_TB.TabIndex = 2;
            this.Connect_TB.Text = "     Check Connection";
            this.Connect_TB.UseVisualStyleBackColor = true;
            this.Connect_TB.Click += new System.EventHandler(this.Connect_TB_Click);
            // 
            // Clean_TB
            // 
            this.Clean_TB.Location = new System.Drawing.Point(693, 452);
            this.Clean_TB.Name = "Clean_TB";
            this.Clean_TB.Size = new System.Drawing.Size(101, 23);
            this.Clean_TB.TabIndex = 3;
            this.Clean_TB.Text = "Clean Console";
            this.Clean_TB.UseVisualStyleBackColor = true;
            this.Clean_TB.Click += new System.EventHandler(this.Clean_TB_Click);
            // 
            // Console
            // 
            this.Console.Location = new System.Drawing.Point(18, 227);
            this.Console.Multiline = true;
            this.Console.Name = "Console";
            this.Console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Console.Size = new System.Drawing.Size(750, 219);
            this.Console.TabIndex = 4;
            this.Console.Resize += new System.EventHandler(this.Console_Resize);
            // 
            // Unconnect_label
            // 
            this.Unconnect_label.Image = ((System.Drawing.Image)(resources.GetObject("Unconnect_label.Image")));
            this.Unconnect_label.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Unconnect_label.Location = new System.Drawing.Point(617, 16);
            this.Unconnect_label.Name = "Unconnect_label";
            this.Unconnect_label.Size = new System.Drawing.Size(133, 26);
            this.Unconnect_label.TabIndex = 5;
            this.Unconnect_label.Text = "      Abort Connection";
            this.Unconnect_label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Unconnect_label.UseVisualStyleBackColor = true;
            this.Unconnect_label.Click += new System.EventHandler(this.Unconnect_label_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(608, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Copyright Rowa Automation 2022";
            // 
            // Ip_label
            // 
            this.Ip_label.AutoSize = true;
            this.Ip_label.Location = new System.Drawing.Point(6, 19);
            this.Ip_label.Name = "Ip_label";
            this.Ip_label.Size = new System.Drawing.Size(65, 15);
            this.Ip_label.TabIndex = 7;
            this.Ip_label.Text = "Ip Address:";
            // 
            // Port_label
            // 
            this.Port_label.AutoSize = true;
            this.Port_label.Location = new System.Drawing.Point(266, 19);
            this.Port_label.Name = "Port_label";
            this.Port_label.Size = new System.Drawing.Size(32, 15);
            this.Port_label.TabIndex = 8;
            this.Port_label.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Info Console:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(18, 487);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "        Not connected ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(806, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Program_box);
            this.groupBox1.Location = new System.Drawing.Point(12, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(756, 52);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Robot Route";
            // 
            // Program_box
            // 
            this.Program_box.FormattingEnabled = true;
            this.Program_box.Location = new System.Drawing.Point(6, 20);
            this.Program_box.Name = "Program_box";
            this.Program_box.Size = new System.Drawing.Size(605, 23);
            this.Program_box.TabIndex = 0;
            this.Program_box.SelectedIndexChanged += new System.EventHandler(this.Program_box_SelectedIndexChanged);
            this.Program_box.SelectedValueChanged += new System.EventHandler(this.Program_box_SelectedValueChanged);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(630, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = " Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(478, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "     Choose a folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Controls.Add(this.Unconnect_label);
            this.groupBox2.Controls.Add(this.Connect_TB);
            this.groupBox2.Controls.Add(this.IpAdress_box);
            this.groupBox2.Controls.Add(this.Port_label);
            this.groupBox2.Controls.Add(this.Port_box);
            this.groupBox2.Controls.Add(this.Ip_label);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(756, 55);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Rowa Connect";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Root);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(12, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(756, 52);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File storage route";
            // 
            // Root
            // 
            this.Root.Location = new System.Drawing.Point(6, 20);
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(461, 23);
            this.Root.TabIndex = 3;
            this.Root.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(806, 511);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.Clean_TB);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Rowa Connect";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker ProgramRun;
        private TextBox IpAdress_box;
        private TextBox Port_box;
        private Button Connect_TB;
        private Button Clean_TB;
        private TextBox Console;
        private Button Unconnect_label;
        private Label label1;
        private Label Ip_label;
        private Label Port_label;
        private Label label2;
        private Label label3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private GroupBox groupBox1;
        private ComboBox Program_box;
        private Button button1;
        private Button button2;
        private GroupBox groupBox2;
        private NotifyIcon notifyIcon1;
        private GroupBox groupBox3;
        private TextBox Root;
    }
}