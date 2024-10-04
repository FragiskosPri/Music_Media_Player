// Ignore Spelling: Zoubify

using music_playlist.Properties;
//package for playing audio files
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace music_playlist
{
    public partial class Zoubify : Form
    {
        public Zoubify()
        {
            InitializeComponent();
            waveOut = new WaveOutEvent();
        }

        Utility utility = new Utility();

        private Button selectedBtn;
        private Color defaultCol, hoverCol, clickCol;
        Graphics g;
        Point pbLoc;
        int pbHeight, pbWidth;

        Color pbColBack, pbColFront;
        Brush brushBack, brushFront;

        int currentSongIndex = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            //--- Initialize database
            utility.InitializeDbTable();

            //--- Play button colors
            pbColBack = playbar.BackColor;
            pbColFront = Color.FromArgb(190, 190, 190);
            brushBack = new SolidBrush(pbColBack);
            brushFront = new SolidBrush(pbColFront);

            g = playbar.CreateGraphics();

            // Play-bar initialization
            hoverCol = Color.FromArgb(255, 110, 110, 110);
            clickCol = Color.FromArgb(255, 60, 60, 60);

            pbLoc = playbar.ClientRectangle.Location;
            pbHeight = playbar.Height;
            pbWidth = playbar.Width;

            panDefaultCol = Color.Transparent;
            panHoverCol = Color.FromArgb(137, 137, 160);
            panClickCol = Color.FromArgb(147, 147, 230);

            initializeSongList();

            if (songList.Count > 0)
            {
                updateSongPanels();
                initializeSong();
            }
            else
            {
                playSongButton.Enabled = false;
                prevSongButton.Enabled = false;
                nextSongButton.Enabled = false;
                MessageBox.Show("No songs found in music folder.\nAdd .mp3 music files to the music folder and restart the app.");
            }

            WindowState = FormWindowState.Maximized;
        }

        List<Song> songList = new List<Song>();
        private void initializeSongList()
        { // This goes inside the music folder from your files and gets all the music files

            string musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            string[] musicFiles = Directory.GetFiles(musicFolder);

            foreach (string file in musicFiles)
            {
                string filePath = Path.GetFileName(file);

                if (!filePath.EndsWith(".mp3")) continue;

                var fileMetadata = TagLib.File.Create(musicFolder + '/' + filePath);

                int duration = (int)fileMetadata.Properties.Duration.TotalSeconds;

                string fileName = Utility.prepareFileString(filePath);

                Song songInst = new Song(Utility.getTitle(fileName), Utility.getArtist(fileName), duration, filePath);
                songList.Add(utility.addSongToDatabase(songInst));
            }

            songList.Sort((song1, song2) => song2.timePlayed.CompareTo(song1.timePlayed));
        }

        //---------------------------------------------Panel Settings---------------------------------------------//
        Color panHoverCol, panDefaultCol, panClickCol;
        private void updateSongPanels()
        {
            for (int i = 0; i < songList.Count; i++)
            {
                //-- Search filters
                bool contains = songList[i].title.ToUpper().Contains(searchPrompt.ToUpper());
                bool containsArtist = songList[i].artist.ToUpper().Contains(searchPrompt.ToUpper());
                if (!contains && !containsArtist && searchPrompt != string.Empty) continue;

                //-- Load a song to the panel
                Panel panel = new Panel();
                panel.BackColor = panDefaultCol;
                panel.Name = "songPanel" + (i);
                panel.Size = songPanel0.Size;
                panel.Cursor = Cursors.Hand;

                //tag stores index of each corresponding panel in songList
                panel.Tag = i;

                //event initialization
                panel.MouseEnter += panelMouseEnter;
                panel.MouseLeave += panelMouseLeave;
                panel.MouseDown += panelMouseDown;

                flowLayoutPanel1.Controls.Add(panel);

                Song cs = songList[i];

                //shows the cover of the song
                PictureBox cover = new PictureBox();
                cover.Enabled = false;
                cover.BackColor = Color.Black;
                cover.SizeMode = PictureBoxSizeMode.Zoom;

                try
                {
                    cover.LoadAsync(cs.cover);
                }
                catch { }

                cover.Name = $"cover";
                cover.Size = new Size(panel.Height, panel.Height);
                panel.Controls.Add(cover);

                //shows the title of the song
                Label title = new Label();
                title.Enabled = false;
                title.Text = cs.title;
                title.Name = $"tLabel"; // Title label
                title.Font = title0.Font;
                title.ForeColor = title0.ForeColor;
                title.Location = title0.Location;
                title.Size = new Size(300, 30);
                panel.Controls.Add(title);

                // Shows the artist name
                Label artist = new Label();
                artist.Enabled = false;
                artist.Text = cs.artist;
                artist.Name = "aLabel"; // Artist Label
                artist.Font = artist0.Font;
                artist.ForeColor = artist0.ForeColor;
                artist.Location = artist0.Location;
                artist.Size = new Size(300, 30);
                panel.Controls.Add(artist);

                // Garbage bin button
                PictureBox gb = new PictureBox();
                gb.Size = new Size(34, 23);
                gb.Location = new Point(panel.Width - gb.Width - 3, panel.Height - gb.Height - 3);
                gb.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                gb.BackgroundImage = Resources.bin;
                gb.BackgroundImageLayout = ImageLayout.Zoom;
                gb.BringToFront();
                gb.Name = "deleteSong";
                gb.Tag = i;
                gb.MouseEnter += garbageMouseEnter;
                gb.MouseLeave += garbageMouseLeave;
                gb.MouseClick += garbageButton_Click;
                panel.Controls.Add(gb);

                // Edit song button
                PictureBox es = new PictureBox();
                es.Size = new Size(34, 23);
                es.Location = new Point(panel.Width - gb.Width - es.Width - 3, panel.Height - gb.Height - 3);
                es.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                es.BackgroundImage = Resources.editSong;
                es.BackgroundImageLayout = ImageLayout.Zoom;
                es.BringToFront();
                es.Name = "editSong";
                es.Tag = i;
                es.MouseEnter += editMouseEnter;
                es.MouseLeave += editMouseLeave;
                es.MouseClick += editButton_Click;

                panel.Controls.Add(es);
            }

            songPanel0.Dispose();
        }

        private void panelMouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (currentSongIndex == (int)panel.Tag) return;

            panel.BackColor = panHoverCol;
        }

        private void panelMouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (currentSongIndex == (int)panel.Tag) return;

            panel.BackColor = panDefaultCol;
        }

        private void panelMouseDown(object sender, EventArgs e)
        {

            Panel panel = sender as Panel;

            songIsPlaying = true;
            setPlayBtnVisual();

            resetSong();
            currentSongIndex = (int)panel.Tag;

            initializeSong();
            timer1.Enabled = true;

        }

        //---------------------------------------------Player-Bar---------------------------------------------//
        private void playbar_MouseDown(object sender, MouseEventArgs e)
        {
            int totalTicks = (songDuration * 1000) / timer1.Interval;
            int tickWidth = pbWidth / totalTicks;
            if (tickWidth == 0) tickWidth = 1;

            // Calculate the adjusted mouse position based on the tick width
            int adjustedMousePosX = (int)Math.Round((double)e.X / tickWidth) * tickWidth;

            // Ensure that adjustedMousePosX is within valid bounds
            adjustedMousePosX = Math.Max(0, Math.Min(pbWidth, adjustedMousePosX));

            // Use adjustedMousePosX for drawing the playbar
            g.FillRectangle(brushBack, playbar.ClientRectangle);
            g.FillRectangle(brushFront, pbLoc.X, pbLoc.Y, adjustedMousePosX, pbHeight);

            // Calculate the tick based on the adjusted mouse position
            double newWidthRatio = (double)adjustedMousePosX / pbWidth;
            tick = (int)(totalTicks * newWidthRatio);

            updateDurationLeft(songDuration, (int)(songDuration * newWidthRatio));

            audioFile.CurrentTime = TimeSpan.FromSeconds(songDuration * newWidthRatio);
        }

        private void drawFrontPlaybar()
        {
            barWidth = (int)((float)msElapsed / (songDuration * 1000) * pbWidth);

            Rectangle rect = new Rectangle(pbLoc.X, pbLoc.Y, barWidth, pbHeight);

            g.FillRectangle(brushBack, playbar.ClientRectangle);
            g.FillRectangle(brushFront, rect);
        }

        bool songIsPlaying;

        private void setPlayBtnVisual()
        {
            if (!songIsPlaying && !isHoveringPlayBtn) playSongButton.BackgroundImage = Resources.New_Piskel_1_png;
            else if (!songIsPlaying && isHoveringPlayBtn) playSongButton.BackgroundImage = Resources.New_Piskel_2_png;
            else if (songIsPlaying && !isHoveringPlayBtn) playSongButton.BackgroundImage = Resources.New_Piskel_3_png;
            else if (songIsPlaying && isHoveringPlayBtn) playSongButton.BackgroundImage = Resources.New_Piskel_4_png;
        }
        bool isHoveringPlayBtn;
        //--- Resume
        private void pressArrowPlayButton(string direction)
        {
            songIsPlaying = true;
            setPlayBtnVisual();

            resetSong();
            getNextSongIndex(direction);
            initializeSong();
            timer1.Enabled = true;
        }

        private void playSongButton_MouseDown(object sender, MouseEventArgs e)
        {
            songIsPlaying = !songIsPlaying;

            if (songIsPlaying)
            {
                timer1.Enabled = true;
            }
            else
            {
                pauseSong();
            }

            setPlayBtnVisual();
        }

        private void playSongButton_MouseEnter(object sender, EventArgs e)
        {
            isHoveringPlayBtn = true;
            setPlayBtnVisual();
        }

        private void playSongButton_MouseLeave(object sender, EventArgs e)
        {
            isHoveringPlayBtn = false;
            setPlayBtnVisual();
        }

        //--- Next song
        private void nextSongButton_MouseEnter(object sender, EventArgs e)
        {
            nextSongButton.BackgroundImage = Resources.New_Piskel_6_png;
        }

        private void nextSongButton_MouseDown(object sender, MouseEventArgs e)
        {
            pressArrowPlayButton("next");
        }

        private void nextSongButton_MouseLeave(object sender, EventArgs e)
        {
            nextSongButton.BackgroundImage = Resources.New_Piskel_5_png;
        }

        //--- Previous song
        private void prevSongButton_MouseDown(object sender, MouseEventArgs e)
        {
            pressArrowPlayButton("prev");
        }

        private void prevSongButton_MouseEnter(object sender, EventArgs e)
        {
            prevSongButton.BackgroundImage = Resources.New_Piskel_8_png;
        }

        private void prevSongButton_MouseLeave(object sender, EventArgs e)
        {
            prevSongButton.BackgroundImage = Resources.New_Piskel_7_png;
        }

        //--- Pause Song
        private void pauseSong()
        {
            waveOut.Pause();

            timer1.Enabled = false;
        }

        ///////////////////////

        int minPanWidth = 370;
        int maxPanWidth = 570;
        private void form1_Resize(object sender, EventArgs e)
        {
            g = playbar.CreateGraphics();
            pbWidth = playbar.Width;

            if (secondsElapsed == songDuration) g.FillRectangle(brushFront, playbar.ClientRectangle);

            drawFrontPlaybar();

            //////////////////////////////////////////

            // Resize song panels
            Size size = flowLayoutPanel1.Size;

            int columns;
            int rows;

            columns = size.Width / 600;
            rows = size.Height / 150;

            if (columns == 0) columns = 1;
            if (rows == 0) rows = 1;

            Size panelSize = new Size(size.Width / columns - 25, size.Height / rows - 25);

            // Set the size for each panel
            foreach (Control panel in flowLayoutPanel1.Controls)
                panel.Size = panelSize;
        }

        ///////////////////////

        int tick, msElapsed;
        int secondsElapsed, minutes, seconds;

        private void artistNamePlaybar_MouseEnter(object sender, EventArgs e)
        {
            artistNamePlaybar.ForeColor = Color.FromArgb(220, 220, 220);
        }

        private void artistNamePlaybar_MouseLeave(object sender, EventArgs e)
        {
            artistNamePlaybar.ForeColor = Color.White;
        }

        private void songNamePlaybar_MouseLeave(object sender, EventArgs e)
        {
            songNamePlaybar.ForeColor = Color.White;
        }

        int normalHeight;
        private void currentSongCover_MouseDown(object sender, MouseEventArgs e)
        {
            // playbar only mode
            if (Size.Height != MinimumSize.Height)
            {
                normalHeight = Size.Height;

                Location = new Point(Location.X, Location.Y + (normalHeight - MinimumSize.Height));
                Size = new Size(Size.Width, MinimumSize.Height);
            }
            else
            {
                Location = new Point(Location.X, Location.Y - (normalHeight - MinimumSize.Height));
                Size = new Size(Size.Width, normalHeight);
            }
        }


        //---------------------------------------------Buttons---------------------------------------------//
        //-- Like song
        private void likeSongButton_Click(object sender, EventArgs e)
        {

            songList[currentSongIndex].liked = !songList[currentSongIndex].liked;
            songList[currentSongIndex].updateToDatabase();
            likeSongButton.BackgroundImage = songList[currentSongIndex].liked ? Resources.heartActive : Resources.heart_hovered;
        }

        private void likeSongButton_MouseEnter(object sender, EventArgs e)
        {
            bool isLiked = songList[currentSongIndex].liked;
            if (!isLiked)
                likeSongButton.BackgroundImage = Resources.heart_hovered;
        }

        private void likeSongButton_MouseLeave(object sender, EventArgs e)
        {
            bool isLiked = songList[currentSongIndex].liked;
            if (!isLiked)
                likeSongButton.BackgroundImage = Resources.heart;
        }

        //--- Repeat gong
        bool repeatSong;
        private void repeatSongButton_Click(object sender, EventArgs e)
        {
            repeatSong = !repeatSong;
            repeatSongButton.BackgroundImage = repeatSong ? Resources.repeat_active : Resources.repeat_hovered;

            if (randomizeSong)
            {
                randomizeSong = false;
                randomSongButton.BackgroundImage = Resources.random;
            }
        }

        private void repeatSongButton_MouseEnter(object sender, EventArgs e)
        {
            if (repeatSong) return;
            repeatSongButton.BackgroundImage = Resources.repeat_hovered;
        }

        private void repeatSongButton_MouseLeave(object sender, EventArgs e)
        {
            if (repeatSong) return;
            repeatSongButton.BackgroundImage = Resources.repeat;
        }

        //--- Random Song
        bool randomizeSong;
        private void randomSongButton_Click(object sender, EventArgs e)
        {
            randomizeSong = !randomizeSong;
            randomSongButton.BackgroundImage = randomizeSong ? Resources.random_active : Resources.random_hovered;

            if (repeatSong)
            {
                repeatSong = false;
                repeatSongButton.BackgroundImage = Resources.repeat;
            }
        }

        private void randomSongButton_MouseEnter(object sender, EventArgs e)
        {
            if (randomizeSong) return;
            randomSongButton.BackgroundImage = Resources.random_hovered;
        }

        private void randomSongButton_MouseLeave(object sender, EventArgs e)
        {
            if (randomizeSong) return;
            randomSongButton.BackgroundImage = Resources.random;
        }

        //--- Delete button
        private void garbageButton_Click(object sender, EventArgs e)
        {
            // Get the song we want to delete
            PictureBox gb = sender as PictureBox;
            int index = (int)gb.Tag;

            // Delete from database and file
            utility.DeleteSong(songList[index].title);
            File.Delete(songList[index].filePath);

            // Update visuals
            songList.RemoveAt(index);
            flowLayoutPanel1.Controls.Clear();
            updateSongPanels();
            getNextSongIndex("next");
        }

        private void garbageMouseEnter(object sender, EventArgs e)
        {
            PictureBox gb = sender as PictureBox;
            gb.BackgroundImage = (gb.Name == "xButton") ? Resources.xButton_hovered : Resources.bin_hovered;
        }

        private void garbageMouseLeave(object sender, EventArgs e)
        {
            PictureBox gb = sender as PictureBox;
            gb.BackgroundImage = (gb.Name == "xButton") ? Resources.xButton : Resources.bin;
        }

        //---Edit button

        private void editMouseEnter(object sender, EventArgs e)
        {
            PictureBox ed = sender as PictureBox;
            ed.BackgroundImage = Resources.editSong_hovered;
        }

        private void editMouseLeave(object sender, EventArgs e)
        {
            PictureBox ed = sender as PictureBox;
            ed.BackgroundImage = Resources.editSong;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            PictureBox edButton = sender as PictureBox;

            // Find the parent of the edit button click
            int index = (int)edButton.Tag;
            Panel parentPanel = flowLayoutPanel1.Controls[index] as Panel;

            foreach (Control control in parentPanel.Controls)
            {
                if (control.Name == "tLabel")
                {   // Title label
                    control.Hide();
                    TextBox textBox = new TextBox();
                    textBox.Size = control.Size;
                    textBox.Name = "titleTextbox";
                    textBox.Location = control.Location;
                    textBox.Text = songList[index].title;
                    parentPanel.Controls.Add(textBox);
                }
                else if (control.Name == "aLabel")
                {   // Artist label
                    control.Hide();
                    TextBox textBox = new TextBox();
                    textBox.Size = control.Size;
                    textBox.Name = "artistTextbox";
                    textBox.Location = control.Location;
                    textBox.Text = songList[index].artist;
                    parentPanel.Controls.Add(textBox);
                }
                else if (control.Name == "cover")
                {   // Cover
                    control.Hide();
                    RichTextBox richTextBox = new RichTextBox();
                    richTextBox.Size = control.Size;
                    richTextBox.Name = "coverTextbox";
                    richTextBox.Location = control.Location;
                    richTextBox.Text = songList[index].cover;
                    parentPanel.Controls.Add(richTextBox);
                }
                else if (control.Name == "editSong")
                {   // Edit button
                    control.Name = "checkButton";
                    control.BackgroundImage = Resources.checkButton_hovered;

                    control.MouseEnter -= editMouseEnter;
                    control.MouseLeave -= editMouseLeave;
                    control.MouseClick -= editButton_Click;

                    control.MouseEnter += checkButton_MouseEnter;
                    control.MouseLeave += checkButton_MouseLeave;
                    control.MouseClick += checkButton_click;
                }
                else if (control.Name == "deleteSong")
                {   // Garbage button
                    control.Name = "xButton";
                    control.BackgroundImage = Resources.xButton;

                    control.MouseEnter -= garbageMouseEnter;
                    control.MouseLeave -= garbageMouseLeave;
                    control.MouseClick -= garbageButton_Click;

                    control.MouseEnter += xButton_MouseEnter;
                    control.MouseLeave += xButton_MouseLeave;
                    control.MouseClick += xButton_Click;
                }
            }


        }

        private void checkButton_click(object sender, EventArgs e)
        {

            PictureBox checkButton = sender as PictureBox;
            int index = (int)checkButton.Tag;
            Panel parentPanel = flowLayoutPanel1.Controls[index] as Panel;

            utility.DeleteSong(songList[index].title);

            foreach (Control control in parentPanel.Controls)
            {
                // Get info from the edit and update to database
                if (control.Name == "artistTextbox")
                {
                    songList[index].artist = control.Text;
                    if (currentSongIndex == index) artistNamePlaybar.Text = control.Text;
                }
                if (control.Name == "aLabel")
                {
                    control.Show();
                }
                if (control.Name == "titleTextbox")
                {
                    songList[index].title = control.Text;
                    if (currentSongIndex == index) songNamePlaybar.Text = control.Text;
                }
                if (control.Name == "tLabel")
                {
                    control.Show();
                }
                if (control.Name == "coverTextbox")
                {
                    songList[index].cover = control.Text;
                    if (currentSongIndex == index)
                    {
                        try
                        {
                            currentSongCover.LoadAsync(control.Text);
                        }
                        catch { }
                    }
                }
                if (control.Name == "cover")
                {
                    control.Show();
                }

                //---Change back to previous buttons
                if (control.Name == "checkButton")
                {
                    control.Name = "editSong";
                    control.BackgroundImage = Resources.editSong_hovered;

                    // Remove the check button functions
                    control.MouseEnter -= checkButton_MouseEnter;
                    control.MouseLeave -= checkButton_MouseLeave;
                    control.MouseClick -= checkButton_click;

                    // Add the edit functionality back
                    control.MouseEnter += editMouseEnter;
                    control.MouseLeave += editMouseLeave;
                    control.MouseClick += editButton_Click;
                }
                if (control.Name == "xButton")
                {
                    control.Name = "deleteSong";
                    control.BackgroundImage = Resources.bin;

                    // Remove the x button functions
                    control.MouseEnter -= xButton_MouseEnter;
                    control.MouseLeave -= xButton_MouseLeave;
                    control.MouseClick -= xButton_Click;

                    // Add the garbage functionality back
                    control.MouseEnter += garbageMouseEnter;
                    control.MouseLeave += garbageMouseLeave;
                    control.MouseClick += garbageButton_Click;
                }
            }

            foreach (Control control in parentPanel.Controls)
            {
                if (control.Name == "artistTextbox")
                {
                    control.Dispose();
                }
                if (control.Name == "titleTextbox")
                {
                    control.Dispose();
                }
                if (control.Name == "coverTextbox")
                {
                    control.Dispose();
                }
            }

            flowLayoutPanel1.Controls.Clear();
            updateSongPanels();

            songList[index].filePath = Utility.renameFile(songList[index].filePath, songList[index].artist, songList[index].title);

            utility.addSongToDatabase(songList[index]);
        }

        private void checkButton_MouseEnter(object sender, EventArgs e)
        {
            PictureBox cb = sender as PictureBox;
            cb.BackgroundImage = Resources.checkButton_hovered;
        }

        private void checkButton_MouseLeave(object sender, EventArgs e)
        {
            PictureBox cb = sender as PictureBox;
            cb.BackgroundImage = Resources.checkButton;
        }

        private void xButton_Click(object sender, EventArgs e)
        {
            PictureBox xButton = sender as PictureBox;

            // Find the parent of the edit button click
            int index = (int)xButton.Tag;
            Panel parentPanel = flowLayoutPanel1.Controls[index] as Panel;

            foreach (Control control in parentPanel.Controls)
            {
                // dispose of textboxes and change check and x buttons to edit and delete
                if (control is TextBox || control is RichTextBox)
                {
                    control.Dispose();
                }
                else if (control.Name == "checkButton")
                {
                    control.Name = "editSong";
                    control.BackgroundImage = Resources.editSong;

                    control.MouseEnter -= checkButton_MouseEnter;
                    control.MouseLeave -= checkButton_MouseLeave;
                    control.MouseClick -= checkButton_click;

                    control.MouseEnter += editMouseEnter;
                    control.MouseLeave += editMouseLeave;
                    control.MouseClick += editButton_Click;
                }
                else if (control.Name == "xButton")
                {
                    control.Name = "deleteSong";
                    control.BackgroundImage = Resources.bin_hovered;

                    control.MouseEnter -= xButton_MouseEnter;
                    control.MouseLeave -= xButton_MouseLeave;
                    control.MouseClick -= xButton_Click;

                    control.MouseEnter += garbageMouseEnter;
                    control.MouseLeave += garbageMouseLeave;
                    control.MouseClick += garbageButton_Click;
                }

                // show previous labels and cover

                else if (control.Name == "tLabel" || control.Name == "aLabel" || control.Name == "cover")
                {
                    control.Show();
                }
            }
        }

        private void xButton_MouseEnter(object sender, EventArgs e)
        {
            PictureBox xb = sender as PictureBox;
            xb.BackgroundImage = Resources.xButton_hovered;
        }

        private void xButton_MouseLeave(object sender, EventArgs e)
        {
            PictureBox xb = sender as PictureBox;
            xb.BackgroundImage = Resources.xButton;
        }

        ////

        //---Other buttons
        private void searchButton_Click(object sender, EventArgs e)
        {
            searchPrompt = searchTextBox.Text;
            flowLayoutPanel1.Controls.Clear();
            updateSongPanels();
        }

        //---------------------------------------------Song initialization & tools---------------------------------------------//
        int songDuration; // in seconds
        int barWidth;
        int ticksListened;
        int secondsListened;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (waveOut.PlaybackState != PlaybackState.Playing) waveOut.Play();

            tick++;
            msElapsed = tick * timer1.Interval;
            secondsElapsed = msElapsed / 1000;

            ticksListened++;
            secondsListened = ticksListened * timer1.Interval / 1000;

            updateDurationLeft(songDuration, secondsElapsed);

            drawFrontPlaybar();

            // if song has ended
            if (secondsElapsed == songDuration)
            {
                resetSong();
                getNextSongIndex("next");
                initializeSong();
                timer1.Enabled = true;
            }
        }
        private void updateDurationLeft(int totalSeconds, int currentSeconds)
        {
            int totalMin = totalSeconds / 60;
            int totalSec = totalSeconds % 60;

            int currentMin = currentSeconds / 60;
            int currentSec = currentSeconds % 60;

            secsPassed.Text = $"{currentMin:D2}:{currentSec:D2}" + " | " + $"{totalMin:D2}:{totalSec:D2}";
        }

        string searchPrompt = string.Empty;

        private void Zoubify_FormClosing(object sender, FormClosingEventArgs e)
        {   // This just makes sure that the seconds listened are registered to the database before 
            songList[currentSongIndex].timePlayed += secondsListened;
            songList[currentSongIndex].updateToDatabase();
        }

        private void getNextSongIndex(string mode)
        {
            if (repeatSong) return;

            if (randomizeSong)
            {
                Random rand = new Random();
                while (true)
                {
                    int randInt = rand.Next(0, songList.Count);
                    if (randInt != currentSongIndex)
                    {
                        currentSongIndex = randInt;
                        return;
                    }
                }
            }

            if (mode == "next")
            {
                currentSongIndex++;
                if (currentSongIndex == songList.Count) currentSongIndex = 0;
            }
            else if (mode == "prev")
            {
                currentSongIndex--;
                if (currentSongIndex == -1) currentSongIndex = songList.Count - 1;
            }
        }

        Song currentSong;

        private void volumeSlider1_VolumeChanged(object sender, EventArgs e)
        {
            waveOut.Volume = volumeSlider1.Volume;
        }

        private void initializeSong()
        {   // This gets the song ready to play
            currentSong = songList[currentSongIndex];

            //-- Audio file 
            try
            {
                audioFile = new AudioFileReader(currentSong.filePath);
                waveOut.Init(audioFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to get the audio file!\n" + ex);
                return;
            }

            //-- Visuals

            try
            {
                (flowLayoutPanel1.Controls[currentSongIndex] as Panel).BackColor = panClickCol;

            songNamePlaybar.Text = currentSong.title;
            artistNamePlaybar.Text = currentSong.artist;
            songDuration = currentSong.duration;
            updateDurationLeft(songDuration, 0);

            likeSongButton.BackgroundImage = currentSong.liked ? Resources.heartActive : Resources.heart;

            
                currentSongCover.LoadAsync(currentSong.cover);
            }
            catch { }
        }

        private void resetSong()
        {
            songList[currentSongIndex].timePlayed += secondsListened;
            songList[currentSongIndex].updateToDatabase();

            waveOut.Dispose();
            audioFile.Dispose();

            tick = 0;
            ticksListened = 0;

            try
            {
                (flowLayoutPanel1.Controls[currentSongIndex] as Panel).BackColor = panDefaultCol;
            }
            catch { }

            updateDurationLeft(songDuration, 0);

            g.FillRectangle(brushBack, playbar.ClientRectangle);
        }

        private WaveOutEvent waveOut;
        private AudioFileReader audioFile;
    }
}