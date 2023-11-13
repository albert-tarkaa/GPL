namespace GPL.Utilities
{
    public class FileService
    {

        public FileService() { }

        public static bool ReadFromFile(RichTextBox GPLParser)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (Path.GetExtension(filePath).ToLower() == ".txt")
                {
                    try
                    {
                        string fileContents = File.ReadAllText(filePath);
                        GPLParser.Text = fileContents;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while loading the file: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a .txt file.");
                }
            }
            return false;
        }

        public static void SaveToFile(RichTextBox richTextBox)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = saveFileDialog.FileName;
                    string textToSave = richTextBox.Text;
                    System.IO.File.WriteAllText(filePath, textToSave);
                    MessageBox.Show("Commands saved to file successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
