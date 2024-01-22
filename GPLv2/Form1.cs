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
                string[] commands = inputCommands.Split(new char[] { '\n', '\v', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);


                List<string> whileLoopCommands = new List<string>();
                List<string> ifBlockCommands = new List<string>();
                List<string> methodCommands = new List<string>();

                foreach (string commandText in commands)
                {
                    errorLine++;
                    //ENDWHILE
                    if (globalCordinates.whileLoopFlag)
                    {
                        if (commandText.Trim().ToLower() == "endwhile")
                        {
                            globalCordinates.SetWhileLoopFlag(false);
                            ProcessWhileLoop(whileLoopCommands);
                            continue;
                        }

                        whileLoopCommands.Add(commandText);
                    }
                    //ENDIF
                    else if (globalCordinates.ifBlockFlag)
                    {
                        if (commandText.Trim().ToLower() == "endif")
                        {
                            globalCordinates.SetIfBlockFlag(false);
                            ProcessIfBlock(ifBlockCommands);
                            continue;
                        }

                        ifBlockCommands.Add(commandText);
                    }
                    else
                    {

                        //START WHILE
                        if (commandText.Trim().StartsWith("while"))
                        {
                            if (globalCordinates.LoopCounter < 1)
                            {
                                globalCordinates.SetWhileLoopFlag(true);
                                whileLoopCommands = new List<string>
                                {
                                    commandText.Trim()
                                };
                            }
                        }
                        //START IF
                        else if (commandText.Trim().StartsWith("if"))
                        {
                            globalCordinates.SetIfBlockFlag(true);
                            ifBlockCommands = new List<string>
                                {
                                    commandText.Trim()
                                };

                        }
                        else
                        {
                            // Process non-while and non-if loop and non-method commands
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
                    canvasGraphics.DrawString(ex.Message + string.Format(" at line {0}", globalCordinates.LineCounter), errorFont, errorBrush, errorPosition);
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

            while (LoopConditionManager.Process(whileCondition))
            {
                // Execute the body of the while loop
                foreach (string commandText in whileLoopCommands.Skip(1))
                {
                    var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
                    commandFactory.AddCommandFromText(commandText, CommandParser);
                }
            }
        }

        private void ProcessIfBlock(List<string> ifBlockCommands)
        {
            if (ifBlockCommands.Count < 2)
            {
                throw new InvalidOperationException("Invalid IF loop structure");
            }

            string whileCondition = ifBlockCommands[0].Trim().Substring("if".Length).Trim();

            if (LoopConditionManager.Process(whileCondition))
            {
                // Execute the body of the while loop
                foreach (string commandText in ifBlockCommands.Skip(1))
                {
                    var commandFactory = new CommandFactory(commandText.Trim(), GPLPanel, globalCordinates, canvas);
                    commandFactory.AddCommandFromText(commandText, CommandParser);
                }
            }
        }


        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] filePaths = openFileDialog.FileNames;

                // Use separate tasks for concurrent execution
                Task task1 = ExecuteCommandsFromFileAsync(filePaths[0]);
                Task task2 = ExecuteCommandsFromFileAsync(filePaths[1]);

                await Task.WhenAll(task1, task2);

            }
        }

        private async Task ExecuteCommandsFromFileAsync(string filePath)
        {
            try
            {
                string fileContents = await Task.Run(() => File.ReadAllText(filePath));

                // Split file contents into commands based on newlines
                string[] lines = fileContents.Split(new char[] { '\n', '\v', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                // Parse and execute commands from each line
                CommandParser commandParser = new CommandParser();

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;

                    var commandFactory = new CommandFactory(line.ToLower().Trim(), GPLPanel, globalCordinates, canvas);
                    commandFactory.AddCommandFromText(line, commandParser);
                }

                await Task.Run(() =>
                {
                    using (Graphics canvasGraphics = GPLPanel.CreateGraphics())
                    {
                        // Ensure that access to shared resources is synchronized
                        lock (canvasGraphics)
                        {
                            GPLPanel.Invoke((MethodInvoker)delegate
                            {
                                commandParser.ExecuteCommands(canvasGraphics);
                            });
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while executing commands from file '{filePath}': {ex.Message}");
            }
        }



    }
}