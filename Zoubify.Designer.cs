namespace music_playlist
{
    partial class Zoubify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zoubify));
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.volumeSlider1 = new NAudio.Gui.VolumeSlider();
            this.panel3 = new System.Windows.Forms.Panel();
            this.songNamePlaybar = new System.Windows.Forms.Label();
            this.artistNamePlaybar = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.secsPassed = new System.Windows.Forms.Label();
            this.nextSongButton = new System.Windows.Forms.PictureBox();
            this.prevSongButton = new System.Windows.Forms.PictureBox();
            this.playSongButton = new System.Windows.Forms.PictureBox();
            this.playbar = new System.Windows.Forms.Panel();
            this.likeSongButton = new System.Windows.Forms.PictureBox();
            this.currentSongCover = new System.Windows.Forms.PictureBox();
            this.randomSongButton = new System.Windows.Forms.PictureBox();
            this.repeatSongButton = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.songPanel0 = new System.Windows.Forms.Panel();
            this.artist0 = new System.Windows.Forms.Label();
            this.title0 = new System.Windows.Forms.Label();
            this.cover0 = new System.Windows.Forms.PictureBox();
            this.bottomPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.likeSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentSongCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomSongButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatSongButton)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.songPanel0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover0)).BeginInit();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.bottomPanel.Controls.Add(this.searchButton);
            this.bottomPanel.Controls.Add(this.searchTextBox);
            this.bottomPanel.Controls.Add(this.volumeSlider1);
            this.bottomPanel.Controls.Add(this.panel3);
            this.bottomPanel.Controls.Add(this.logoPictureBox);
            this.bottomPanel.Controls.Add(this.secsPassed);
            this.bottomPanel.Controls.Add(this.nextSongButton);
            this.bottomPanel.Controls.Add(this.prevSongButton);
            this.bottomPanel.Controls.Add(this.playSongButton);
            this.bottomPanel.Controls.Add(this.playbar);
            this.bottomPanel.Controls.Add(this.likeSongButton);
            this.bottomPanel.Controls.Add(this.currentSongCover);
            this.bottomPanel.Controls.Add(this.randomSongButton);
            this.bottomPanel.Controls.Add(this.repeatSongButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 538);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1158, 105);
            this.bottomPanel.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.BackgroundImage = global::music_playlist.Properties.Resources.searchLens;
            this.searchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Location = new System.Drawing.Point(1111, 75);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(35, 26);
            this.searchButton.TabIndex = 5;
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchTextBox.Location = new System.Drawing.Point(984, 79);
            this.searchTextBox.MaxLength = 150;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(122, 20);
            this.searchTextBox.TabIndex = 1;
            // 
            // volumeSlider1
            // 
            this.volumeSlider1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.volumeSlider1.BackColor = System.Drawing.Color.White;
            this.volumeSlider1.ForeColor = System.Drawing.Color.White;
            this.volumeSlider1.Location = new System.Drawing.Point(1039, 27);
            this.volumeSlider1.Name = "volumeSlider1";
            this.volumeSlider1.Size = new System.Drawing.Size(107, 13);
            this.volumeSlider1.TabIndex = 13;
            this.volumeSlider1.VolumeChanged += new System.EventHandler(this.volumeSlider1_VolumeChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel3.Controls.Add(this.songNamePlaybar);
            this.panel3.Controls.Add(this.artistNamePlaybar);
            this.panel3.Location = new System.Drawing.Point(107, 21);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 72);
            this.panel3.TabIndex = 12;
            // 
            // songNamePlaybar
            // 
            this.songNamePlaybar.AutoSize = true;
            this.songNamePlaybar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.songNamePlaybar.Font = new System.Drawing.Font("Ebrima", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.songNamePlaybar.ForeColor = System.Drawing.Color.White;
            this.songNamePlaybar.Location = new System.Drawing.Point(3, 8);
            this.songNamePlaybar.Name = "songNamePlaybar";
            this.songNamePlaybar.Size = new System.Drawing.Size(102, 25);
            this.songNamePlaybar.TabIndex = 10;
            this.songNamePlaybar.Text = "[song title]";
            this.songNamePlaybar.MouseLeave += new System.EventHandler(this.songNamePlaybar_MouseLeave);
            // 
            // artistNamePlaybar
            // 
            this.artistNamePlaybar.AutoSize = true;
            this.artistNamePlaybar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.artistNamePlaybar.Font = new System.Drawing.Font("Ebrima", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artistNamePlaybar.ForeColor = System.Drawing.Color.White;
            this.artistNamePlaybar.Location = new System.Drawing.Point(4, 39);
            this.artistNamePlaybar.Name = "artistNamePlaybar";
            this.artistNamePlaybar.Size = new System.Drawing.Size(58, 20);
            this.artistNamePlaybar.TabIndex = 9;
            this.artistNamePlaybar.Text = "[artist]";
            this.artistNamePlaybar.MouseEnter += new System.EventHandler(this.artistNamePlaybar_MouseEnter);
            this.artistNamePlaybar.MouseLeave += new System.EventHandler(this.artistNamePlaybar_MouseLeave);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logoPictureBox.BackgroundImage = global::music_playlist.Properties.Resources.zoubify;
            this.logoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logoPictureBox.Location = new System.Drawing.Point(748, 27);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(169, 59);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // secsPassed
            // 
            this.secsPassed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.secsPassed.AutoSize = true;
            this.secsPassed.BackColor = System.Drawing.Color.Transparent;
            this.secsPassed.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secsPassed.ForeColor = System.Drawing.Color.DarkGray;
            this.secsPassed.Location = new System.Drawing.Point(530, 73);
            this.secsPassed.Name = "secsPassed";
            this.secsPassed.Size = new System.Drawing.Size(103, 21);
            this.secsPassed.TabIndex = 6;
            this.secsPassed.Text = "00:00 | 00:00";
            // 
            // nextSongButton
            // 
            this.nextSongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextSongButton.BackgroundImage = global::music_playlist.Properties.Resources.New_Piskel_5_png;
            this.nextSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.nextSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextSongButton.Location = new System.Drawing.Point(612, 27);
            this.nextSongButton.Name = "nextSongButton";
            this.nextSongButton.Size = new System.Drawing.Size(36, 36);
            this.nextSongButton.TabIndex = 4;
            this.nextSongButton.TabStop = false;
            this.nextSongButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nextSongButton_MouseDown);
            this.nextSongButton.MouseEnter += new System.EventHandler(this.nextSongButton_MouseEnter);
            this.nextSongButton.MouseLeave += new System.EventHandler(this.nextSongButton_MouseLeave);
            // 
            // prevSongButton
            // 
            this.prevSongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.prevSongButton.BackgroundImage = global::music_playlist.Properties.Resources.New_Piskel_7_png;
            this.prevSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.prevSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevSongButton.Location = new System.Drawing.Point(511, 27);
            this.prevSongButton.Name = "prevSongButton";
            this.prevSongButton.Size = new System.Drawing.Size(36, 36);
            this.prevSongButton.TabIndex = 5;
            this.prevSongButton.TabStop = false;
            this.prevSongButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prevSongButton_MouseDown);
            this.prevSongButton.MouseEnter += new System.EventHandler(this.prevSongButton_MouseEnter);
            this.prevSongButton.MouseLeave += new System.EventHandler(this.prevSongButton_MouseLeave);
            // 
            // playSongButton
            // 
            this.playSongButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playSongButton.BackgroundImage = global::music_playlist.Properties.Resources.New_Piskel_1_png;
            this.playSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playSongButton.Location = new System.Drawing.Point(553, 27);
            this.playSongButton.Name = "playSongButton";
            this.playSongButton.Size = new System.Drawing.Size(53, 36);
            this.playSongButton.TabIndex = 3;
            this.playSongButton.TabStop = false;
            this.playSongButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playSongButton_MouseDown);
            this.playSongButton.MouseEnter += new System.EventHandler(this.playSongButton_MouseEnter);
            this.playSongButton.MouseLeave += new System.EventHandler(this.playSongButton_MouseLeave);
            // 
            // playbar
            // 
            this.playbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.playbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.playbar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playbar.Location = new System.Drawing.Point(0, 3);
            this.playbar.Name = "playbar";
            this.playbar.Size = new System.Drawing.Size(1158, 5);
            this.playbar.TabIndex = 3;
            this.playbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playbar_MouseDown);
            // 
            // likeSongButton
            // 
            this.likeSongButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.likeSongButton.BackgroundImage = global::music_playlist.Properties.Resources.heart;
            this.likeSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.likeSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.likeSongButton.Location = new System.Drawing.Point(1039, 46);
            this.likeSongButton.Name = "likeSongButton";
            this.likeSongButton.Size = new System.Drawing.Size(34, 23);
            this.likeSongButton.TabIndex = 3;
            this.likeSongButton.TabStop = false;
            this.likeSongButton.Click += new System.EventHandler(this.likeSongButton_Click);
            this.likeSongButton.MouseEnter += new System.EventHandler(this.likeSongButton_MouseEnter);
            this.likeSongButton.MouseLeave += new System.EventHandler(this.likeSongButton_MouseLeave);
            // 
            // currentSongCover
            // 
            this.currentSongCover.BackColor = System.Drawing.Color.Transparent;
            this.currentSongCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.currentSongCover.Location = new System.Drawing.Point(3, 11);
            this.currentSongCover.Name = "currentSongCover";
            this.currentSongCover.Size = new System.Drawing.Size(98, 92);
            this.currentSongCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.currentSongCover.TabIndex = 8;
            this.currentSongCover.TabStop = false;
            this.currentSongCover.MouseDown += new System.Windows.Forms.MouseEventHandler(this.currentSongCover_MouseDown);
            // 
            // randomSongButton
            // 
            this.randomSongButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.randomSongButton.BackgroundImage = global::music_playlist.Properties.Resources.random;
            this.randomSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.randomSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.randomSongButton.Location = new System.Drawing.Point(1079, 46);
            this.randomSongButton.Name = "randomSongButton";
            this.randomSongButton.Size = new System.Drawing.Size(34, 23);
            this.randomSongButton.TabIndex = 4;
            this.randomSongButton.TabStop = false;
            this.randomSongButton.Click += new System.EventHandler(this.randomSongButton_Click);
            this.randomSongButton.MouseEnter += new System.EventHandler(this.randomSongButton_MouseEnter);
            this.randomSongButton.MouseLeave += new System.EventHandler(this.randomSongButton_MouseLeave);
            // 
            // repeatSongButton
            // 
            this.repeatSongButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.repeatSongButton.BackgroundImage = global::music_playlist.Properties.Resources.repeat;
            this.repeatSongButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.repeatSongButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.repeatSongButton.Location = new System.Drawing.Point(1112, 46);
            this.repeatSongButton.Name = "repeatSongButton";
            this.repeatSongButton.Size = new System.Drawing.Size(34, 23);
            this.repeatSongButton.TabIndex = 4;
            this.repeatSongButton.TabStop = false;
            this.repeatSongButton.Click += new System.EventHandler(this.repeatSongButton_Click);
            this.repeatSongButton.MouseEnter += new System.EventHandler(this.repeatSongButton_MouseEnter);
            this.repeatSongButton.MouseLeave += new System.EventHandler(this.repeatSongButton_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.flowLayoutPanel1.Controls.Add(this.songPanel0);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, -1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1155, 536);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // songPanel0
            // 
            this.songPanel0.BackColor = System.Drawing.Color.Transparent;
            this.songPanel0.Controls.Add(this.artist0);
            this.songPanel0.Controls.Add(this.title0);
            this.songPanel0.Controls.Add(this.cover0);
            this.songPanel0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.songPanel0.Location = new System.Drawing.Point(3, 3);
            this.songPanel0.Name = "songPanel0";
            this.songPanel0.Size = new System.Drawing.Size(430, 126);
            this.songPanel0.TabIndex = 0;
            // 
            // artist0
            // 
            this.artist0.AutoSize = true;
            this.artist0.Enabled = false;
            this.artist0.Font = new System.Drawing.Font("Ebrima", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.artist0.Location = new System.Drawing.Point(141, 65);
            this.artist0.Name = "artist0";
            this.artist0.Size = new System.Drawing.Size(61, 21);
            this.artist0.TabIndex = 2;
            this.artist0.Text = "[artist]";
            // 
            // title0
            // 
            this.title0.AutoSize = true;
            this.title0.Enabled = false;
            this.title0.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title0.Location = new System.Drawing.Point(140, 35);
            this.title0.Name = "title0";
            this.title0.Size = new System.Drawing.Size(111, 30);
            this.title0.TabIndex = 1;
            this.title0.Text = "[song title]";
            // 
            // cover0
            // 
            this.cover0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cover0.Enabled = false;
            this.cover0.Location = new System.Drawing.Point(0, 0);
            this.cover0.Name = "cover0";
            this.cover0.Size = new System.Drawing.Size(126, 126);
            this.cover0.TabIndex = 0;
            this.cover0.TabStop = false;
            // 
            // Zoubify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.ClientSize = new System.Drawing.Size(1158, 643);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.bottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.MinimumSize = new System.Drawing.Size(977, 144);
            this.Name = "Zoubify";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoubify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Zoubify_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.form1_Resize);
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.likeSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentSongCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomSongButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatSongButton)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.songPanel0.ResumeLayout(false);
            this.songPanel0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cover0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.PictureBox playSongButton;
        private System.Windows.Forms.Panel playbar;
        private System.Windows.Forms.PictureBox prevSongButton;
        private System.Windows.Forms.PictureBox nextSongButton;
        private System.Windows.Forms.Label secsPassed;
        private System.Windows.Forms.PictureBox currentSongCover;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox randomSongButton;
        private System.Windows.Forms.PictureBox repeatSongButton;
        private System.Windows.Forms.PictureBox likeSongButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label songNamePlaybar;
        private System.Windows.Forms.Label artistNamePlaybar;
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private System.Windows.Forms.Panel songPanel0;
        private System.Windows.Forms.PictureBox cover0;
        private System.Windows.Forms.Label title0;
        private System.Windows.Forms.Label artist0;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}

