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
            textBox1 = new TextBox();
            btnRun = new Button();
            button2 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            GPLPanel = new Panel();
            pictureBox1 = new PictureBox();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            GPLParser.Size = new Size(395, 273);
            GPLParser.TabIndex = 0;
            GPLParser.Text = "";
            GPLParser.UseWaitCursor = true;
            
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "command line";
            textBox1.Size = new Size(310, 23);
            textBox1.TabIndex = 1;
            // 
            // btnRun
            // 
            btnRun.BackColor = SystemColors.HotTrack;
            btnRun.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnRun.FlatStyle = FlatStyle.Popup;
            btnRun.ForeColor = SystemColors.Window;
            btnRun.Location = new Point(3, 32);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 2;
            btnRun.Text = "Run";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += BtnRun_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Location = new Point(84, 32);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Syntax";
            button2.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Controls.Add(btnRun);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Location = new Point(12, 291);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(395, 62);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // GPLPanel
            // 
            GPLPanel.BackColor = SystemColors.ControlLight;
            GPLPanel.Location = new Point(413, 13);
            GPLPanel.Name = "GPLPanel";
            GPLPanel.Padding = new Padding(5);
            GPLPanel.Size = new Size(375, 311);
            GPLPanel.TabIndex = 5;
            GPLPanel.Paint += GPLPanel_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Frame_4;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(15, 369);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(776, 206);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 591);
            Controls.Add(pictureBox1);
            Controls.Add(GPLPanel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(GPLParser);
            Name = "Form1";
            Text = "Simple Programming Language";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox GPLParser;
        private TextBox textBox1;
        private Button btnRun;
        private Button button2;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox pictureBox1;
        public Panel GPLPanel;
    }
}