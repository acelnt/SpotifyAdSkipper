﻿namespace SpotifyAdSkipper
{
    partial class AdSkipperInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdSkipperInfoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ForceSkipButton = new System.Windows.Forms.Button();
            this.CurrentArtistRegisterButton = new System.Windows.Forms.Button();
            this.CurrentAlbumRegisterbutton = new System.Windows.Forms.Button();
            this.CurrentTitleRegisterButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAudioInfo = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.IsAdLabel = new System.Windows.Forms.Label();
            this.PlayingAudiosBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LogBox = new System.Windows.Forms.TextBox();
            this.FormUpdate = new System.Windows.Forms.Timer(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.EditAdFeaturesButton = new System.Windows.Forms.Button();
            this.lblSpotiyOpen = new System.Windows.Forms.Label();
            this.lblSpotifyOpenInfo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ForceSkipButton);
            this.groupBox1.Controls.Add(this.CurrentArtistRegisterButton);
            this.groupBox1.Controls.Add(this.CurrentAlbumRegisterbutton);
            this.groupBox1.Controls.Add(this.CurrentTitleRegisterButton);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Info";
            // 
            // ForceSkipButton
            // 
            this.ForceSkipButton.Location = new System.Drawing.Point(385, 130);
            this.ForceSkipButton.Name = "ForceSkipButton";
            this.ForceSkipButton.Size = new System.Drawing.Size(111, 23);
            this.ForceSkipButton.TabIndex = 6;
            this.ForceSkipButton.Text = "Force skip";
            this.ForceSkipButton.UseVisualStyleBackColor = true;
            this.ForceSkipButton.Click += new System.EventHandler(this.ForceSkipButton_Click);
            // 
            // CurrentArtistRegisterButton
            // 
            this.CurrentArtistRegisterButton.Location = new System.Drawing.Point(259, 130);
            this.CurrentArtistRegisterButton.Name = "CurrentArtistRegisterButton";
            this.CurrentArtistRegisterButton.Size = new System.Drawing.Size(120, 23);
            this.CurrentArtistRegisterButton.TabIndex = 5;
            this.CurrentArtistRegisterButton.Text = "Filter artist";
            this.CurrentArtistRegisterButton.UseVisualStyleBackColor = true;
            this.CurrentArtistRegisterButton.Click += new System.EventHandler(this.CurrentArtistRegisterButton_Click);
            // 
            // CurrentAlbumRegisterbutton
            // 
            this.CurrentAlbumRegisterbutton.Location = new System.Drawing.Point(132, 130);
            this.CurrentAlbumRegisterbutton.Name = "CurrentAlbumRegisterbutton";
            this.CurrentAlbumRegisterbutton.Size = new System.Drawing.Size(120, 23);
            this.CurrentAlbumRegisterbutton.TabIndex = 4;
            this.CurrentAlbumRegisterbutton.Text = "Filter album title";
            this.CurrentAlbumRegisterbutton.UseVisualStyleBackColor = true;
            this.CurrentAlbumRegisterbutton.Click += new System.EventHandler(this.CurrentAlbumRegisterbutton_Click);
            // 
            // CurrentTitleRegisterButton
            // 
            this.CurrentTitleRegisterButton.Location = new System.Drawing.Point(6, 130);
            this.CurrentTitleRegisterButton.Name = "CurrentTitleRegisterButton";
            this.CurrentTitleRegisterButton.Size = new System.Drawing.Size(120, 23);
            this.CurrentTitleRegisterButton.TabIndex = 3;
            this.CurrentTitleRegisterButton.Text = "Filter song title";
            this.CurrentTitleRegisterButton.UseVisualStyleBackColor = true;
            this.CurrentTitleRegisterButton.Click += new System.EventHandler(this.CurrentTitleRegisterButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblAudioInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.IsAdLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.PlayingAudiosBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSpotiyOpen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSpotifyOpenInfo, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(490, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(490, 105);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblAudioInfo
            // 
            this.lblAudioInfo.AutoSize = true;
            this.lblAudioInfo.Location = new System.Drawing.Point(3, 23);
            this.lblAudioInfo.Name = "lblAudioInfo";
            this.lblAudioInfo.Size = new System.Drawing.Size(104, 26);
            this.lblAudioInfo.TabIndex = 0;
            this.lblAudioInfo.Text = "Playing Audios:\r\n(song - album - artist)";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(3, 86);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(29, 13);
            this.lblAd.TabIndex = 2;
            this.lblAd.Text = "Ad?:";
            // 
            // IsAdLabel
            // 
            this.IsAdLabel.AutoSize = true;
            this.IsAdLabel.Location = new System.Drawing.Point(113, 86);
            this.IsAdLabel.Name = "IsAdLabel";
            this.IsAdLabel.Size = new System.Drawing.Size(21, 13);
            this.IsAdLabel.TabIndex = 3;
            this.IsAdLabel.Text = "No";
            // 
            // PlayingAudiosBox
            // 
            this.PlayingAudiosBox.Location = new System.Drawing.Point(113, 26);
            this.PlayingAudiosBox.Multiline = true;
            this.PlayingAudiosBox.Name = "PlayingAudiosBox";
            this.PlayingAudiosBox.ReadOnly = true;
            this.PlayingAudiosBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PlayingAudiosBox.Size = new System.Drawing.Size(377, 57);
            this.PlayingAudiosBox.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LogBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 303);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(6, 19);
            this.LogBox.MaxLength = 100;
            this.LogBox.Multiline = true;
            this.LogBox.Name = "LogBox";
            this.LogBox.ReadOnly = true;
            this.LogBox.Size = new System.Drawing.Size(489, 278);
            this.LogBox.TabIndex = 0;
            // 
            // FormUpdate
            // 
            this.FormUpdate.Enabled = true;
            this.FormUpdate.Interval = 1000;
            this.FormUpdate.Tick += new System.EventHandler(this.FormUpdate_Tick);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(433, 486);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // EditAdFeaturesButton
            // 
            this.EditAdFeaturesButton.Location = new System.Drawing.Point(12, 486);
            this.EditAdFeaturesButton.Name = "EditAdFeaturesButton";
            this.EditAdFeaturesButton.Size = new System.Drawing.Size(415, 23);
            this.EditAdFeaturesButton.TabIndex = 3;
            this.EditAdFeaturesButton.Text = "Edit ad filters";
            this.EditAdFeaturesButton.UseVisualStyleBackColor = true;
            this.EditAdFeaturesButton.Click += new System.EventHandler(this.EditAdFeaturesButton_Click);
            // 
            // lblSpotiyOpen
            // 
            this.lblSpotiyOpen.AutoSize = true;
            this.lblSpotiyOpen.Location = new System.Drawing.Point(3, 0);
            this.lblSpotiyOpen.Name = "lblSpotiyOpen";
            this.lblSpotiyOpen.Size = new System.Drawing.Size(74, 13);
            this.lblSpotiyOpen.TabIndex = 7;
            this.lblSpotiyOpen.Text = "Spotify Open?";
            // 
            // lblSpotifyOpenInfo
            // 
            this.lblSpotifyOpenInfo.AutoSize = true;
            this.lblSpotifyOpenInfo.Location = new System.Drawing.Point(113, 0);
            this.lblSpotifyOpenInfo.Name = "lblSpotifyOpenInfo";
            this.lblSpotifyOpenInfo.Size = new System.Drawing.Size(21, 13);
            this.lblSpotifyOpenInfo.TabIndex = 8;
            this.lblSpotifyOpenInfo.Text = "No";
            // 
            // AdSkipperInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 521);
            this.Controls.Add(this.EditAdFeaturesButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdSkipperInfoForm";
            this.Text = "Spotify Ad Skipper Info";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAudioInfo;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label IsAdLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox LogBox;
        private System.Windows.Forms.Timer FormUpdate;
        private System.Windows.Forms.TextBox PlayingAudiosBox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button EditAdFeaturesButton;
        private System.Windows.Forms.Button CurrentAlbumRegisterbutton;
        private System.Windows.Forms.Button CurrentTitleRegisterButton;
        private System.Windows.Forms.Button CurrentArtistRegisterButton;
        private System.Windows.Forms.Button ForceSkipButton;
        private System.Windows.Forms.Label lblSpotiyOpen;
        private System.Windows.Forms.Label lblSpotifyOpenInfo;
    }
}