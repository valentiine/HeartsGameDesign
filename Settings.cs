using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Numerics;

namespace HeartsGameDesign
{
    public partial class Settings : Form
    {

        // Define the music path (relative so any device can utilize)
        private SoundPlayer player = new SoundPlayer(@"Music\one_piece.wav");


        private GameStatistics gameStats;

        public Settings(GameStatistics stats)
        {
            InitializeComponent();
            gameStats = stats;
            btnChangeNames.Click += btnChangeNames_Click;
            btnChangeToRed.Click += btnChangeToRed_Click;
            btnChangeToGreen.Click += btnChangeToGreen_Click;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeNames_Click(object sender, EventArgs e)
        {
            // Helper function to validate names
            Func<string, bool> isValidName = (name) =>
                !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ');

            // Validate all name text boxes
            if (!isValidName(txtNewCPU1Name.Text) ||
                !isValidName(txtNewCPU2Name.Text) ||
                !isValidName(txtNewPlayerName.Text) ||
                !isValidName(txtNewCPU3Name.Text))
            {
                // Show a message box to inform the user
                MessageBox.Show("All names must be entered, contain only letters and spaces.", "Invalid Names", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the event handler without changing the names
            }

            // Get the main form instance and change names
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (mainForm != null)
            {
                mainForm.ChangePlayerAndCpuNames(txtNewCPU1Name.Text, txtNewCPU2Name.Text, txtNewPlayerName.Text, txtNewCPU3Name.Text);
            }
        }



        // This event will be triggered when the user clicks the Change To Red button
        private void btnChangeToRed_Click(object sender, EventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault(); // Get the main form instance
            if (mainForm != null)
            {
                // Call the method to change the table color on the main form
                mainForm.ChangeTableColorToRed();
            }
        }

        // This event will be triggered when the user clicks the Change To Green button
        private void btnChangeToGreen_Click(object sender, EventArgs e)
        {
            var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault(); // Get the main form instance
            if (mainForm != null)
            {
                // Call the method to change the table color on the main form
                mainForm.ChangeTableColorToGreen();
            }
        }


        // Close the Settings page
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            // Play the music
            player.Play();
            player.PlayLooping();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            // Stop the music
            player.Stop();
        }

        private void btnGameStats_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gameStats.GetStatisticsSummary(), "Game Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
