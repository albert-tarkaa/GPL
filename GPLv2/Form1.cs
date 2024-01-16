using GPL.Commands;
using GPL.Utilities;
using System;
using System.Diagnostics;

namespace GPL
{
    public partial class Form1 : Form
    {

        private DrawingSettings globalCordinates;
        private CommandParser CommandParser;
        private Bitmap canvas;

        public Form1()
        {
            InitializeComponent();
            // Initialize the context and set default coordinates
            canvas = new Bitmap(GPLPanel.Width, GPLPanel.Height);
            GPLPanel.Image = canvas;
            CommandParser = new CommandParser();
            globalCordinates = new DrawingSettings(canvas);
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            int errorLine = 0;
            try
            {
                GPLPanel.Refresh();
                var clearCommand = new ClearDisplayParser(canvas);
                CommandParser.AddCommand(clearCommand);

                

                string inputCommands = GPLParser.Text.ToLower().Trim();
                string[] commands = inputCommands.Split(new char[] { '\n', '\v' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string commandText in commands)
                {
                   // errorLine =  Array.IndexOf(commands, commandText) + 1;

                    var commandFactory = new CommandFactory(commandText, GPLPanel, globalCordinates, canvas);
                    commandFactory.AddCommandFromText(commandText, CommandParser);
                }
                using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
                {
                    CommandParser.ExecuteCommands(canvasGraphics);
                }
            }
            catch (Exception ex)
            {
                using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
                {
                    PointF errorPosition = new PointF(10, 15);
                    Font errorFont = new Font("Times New Roman", 11, FontStyle.Regular);
                    Brush errorBrush = new SolidBrush(Color.Red);
                    canvasGraphics.DrawString(ex.Message + string.Format(" at line {0}",errorLine), errorFont, errorBrush, errorPosition);
                }

            }
        }
        private void textBoxParser_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var clearCommand = new ClearDisplayParser(canvas);
                    using (Graphics g = GPLPanel.CreateGraphics())
                    {
                        clearCommand.Execute(g);
                    }
                    string inputCommand = textBoxParser.Text.ToLower().Trim();
                    if (!string.IsNullOrEmpty(inputCommand))
                    {
                        var commandFactory = new CommandFactory(inputCommand, GPLPanel, globalCordinates, canvas);
                        commandFactory.AddCommandFromText(inputCommand, CommandParser);

                        using (Graphics graphics = GPLPanel.CreateGraphics())
                        {
                            graphics.DrawImage(canvas, Point.Empty);
                            CommandParser.ExecuteCommands(graphics);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
                {
                    PointF errorPosition = new PointF(10, 15);
                    Font errorFont = new Font("Times New Roman", 11, FontStyle.Regular);
                    Brush errorBrush = new SolidBrush(Color.Red);
                    canvasGraphics.DrawString(ex.Message, errorFont, errorBrush, errorPosition);
                }
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FileService.ReadFromFile(GPLParser))
                {
                    throw new Exception("An error occurred while loading the file");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileService.SaveToFile(GPLParser);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/albert-tarkaa/GPL/#readme",
                UseShellExecute = true
            });
        }
    }
}