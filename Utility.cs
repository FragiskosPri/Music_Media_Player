using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace music_playlist
{
    internal class Utility
    {


        //---------------------------------------------Database---------------------------------------------//
        private string connString = "Data Source=Database.db;Version=3;";

        public void InitializeDbTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                string createTableSQL = "CREATE TABLE IF NOT EXISTS Songs(" +
                    "songName TEXT PRIMARY KEY," +
                    "imageLocation TEXT," +
                    "artist TEXT," +
                    "liked BOOLEAN," +
                    "releaseDate int," +
                    "timePlayed TEXT" +
                    ")";

                using (SQLiteCommand command = new SQLiteCommand(createTableSQL, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool songExistsInDatabase(string songName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                try
                {
                    connection.Open();
                    string selectSQL = "SELECT COUNT(*) FROM Songs WHERE songName = @songName";

                    using (SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@songName", songName);
                        int count = Convert.ToInt32(selectCommand.ExecuteScalar());

                        return count > 0;
                    }
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show($"Error checking if song exists in the database!\n\n{e.Message}");
                    return false;
                }
            }
        }

        public Song addSongToDatabase(Song song)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                try
                {
                    connection.Open();
                    if (!songExistsInDatabase(song.title))
                    {   // Add a new Song to the database

                        string insertSQL = "INSERT INTO Songs (songName, imageLocation, artist, liked, releaseDate, timePlayed)" +
                                                "VALUES (@songName, @imageLocation, @artist, @liked, @releaseDate, @timePlayed)";

                        using (SQLiteCommand command = new SQLiteCommand(insertSQL, connection))
                        {
                            command.Parameters.AddWithValue("@songName", song.title);
                            command.Parameters.AddWithValue("@imageLocation", song.cover);
                            command.Parameters.AddWithValue("@artist", song.artist);
                            command.Parameters.AddWithValue("@liked", false);
                            command.Parameters.AddWithValue("@releaseDate", song.releaseDate);
                            command.Parameters.AddWithValue("@timePlayed", song.timePlayed);

                            int rowsInserted = command.ExecuteNonQuery();
                            if (rowsInserted > 0)
                                Console.WriteLine("Successfully added game to Database!");
                            else
                                Console.WriteLine("No rows were inserted!");
                        }

                    }
                    else
                    {
                        // Get the info from the already existing one
                        string selectSQL = "SELECT * FROM Songs WHERE songName = @songName";

                        using (SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@songName", song.title);

                            using (SQLiteDataReader reader = selectCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Access data here
                                    string title = reader.IsDBNull(reader.GetOrdinal("songName")) ? null : reader.GetString(reader.GetOrdinal("songName"));
                                    string cover = reader.IsDBNull(reader.GetOrdinal("imageLocation")) ? null : reader.GetString(reader.GetOrdinal("imageLocation"));
                                    string artist = reader.IsDBNull(reader.GetOrdinal("artist")) ? null : reader.GetString(reader.GetOrdinal("artist"));
                                    bool liked = Convert.ToBoolean(reader["liked"]);
                                    int releaseDate = Convert.ToInt32(reader["releaseDate"]);
                                    int timePlayed = Convert.ToInt32(reader["timePlayed"]);

                                    // Update the song properties
                                    song.title = title;
                                    song.cover = cover;
                                    song.artist = artist;
                                    song.liked = liked;
                                    song.releaseDate = releaseDate;
                                    song.timePlayed = timePlayed;
                                }
                            }
                        }

                        // Return the updated song
                        return song;
                    }

                }
                catch (SQLiteException e)
                {
                    MessageBox.Show($"Error adding song to the database!\n\n{e.Message}");
                }
            }
            return song;
        }

        public void updateSongOnDatabase(Song song)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                try
                {
                    connection.Open();
                    if (!songExistsInDatabase(song.title)) return;

                    // Song already exists, replace its values
                    string replaceSQL = "REPLACE INTO Songs (songName, imageLocation, artist, liked, releaseDate, timePlayed) " +
                                        "VALUES (@songName, @imageLocation, @artist, @liked, @releaseDate, @timePlayed)";

                    using (SQLiteCommand replaceCommand = new SQLiteCommand(replaceSQL, connection))
                    {
                        replaceCommand.Parameters.AddWithValue("@songName", song.title);
                        replaceCommand.Parameters.AddWithValue("@imageLocation", song.cover);
                        replaceCommand.Parameters.AddWithValue("@artist", song.artist);
                        replaceCommand.Parameters.AddWithValue("@liked", song.liked);
                        replaceCommand.Parameters.AddWithValue("@releaseDate", song.releaseDate);
                        replaceCommand.Parameters.AddWithValue("@timePlayed", song.timePlayed);

                        replaceCommand.ExecuteNonQuery();
                    }
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show($"Error replacing song in the database!\n\n{e.Message}");
                }
            }
        }

        public void DeleteSong(string songName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                try
                {
                    connection.Open();

                    if (songExistsInDatabase(songName))
                    {
                        // Song exists, delete it
                        string deleteSQL = "DELETE FROM Songs WHERE songName = @songName";

                        using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteSQL, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@songName", songName);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }

                }
                catch (SQLiteException e)
                {
                    MessageBox.Show($"Error deleting song from the database!\n\n{e.Message}");
                }
            }
        }

        //---------------------------------------------String tools---------------------------------------------//
        public static string prepareFileString(string str)
        {
            // removes .mp3
            str = str.Substring(0, str.Length - 4);

            // if name contains ft. , every letter to right of it will be removed
            if (str.Contains("ft."))
            {
                str = str.Substring(0, str.IndexOf("ft."));
            }

            // removes all parentheses and the letters between them
            str = Regex.Replace(str, @"\([^\)]*\)", "()");

            // removes all symbols except - and space
            str = new string(str.Where(c => char.IsLetterOrDigit(c) || c == '-' || c == ' ').ToArray());

            return str;
        }

        public static string getArtist(string str)
        {
            string artist = "";

            if (str.Contains('-'))
            {
                artist = str.Substring(0, str.IndexOf('-'));
            }

            return artist;
        }

        public static string getTitle(string str)
        {
            string title = str;

            if (str.Contains('-'))
            {
                title = str.Substring(str.IndexOf('-') + 1);
            }

            return title;
        }

        public static string renameFile(string curPath, string newArtistName , string newTitle )
        {
            try
            {
                if (File.Exists(curPath))
                {
                    string newName = newArtistName + "-" + newTitle + ".mp3";
                    string newPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)}/{newName}";

                    File.Move(curPath, newPath);
                    curPath = newPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not rename file!\n\n" + ex);
            }
            return curPath;
        }
    }


    internal class Song
    {
        public string title { get; set; }
        public string artist { get; set; }
        public int duration { get; set; }
        public string filePath { get; set; }
        public string cover { get; set; }
        public bool liked { get; set; }
        public int timePlayed { get; set; }
        public int releaseDate { get; set; }

        public Song(string title, string artist, int duration, string mp3title)
        {
            this.title = title;
            this.artist = artist;
            this.duration = duration;


            string initialFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\";

            //if mp3 title doesn't end with ".mp3" , add ".mp3"
            filePath = initialFolder + mp3title + (mp3title.EndsWith(".mp3") ? "" : ".mp3");


        }

        public void updateToDatabase()
        {
            Utility utility = new Utility();
            utility.updateSongOnDatabase(this);
        }
    }


}
