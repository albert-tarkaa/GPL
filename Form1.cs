using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace GPL
{
    public partial class Form1 : Form
    {
       // private List<string> shapeCommands = new List<string>();

        private CordinatesStateManager globalCordinates;

        public Form1()
        {
            InitializeComponent();

            // Initialize the context and set default coordinates
            globalCordinates = new CordinatesStateManager();
            globalCordinates.GlobalX = 15;
            globalCordinates.GlobalY = 15;

            GPLPanel.Invalidate();
        }



        private void BtnRun_Click(object sender, EventArgs e)
        {
            // Clear the panel before redrawing.
            GPLPanel.Controls.Clear();

            Color[] shapeColors = { Color.Blue, Color.Red, Color.Green, Color.Orange, Color.Purple };
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