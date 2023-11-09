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
            canvas = new Bitmap(GPLPanel.Width, GPLPanel.Height);
            GPLPanel.Image = canvas;

            CommandParser = new CommandParser();
            globalCordinates = new CordinatesStateManager(canvas, GPLPanel);
           

            //DrawCursor();

            GPLPanel.Invalidate();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            //Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
            //int panelWidth = GPLPanel.Width;
            //int panelHeight = GPLPanel.Height;
            //Bitmap bitmap = new Bitmap(panelWidth, panelHeight);
            //Graphics g = Graphics.FromImage(bitmap);

            //Pen pen = new Pen(Color.Black, 1);
            string commandLine = textBox1.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(commandLine))
            {

            }

            string inputCommands = GPLParser.Text.ToLower();
            string[] commands = inputCommands.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);



            foreach (string commandText in commands)
            {
                var commandFactory = new CommandFactory(commandText, GPLPanel, globalCordinates, canvas);
               
                if (commandFactory != null)
                {
                    CommandParser.AddCommand(commandFactory.CreateCommand());
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

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }



        //public void DrawCursor()
        //{
        //    using (Graphics g = Graphics.FromImage(canvas))
        //    {
        //        Pen pen = new Pen(Color.Red);
        //        g.DrawEllipse(pen, globalCordinates.GlobalX, globalCordinates.GlobalY, 6, 6);
        //    }
        //    GPLPanel.Invalidate();
        //}
    }
}