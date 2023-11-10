namespace GPL
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
            GPLParser = new RichTextBox();
            pictureBox1 = new PictureBox();
            GPLPanel = new PictureBox();
            label1 = new Label();
            button2 = new Button();
            btnRun = new Button();
            textBoxParser = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            Save = new Button();
            Open = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GPLPanel).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // GPLParser
            // 
            GPLParser.AcceptsTab = true;
            GPLParser.BorderStyle = BorderStyle.None;
            GPLParser.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            GPLParser.Location = new Point(12, 46);
            GPLParser.Name = "GPLParser";
            GPLParser.ScrollBars = RichTextBoxScrollBars.Vertical;
            GPLParser.Size = new Size(427, 324);
            GPLParser.TabIndex = 0;
            GPLParser.Text = "";
            GPLParser.UseWaitCursor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Frame_4;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(26, 434);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 206);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // GPLPanel
            // 
            GPLPanel.BackColor = SystemColors.ControlLight;
            GPLPanel.Location = new Point(460, 46);
            GPLPanel.Name = "GPLPanel";
            GPLPanel.Size = new Size(354, 324);
            GPLPanel.TabIndex = 7;
            GPLPanel.TabStop = false;
            GPLPanel.MouseMove += pictureBox_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(738, 403);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(352, 3);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Syntax";
            button2.UseVisualStyleBackColor = false;
            // 
            // btnRun
            // 
            btnRun.BackColor = SystemColors.HotTrack;
            btnRun.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.ForeColor = SystemColors.Window;
            btnRun.Location = new Point(271, 3);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 2;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += BtnRun_Click;
            // 
            // textBoxParser
            // 
            textBoxParser.Location = new Point(3, 3);
            textBoxParser.Name = "textBoxParser";
            textBoxParser.PlaceholderText = "command line";
            textBoxParser.Size = new Size(262, 23);
            textBoxParser.TabIndex = 1;
            textBoxParser.KeyDown += textBoxParser_KeyDown;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(textBoxParser);
            flowLayoutPanel1.Controls.Add(btnRun);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Location = new Point(12, 386);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(442, 32);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(Save);
            flowLayoutPanel2.Controls.Add(Open);
            flowLayoutPanel2.Location = new Point(15, 7);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(424, 32);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // Save
            // 
            Save.BackColor = SystemColors.ActiveCaption;
            Save.FlatAppearance.BorderColor = SystemColors.HotTrack;
            Save.FlatStyle = FlatStyle.Popup;
            Save.ForeColor = SystemColors.Window;
            Save.Location = new Point(3, 3);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 2;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = false;
            Save.Click += Save_Click;
            // 
            // Open
            // 
            Open.BackColor = Color.RosyBrown;
            Open.FlatStyle = FlatStyle.Popup;
            Open.Location = new Point(84, 3);
            Open.Name = "Open";
            Open.Size = new Size(75, 23);
            Open.TabIndex = 3;
            Open.Text = "Open Command";
            Open.UseVisualStyleBackColor = false;
            Open.Click += Open_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 652);
            Controls.Add(label1);
            Controls.Add(GPLPanel);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(GPLParser);
            Name = "Form1";
            Text = "Simple Programming Language";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)GPLPanel).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox GPLParser;
        private PictureBox pictureBox1;
        private PictureBox GPLPanel;
        private Label label1;
        private Button button2;
        private Button btnRun;
        private TextBox textBoxParser;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button Save;
        private Button Open;
    }
}