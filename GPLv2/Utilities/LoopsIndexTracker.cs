namespace GPL.Utilities
{
    public class LoopsIndexTracker
    {
        private List<int> whileIndices;

        private List<int> ifIndices;

        public LoopsIndexTracker()
        {
            whileIndices = new List<int>();
            ifIndices = new List<int>();
        }

        public List<int> GetWhileIndices(List<string> commands)
        {
            whileIndices.Clear();

            for (int i = 0; i < commands.Count; i++)
            {
                string commandText = commands[i].Trim();

                if (commandText.StartsWith("while"))
                {
                    // Add the index where "while" occurs
                    whileIndices.Add(i);
                }
            }

            return whileIndices;
        }

        public List<int> GetIfIndices(string[] commands)
        {
            ifIndices.Clear();

            for (int i = 0; i < commands.Length; i++)
            {
                string commandText = commands[i].Trim();

                if (commandText.StartsWith("if"))
                {
                    // Add the index where "while" occurs
                    ifIndices.Add(i);
                }
            }

            return ifIndices;
        }
    }
}
