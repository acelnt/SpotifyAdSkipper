using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Xaml.Controls.Maps;

namespace SpotifyAdSkipper
{
    public partial class FilterListEditControl : UserControl
    {
        private AdDetection.AudioProperty _audioProperty;

        public AdDetection.AudioProperty AudioProperty { 
            get
            {
                return _audioProperty;
            }
            set 
            {
                _audioProperty = value;
                ListUpdate();
            } }

        public FilterListEditControl()
        {
            InitializeComponent();
            ListUpdate();
        }

        /// <summary>
        /// Updates the list of match values to accurately reflect the features in AdDection.AdDetector
        /// </summary>
        private void ListUpdate()
        {
            MatchValuesList.Items.Clear();
            var matchValues = AdDetection.AdDetector.GetMatchValuesForProperty(this.AudioProperty);
            foreach (AdDetection.MatchStrength matchStrength in matchValues.Keys)
            {
                foreach (string matchValue in matchValues[matchStrength])
                {
                    MatchValuesList.Items.Add(
                        new ListViewItem(
                            new string[] { Enum.GetName(typeof(AdDetection.MatchStrength), matchStrength), matchValue }
                        )
                    );
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in MatchValuesList.SelectedItems)
            {
                string matchValue = item.SubItems[1].Text;
                AdDetection.MatchStrength matchStrength;
                Enum.TryParse(item.SubItems[0].Text, out matchStrength);

                AdDetection.AdDetector.RemoveAdDetectionFilter(AudioProperty, matchStrength, matchValue);
            }
            ListUpdate();
            AdDetection.AdDetector.StoreAdDetectionFiltersInFile();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddAdFilterForm addAdFiltersForm = new AddAdFilterForm(AudioProperty);
            addAdFiltersForm.Show();
            addAdFiltersForm.Disposed += (a, b) => ListUpdate();
        }

        private void FilterListEditControl_Resize(object sender, EventArgs e)
        {
            AddButton.Size = new Size(this.Size.Width / 2 - 6, 23);
            AddButton.Location = new Point(3, this.Size.Height - 28);
            RemoveButton.Size = new Size(this.Size.Width / 2 - 6, 23);
            RemoveButton.Location = new Point(this.Size.Width / 2 + 3, this.Size.Height - 28);
            MatchValuesList.Size = new Size(this.Size.Width - 6, this.Size.Height - 37);
        }
    }
}
