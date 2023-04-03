using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media;
using Windows.Media.Control;

namespace SpotifyAdSkipper
{
    public partial class AdSkipperInfoForm : Form
    {
        LoggerReader _loggerReader = new LoggerReader();

        public AdSkipperInfoForm()
        {
            InitializeComponent();
            UpdateContent();
        }

        public void ScrollLogToBottom()
        {
            LogBox.SelectionStart = LogBox.TextLength;
            LogBox.SelectionLength = 0;
            LogBox.ScrollToCaret();
        }

        private void FormUpdate_Tick(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private async void UpdateContent()
        {
            // Update log box with new log data
            List<string> newLines = _loggerReader.NextLines();
            LogBox.AppendText(string.Join("\r\n", newLines) + ((newLines.Count > 0) ? "\r\n" : ""));

            // get playing audios and if there is an ad
            var spotifyPlayingAudios = await SpotifyController.GetPlayingAudios();
            bool isAdPlaying = SpotifyController.IsAdPlaying(spotifyPlayingAudios);

            // Update PlayingAudiosBox to contain each currently playing audio title and album name
            string playingAudiosText = "";
            foreach (var audio in spotifyPlayingAudios)
            {
                string title = audio.Title;
                string album = audio.AlbumTitle;
                playingAudiosText += $"{title} - {album}\r\n";
            }
            PlayingAudiosBox.Text = playingAudiosText;

            // Set is ad label to yes or no based on if an ad is playing or not
            if (isAdPlaying)
            {
                IsAdLabel.Text = "Yes";
            }
            else
            {
                IsAdLabel.Text = "No";
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            SpotifyController.CloseAndRestart();
        }

        private void EditAdFeaturesButton_Click(object sender, EventArgs e)
        {
            EditAdFiltersForm editAdFiltersForm = new EditAdFiltersForm();
            editAdFiltersForm.Show();
        }

        private async void CurrentTitleRegisterButton_Click(object sender, EventArgs e)
        {
            var playingTracks = await SpotifyController.GetPlayingAudios();
            if (playingTracks.Count > 0)
            {
                AddAdFilterForm addAdFilterForm = new AddAdFilterForm(
                    AdDetection.AudioProperty.Title,
                    playingTracks[0].Title.ToLower());
                addAdFilterForm.Show();
            }
        }

        private async void CurrentAlbumRegisterbutton_Click(object sender, EventArgs e)
        {
            var playingTracks = await SpotifyController.GetPlayingAudios();
            if (playingTracks.Count > 0)
            {
                AddAdFilterForm addAdFiltersForm = new AddAdFilterForm(
                    AdDetection.AudioProperty.Album,
                    playingTracks[0].AlbumTitle.ToLower());
                addAdFiltersForm.Show();
            }
        }
    }
}
