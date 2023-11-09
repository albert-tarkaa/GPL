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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GPLPanel).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // GPLParser
            // 
            GPLParser.AcceptsTab = true;
            GPLParser.BorderStyle = BorderStyle.None;
            GPLParser.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            GPLParser.Location = new Point(12, 12);
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
            pictureBox1.Location = new Point(26, 410);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 206);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // GPLPanel
            // 
            GPLPanel.BackColor = SystemColors.ControlLight;
            GPLPanel.Location = new Point(460, 12);
            GPLPanel.Name = "GPLPanel";
            GPLPanel.Size = new Size(354, 324);
            GPLPanel.TabIndex = 7;
            GPLPanel.TabStop = false;
            GPLPanel.MouseMove += pictureBox_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 380);
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
            flowLayoutPanel1.Location = new Point(12, 342);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(442, 32);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 628);
            Controls.Add(label1);
            Controls.Add(GPLPanel);
            Controls.Add(pictureBox1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(GPLParser);
            Name = "Form1";
            Text = "Simple Programming Language";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)GPLPanel).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
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
    }
}