using GPL.Commands;
using GPL.Utilities;
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
                string[] commands = inputCommands.Split(new char[] { '\n', '\v', '\t' }, StringSplitOptions.RemoveEmptyEntries);


                int endwhileCount = commands.Count(command => command.Trim().ToLower() == "endwhile");

                List<string> whileLoopCommands = new List<string>();

                foreach (string commandText in commands)
                {
                    if (globalCordinates.whileLoopFlag)
                    {
                        // Check for the end of the while loop
                        if (commandText.Trim().ToLower() == "endwhile")
                        {
                            if (endwhileCount == 1)
                            {
                                globalCordinates.SetWhileLoopFlag(false);
                                ProcessWhileLoop(whileLoopCommands);
                            }
                            continue;
                        }

                        whileLoopCommands.Add(commandText);
                       
                    }
                    else
                    {
                        if (commandText.Trim().StartsWith("while"))
                        {
                            // Set the while loop flag and initialize the while loop command list
                            if (globalCordinates.LoopCounter < 1)
                            {
                                globalCordinates.SetWhileLoopFlag(true);
                                whileLoopCommands = new List<string>
                                {
                                    commandText.Trim()
                                };
                            }
                        }
                        else
                        {
                            // Process non-while loop commands
                            var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
                            commandFactory.AddCommandFromText(commandText, CommandParser);
                        }
                    }
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
                    canvasGraphics.DrawString(ex.Message + string.Format(" at line {0}", errorLine), errorFont, errorBrush, errorPosition);
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

        private void ProcessWhileLoop(List<string> whileLoopCommands)
        {
            if (whileLoopCommands.Count < 2)
            {
                throw new InvalidOperationException("Invalid while loop structure");
            }

            string whileCondition = whileLoopCommands[0].Trim().Substring("while".Length).Trim();

            while (LoopConditionManager.EvaluateCondition(whileCondition))
            {
                // Execute the body of the while loop
                foreach (string commandText in whileLoopCommands.Skip(1))
                {
                    var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
                    commandFactory.AddCommandFromText(commandText, CommandParser);
                }
            }
        }


        #region  Discarded code for Nested While Loops
        //private void ProcessWhileLoop(List<string> whileLoopCommands, int WhileLoopCounter)
        //{
        //    if (whileLoopCommands.Count < 2)
        //    {
        //        throw new InvalidOperationException("Invalid while loop structure");
        //    }

        //    string whileCondition = whileLoopCommands[0].Trim().Substring("while".Length).Trim();

        //    while (LoopConditionManager.EvaluateCondition(whileCondition) && WhileLoopCounter > 0)
        //    {
        //        // Execute the body of the while loop
        //        foreach (string commandText in whileLoopCommands.Skip(1))
        //        {
        //            var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
        //            commandFactory.AddCommandFromText(commandText, CommandParser);
        //        }

        //        // Decrement the WhileLoopCounter for the next iteration
        //        WhileLoopCounter--;

        //        // Recursively call the ProcessWhileLoop method
        //        ProcessWhileLoop(whileLoopCommands, WhileLoopCounter);
        //    }

        //    // Reset the WhileLoopCounter after the while loop exits
        //    globalCordinates.WhileLoopCounter = 0;
        //}

        //private void ProcessWhileLoop(List<string> whileLoopCommands, int outerWhileLoopCounter)
        //{
        //    LoopsIndexTracker indexTracker = new LoopsIndexTracker();
        //    List<int> whileIndices = indexTracker.GetWhileIndices(whileLoopCommands);
        //    if (whileLoopCommands.Count < 2)
        //    {
        //        throw new InvalidOperationException("Invalid while loop structure");
        //    }

        //    string whileCondition = whileLoopCommands[0].Trim().Substring("while".Length).Trim();

        //    while (LoopConditionManager.EvaluateCondition(whileCondition) && outerWhileLoopCounter > 0)
        //    {
        //        // Execute the body of the while loop
        //        foreach (string commandText in whileLoopCommands)
        //        {
        //            if (commandText.Contains("while"))
        //            {
        //                continue;
        //            }
        //            var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
        //            commandFactory.AddCommandFromText(commandText, CommandParser);
        //        }

        //        // Increment the WhileLoopCounter for the next iteration of the outer loop
        //        outerWhileLoopCounter--;

        //        // Introduce a nestedWhileLoopCounter for the nested loop
        //        int nestedWhileLoopCounter = globalCordinates.WhileLoopCounter;

        //        while (LoopConditionManager.EvaluateCondition(whileCondition) && nestedWhileLoopCounter > 0)
        //        {
        //            // Execute the body of the nested while loop
        //            foreach (string commandText in whileLoopCommands)
        //            {
        //                if (commandText.Contains("while"))
        //                {
        //                    continue;
        //                }
        //                var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
        //                commandFactory.AddCommandFromText(commandText, CommandParser);
        //            }

        //            // Decrement the nestedWhileLoopCounter for the next iteration of the nested loop
        //            nestedWhileLoopCounter--;
        //        }
        //    }

        //    // Reset the WhileLoopCounter after the while loop exits
        //    globalCordinates.WhileLoopCounter = 0;
        //}

        #endregion
    }
}