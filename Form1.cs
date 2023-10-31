using GPL.Commands;
using System.Text.RegularExpressions;

namespace GPL
{
    public partial class Form1 : Form
    {

        private CordinatesStateManager globalCordinates;
        private CommandParser CommandParser;
        private Bitmap canvas;

        public Form1()
        {
            InitializeComponent();
            // GPLPanel.Invalidate();
            // Initialize the context and set default coordinates
            CommandParser = new CommandParser();
            globalCordinates = new CordinatesStateManager();

            canvas = new Bitmap(GPLPanel.Width, GPLPanel.Height);
            GPLPanel.Image = canvas;
            DrawCursor();

            // GPLPanel.Invalidate();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            //Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            //int panelWidth = GPLPanel.Width;
            //int panelHeight = GPLPanel.Height;
            //Bitmap bitmap = new Bitmap(panelWidth, panelHeight);
            //Graphics g = Graphics.FromImage(bitmap);

            //Pen pen = new Pen(Color.Black, 1);

            string inputCommands = GPLParser.Text.ToLower();
            string[] commands = inputCommands.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandText in commands)
            {
                Match drawToMatch = Regex.Match(commandText, @"drawto\((\d+), (\d+)\)");
                Match moveToMatch = Regex.Match(commandText, @"moveto\((\d+), (\d+)\)");
                Match rectMatch = Regex.Match(commandText, @"rect\((\d+), (\d+)\)");
                Match trigMatch = Regex.Match(commandText, @"trig\((\d+), (\d+)\)");
                Match circleMatch = Regex.Match(commandText, @"^circle\((\d+)\)$");

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
                else if (trigMatch.Success)
                {
                    int targetX = int.Parse(Regex.Match(commandText, @"trig\((\d+), (\d+)\)").Groups[1].Value);
                    int targetY = int.Parse(Regex.Match(commandText, @"trig\((\d+), (\d+)\)").Groups[2].Value);

                    ICommand triangleCommand = new TriangleCommand(targetX, targetY, globalCordinates);
                    CommandParser.AddCommand(triangleCommand);
                }
                else if (circleMatch.Success)
                {
                    int radius = int.Parse(Regex.Match(commandText, @"circle\((\d+)\)").Groups[1].Value);

                    ICommand circleCommand = new CircleCommand(radius, globalCordinates);
                    CommandParser.AddCommand(circleCommand);
                }
                else
                {
                    MessageBox.Show("Invalid command: " + commandText);
                }
            }

            using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
            {
                CommandParser.ExecuteCommands(canvasGraphics);
            }

        }

        //Added for debug purposes
        private void UpdateCoordinatesLabel(int x, int y)
        {
            label1.Text = $"X: {x}, Y: {y}";
        }
        //Added for debug purposes
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateCoordinatesLabel(e.X, e.Y);
        }



        private void DrawCursor()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Pen pen = new Pen(Color.Red);
                g.DrawEllipse(pen, globalCordinates.GlobalX, globalCordinates.GlobalY, 6, 6);
            }
            GPLPanel.Invalidate();
        }
    }
}