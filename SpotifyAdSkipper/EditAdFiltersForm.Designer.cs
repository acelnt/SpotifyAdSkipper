namespace SpotifyAdSkipper
{
    partial class EditAdFiltersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PropertyTabs = new System.Windows.Forms.TabControl();
            this.Title = new System.Windows.Forms.TabPage();
            this.detectionFeatureEditControl1 = new SpotifyAdSkipper.FilterListEditControl();
            this.Album = new System.Windows.Forms.TabPage();
            this.detectionFeatureEditControl2 = new SpotifyAdSkipper.FilterListEditControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PropertyTabs.SuspendLayout();
            this.Title.SuspendLayout();
            this.Album.SuspendLayout();
            this.SuspendLayout();
            // 
            // PropertyTabs
            // 
            this.PropertyTabs.Controls.Add(this.Title);
            this.PropertyTabs.Controls.Add(this.Album);
            this.PropertyTabs.Location = new System.Drawing.Point(12, 12);
            this.PropertyTabs.Name = "PropertyTabs";
            this.PropertyTabs.SelectedIndex = 0;
            this.PropertyTabs.Size = new System.Drawing.Size(349, 426);
            this.PropertyTabs.TabIndex = 0;
            // 
            // Title
            // 
            this.Title.Controls.Add(this.detectionFeatureEditControl1);
            this.Title.Location = new System.Drawing.Point(4, 22);
            this.Title.Name = "Title";
            this.Title.Padding = new System.Windows.Forms.Padding(3);
            this.Title.Size = new System.Drawing.Size(341, 400);
            this.Title.TabIndex = 0;
            this.Title.Text = "Song Title";
            this.Title.UseVisualStyleBackColor = true;
            // 
            // detectionFeatureEditControl1
            // 
            this.detectionFeatureEditControl1.AudioProperty = SpotifyAdSkipper.AdDetection.AudioProperty.Title;
            this.detectionFeatureEditControl1.Location = new System.Drawing.Point(0, 0);
            this.detectionFeatureEditControl1.MinimumSize = new System.Drawing.Size(72, 78);
            this.detectionFeatureEditControl1.Name = "detectionFeatureEditControl1";
            this.detectionFeatureEditControl1.Size = new System.Drawing.Size(341, 400);
            this.detectionFeatureEditControl1.TabIndex = 0;
            // 
            // Album
            // 
            this.Album.Controls.Add(this.detectionFeatureEditControl2);
            this.Album.Location = new System.Drawing.Point(4, 22);
            this.Album.Name = "Album";
            this.Album.Padding = new System.Windows.Forms.Padding(3);
            this.Album.Size = new System.Drawing.Size(341, 400);
            this.Album.TabIndex = 1;
            this.Album.Text = "Album Name";
            this.Album.UseVisualStyleBackColor = true;
            // 
            // detectionFeatureEditControl2
            // 
            this.detectionFeatureEditControl2.AudioProperty = SpotifyAdSkipper.AdDetection.AudioProperty.Album;
            this.detectionFeatureEditControl2.Location = new System.Drawing.Point(0, 0);
            this.detectionFeatureEditControl2.MinimumSize = new System.Drawing.Size(72, 78);
            this.detectionFeatureEditControl2.Name = "detectionFeatureEditControl2";
            this.detectionFeatureEditControl2.Size = new System.Drawing.Size(341, 400);
            this.detectionFeatureEditControl2.TabIndex = 0;
            // 
            // EditAdFeaturesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 450);
            this.Controls.Add(this.PropertyTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EditAdFeaturesForm";
            this.Text = "Edit Ad Filters";
            this.PropertyTabs.ResumeLayout(false);
            this.Title.ResumeLayout(false);
            this.Album.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl PropertyTabs;
        private System.Windows.Forms.TabPage Title;
        private System.Windows.Forms.TabPage Album;
        private System.Windows.Forms.Timer timer1;
        private FilterListEditControl detectionFeatureEditControl1;
        private FilterListEditControl detectionFeatureEditControl2;
    }
}