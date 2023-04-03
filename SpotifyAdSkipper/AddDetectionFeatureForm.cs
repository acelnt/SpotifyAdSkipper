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
    public partial class AddDetectionFeatureForm : Form
    {
        AudioProperty _audioProperty;

        public AddDetectionFeatureForm(AdDetection.AudioProperty audioProperty, string initialMatchValue = "")
        {
            InitializeComponent();
            
            _audioProperty = audioProperty;
            
            // Let label describe what is being added
            DescriptionLabel.Text = $"Add new {audioProperty.ToString()} ad filter.\nCase is ignored.";

            // Set the match value text box to the initial value
            MatchValueBox.Text = initialMatchValue;

            // Populate match strength drop down with correct values
            foreach (var detectionStrength in Enum.GetValues(typeof(AdDetection.DetectionStrength)))
            {
                MatchStrengthDropDown.Items.Add(detectionStrength.ToString());
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string matchValue = MatchValueBox.Text;
            AdDetection.DetectionStrength detectionStrength;
            Enum.TryParse(MatchStrengthDropDown.Text, out detectionStrength);

            AdDetection.AdDetector.AddAdDetectionFeature(_audioProperty, detectionStrength, matchValue);
            AdDetection.AdDetector.StoreAdDetectionFeaturesInFile();

            Close();
        }
    }
}
