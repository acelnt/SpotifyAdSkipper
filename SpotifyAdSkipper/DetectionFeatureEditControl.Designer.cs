namespace SpotifyAdSkipper
{
    partial class DetectionFeatureEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.MatchValuesList = new System.Windows.Forms.ListView();
            this.strengthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.matchValueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MatchValuesList
            // 
            this.MatchValuesList.AutoArrange = false;
            this.MatchValuesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.strengthColumn,
            this.matchValueColumn});
            this.MatchValuesList.FullRowSelect = true;
            this.MatchValuesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MatchValuesList.HideSelection = false;
            this.MatchValuesList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.MatchValuesList.Location = new System.Drawing.Point(3, 3);
            this.MatchValuesList.Name = "MatchValuesList";
            this.MatchValuesList.Size = new System.Drawing.Size(534, 488);
            this.MatchValuesList.TabIndex = 0;
            this.MatchValuesList.UseCompatibleStateImageBehavior = false;
            this.MatchValuesList.View = System.Windows.Forms.View.Details;
            // 
            // strengthColumn
            // 
            this.strengthColumn.Text = "Match Strength";
            this.strengthColumn.Width = 87;
            // 
            // matchValueColumn
            // 
            this.matchValueColumn.Text = "Match Value";
            this.matchValueColumn.Width = 150;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 497);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(264, 23);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(273, 497);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(264, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // DetectionFeatureEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.MatchValuesList);
            this.MinimumSize = new System.Drawing.Size(72, 78);
            this.Name = "DetectionFeatureEditControl";
            this.Size = new System.Drawing.Size(540, 525);
            this.Resize += new System.EventHandler(this.DetectionFeatureEditControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView MatchValuesList;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.ColumnHeader matchValueColumn;
        private System.Windows.Forms.ColumnHeader strengthColumn;
    }
}
