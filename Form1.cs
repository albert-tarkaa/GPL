using GPL.Commands;
using System.Text.RegularExpressions;

namespace GPL
{
    public partial class Form1 : Form
    {

        private CordinatesStateManager globalCordinates;
        private CommandParser CommandParser;

        public Form1()
        {
            InitializeComponent();
            // GPLPanel.Invalidate();
            // Initialize the context and set default coordinates
            CommandParser = new CommandParser();
            globalCordinates = new CordinatesStateManager();
            globalCordinates.GlobalX = 15;
            globalCordinates.GlobalY = 15;

            // GPLPanel.Invalidate();
        }



        private void BtnRun_Click(object sender, EventArgs e)
        {
            Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            Graphics g = GPLPanel.CreateGraphics();
            Pen pen = new Pen(Color.Black, 1);

            string inputCommands = GPLParser.Text.ToLower();
            string[] commands = inputCommands.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandText in commands)
            {
                Match drawToMatch = Regex.Match(commandText, @"drawto\((\d+), (\d+)\)");
                Match moveToMatch = Regex.Match(commandText, @"moveto\((\d+), (\d+)\)");
                Match rectMatch = Regex.Match(commandText, @"rect\((\d+), (\d+)\)");

                if (drawToMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandText, @"drawto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandText, @"drawto\((\d+), (\d+)\)").Groups[2].Value);

                    ICommand drawToCommand = new DrawTo(targetX, targetY, globalCordinates);
                    CommandParser.AddCommand(drawToCommand);
                }
                else if (moveToMatch.Success)
                {
                    // Match match = Regex.Match(commandText, @"MoveTo\((\d+), (\d+)\)");
                    int targetX = int.Parse(Regex.Match(commandText, @"moveto\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandText, @"moveto\((\d+), (\d+)\)").Groups[2].Value);

                    ICommand moveToCommand = new MoveTo(targetX, targetY, globalCordinates);
                    CommandParser.AddCommand(moveToCommand);
                }
                else if (rectMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandText, @"rect\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandText, @"rect\((\d+), (\d+)\)").Groups[2].Value);

                    ICommand rectCommand = new RectangleCommand(targetX, targetY, globalCordinates);
                    CommandParser.AddCommand(rectCommand);
                }
                else
                {
                    MessageBox.Show("Invalid command: " + commandText);
                }
            }
            CommandParser.ExecuteCommands(g);
            pen.Dispose(); // Dispose of the Pen
            g.Dispose();// Dispose of the Graphics

        }

        private void GPLPanel_Paint(object sender, PaintEventArgs e)
        {
            GPLPanel.Controls.Clear();
            try
            {
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Red, 1);

                int x = globalCordinates.GlobalX;
                int y = globalCordinates.GlobalY;
                int diameter = 6;

                g.DrawEllipse(pen, x, y, diameter, diameter);
                pen.Dispose();
                g.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}