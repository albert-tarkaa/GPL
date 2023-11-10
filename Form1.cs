using GPL.Commands;
using GPL.Utilities;

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
            canvas = new Bitmap(GPLPanel.Width, GPLPanel.Height);
            GPLPanel.Image = canvas;

            CommandParser = new CommandParser();
            globalCordinates = new CordinatesStateManager(canvas, GPLPanel);


            // DrawCursor();

            //GPLPanel.Invalidate();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            //Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            //int panelWidth = GPLPanel.Width;
            //int panelHeight = GPLPanel.Height;
            //Bitmap bitmap = new Bitmap(panelWidth, panelHeight);
            //Graphics g = Graphics.FromImage(bitmap);

            GPLPanel.Refresh();
            //Pen pen = new Pen(Color.Black, 1);
            var clearCommand = new ClearDisplayParser(canvas);
            CommandParser.AddCommand(clearCommand);

            string inputCommands = GPLParser.Text.ToLower().Trim();
            string[] commands = inputCommands.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string commandText in commands)
            {
                var commandFactory = new CommandFactory(commandText, GPLPanel, globalCordinates, canvas);

                commandFactory.AddCommandFromText(commandText, CommandParser);
            }
            using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
            {
                CommandParser.ExecuteCommands(canvasGraphics);
            }
        }

        private void textBoxParser_KeyDown(object sender, KeyEventArgs e)
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




        public void DrawCursor()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                Pen pen = new Pen(Color.Red);
                g.DrawEllipse(pen, globalCordinates.GlobalX, globalCordinates.GlobalY, 6, 6);
            }
            // GPLPanel.Invalidate();
        }

        private void Open_Click(object sender, EventArgs e)
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


        private void Save_Click(object sender, EventArgs e)
        {
            FileService.SaveToFile(GPLParser);

        }

    }
}