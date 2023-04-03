using SpotifyAdSkipper.AdDetection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyAdSkipper
{
    public partial class AddAdFilterForm : Form
    {
        AudioProperty _audioProperty;

        public AddAdFilterForm(AdDetection.AudioProperty audioProperty, string initialMatchValue = "")
        {
            InitializeComponent();
            
            _audioProperty = audioProperty;
            
            // Let label describe what is being added
            DescriptionLabel.Text = $"Add new {audioProperty.ToString()} ad filter.\nCase is ignored.";

            // Set the match value text box to the initial value
            MatchValueBox.Text = initialMatchValue;

            // Populate match strength drop down with correct values
            foreach (var matchStrength in Enum.GetValues(typeof(AdDetection.MatchStrength)))
            {
                MatchStrengthDropDown.Items.Add(matchStrength.ToString());
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string matchValue = MatchValueBox.Text;
            AdDetection.MatchStrength matchStrength;
            Enum.TryParse(MatchStrengthDropDown.Text, out matchStrength);

            AdDetection.AdDetector.AddAdDetectionFilter(_audioProperty, matchStrength, matchValue);
            AdDetection.AdDetector.StoreAdDetectionFiltersInFile();

            Close();
        }
    }
}
