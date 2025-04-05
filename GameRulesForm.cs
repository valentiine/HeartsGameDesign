using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HeartsGameDesign
{
    public partial class GameRulesForm : Form
    {
        public GameRulesForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkClickMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            // Tried using Process.Start on it's own but I was getting errors so I found this alternative
            try
            {
                var psi = new ProcessStartInfo
                {
                    // Hearts Game YouTube Tutorial
                    FileName = "https://www.youtube.com/watch?v=u1Pxo_OqTUc",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while trying to open the link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
