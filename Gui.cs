namespace OOPSpotiflixV2
{
    #region MAIN BODY section and start up Menu
    internal class Gui
    {
        Data data = new Data();
        private string path = @"c:\SpotiflixData.json";
        public Gui()
        {
            //data.MovieList.Add(new Movie() { WWW=@"https:\\netflix.com/rambo3.mp4", Title="Rambo III", Genre ="Action", ReleaseDate=new DateTime(1988,5,25), Length=new DateTime(1,1,1, 1, 42, 0)});
            while (true)
            {
                Menu();
            }
        }
        // MAIN MENU FOR WHOLE PROGRAM
        private void Menu()
        {
            Console.WriteLine("\nMENU\n1 for Movies\n2 for Music\n3 for music\n4 for Series");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:

                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    MusicMenu();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SeriesMenu();

                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:

                    break;
                default:
                    break;
            }
        }
        #endregion

        
        
        
        #region Movie section
        //MOVIE MENU
        private void MovieMenu()
        {
            Console.WriteLine("\nMOVIE MENU\n1 for list of movies\n2 for search movies\n3 for add new movie");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMovie();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMovie();
                    break;
                default:
                    break;
            }
        }


        // ADD MOVIE
        private void AddMovie()
        {
            Movie movie = new Movie();
            movie.Title = GetString("Title: ");
            movie.Length = GetLength();
            movie.Genre = GetString("Genre: ");
            movie.ReleaseDate = GetReleaseDate();
            movie.WWW = GetString("WWW: ");

            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.MovieList.Add(movie);
        }


        //SEARCH MOVIE
        private void SearchMovie()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Movie movie in data.MovieList)
            {
                if (search != null)
                {
                    if (movie.Title.Contains(search) || movie.Genre.Contains(search))
                        ShowMovie(movie);
                }
            }
        }


        //SHOW MOVIE
        private void ShowMovie(Movie m)
        {
            Console.WriteLine($"{m.Title} {m.Length} {m.Genre} {m.ReleaseDate} {m.WWW}");
        }


        //SHOW MOVIE LIST
        private void ShowMovieList()
        {
            foreach (Movie m in data.MovieList)
            {
                ShowMovie(m);
            }
        }
        #endregion



        
        
        #region Music section
        // MUSIC MENU

        private void MusicMenu()
        {
            Console.WriteLine("\nMusic MENU\n1 for list of Songs\n2 to search for Songs \n3 to add new Song \n4 for list of Albums \n5 to search for Albums \n6 to add a new Album");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSongList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSongs();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSong();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ShowAlbumList();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    SearchAlbum();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    AddAlbum();
                    break;

            }
        }

        // --------------AlBUM METHODS-----------------\\

        //ADD ALBUM
        private void AddAlbum()
        {
            Album album = new Album();
            album.Title = GetString("Title: ");
            album.Artist = GetString("Artist: ");
            album.Genre = GetString("Genre: ");
            album.Length = GetLength();
            album.ReleaseDate = GetReleaseDate();


            ShowAlbum(album);
            Console.WriteLine("Add album to list? Confirm adding to list (Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y) data.AlbumList.Add(album);

            Console.WriteLine("Add new song to album?");
            while (Console.ReadKey(true).Key == ConsoleKey.Y)
            {
                AddSong(album);
                Console.WriteLine("Add another song to album? (y/n)");
            };

        }

        //SEARCH ALBUM
        private void SearchAlbum()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Album album in data.AlbumList)
            {
                if (search != null)
                {
                    if (album.Title.Contains(search) || album.Genre.Contains(search))
                        ShowAlbum(album);
                }
            }
        }

        // SHOW ALBUM 
        private void ShowAlbum(Album s)
        {
            Console.WriteLine($"{s.Title} {s.Length} {s.Genre} {s.ReleaseDate} {s.Artist}");
        }

        // SHOW ALBUM LIST
        private void ShowAlbumList()
        {
            foreach (Album s in data.AlbumList)
            {
                ShowAlbum(s);
            }
        }
        //ADD SONG 

        private void AddSong()
        {
            Song song = new Song();
            song.Title = GetString("Title: ");
            song.Artist = GetString("Artist: ");
            song.Length = GetLength();
            song.Genre = GetString("Genre: ");
            song.ReleaseDate = GetReleaseDate();


            ShowSong(song);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.SongList.Add(song);
        }

        //SEARCH MUSIC 

        private void SearchSongs()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Song song in data.SongList)
            {
                if (search != null)
                {
                    if (song.Title.Contains(search) || song.Genre.Contains(search))
                        ShowSong(song);
                }
            }
        }

        // SHOW SONGS
        private void ShowSong(Song s)
        {
            Console.WriteLine($"{s.Title} {s.Length} {s.Genre} {s.ReleaseDate} {s.Artist}");
        }

        // SHOW SONG LIST
        private void ShowSongList()
        {
            foreach (Song s in data.SongList)
            {
                ShowSong(s);
            }
        }





       
        #endregion

        
        
        
        #region SERIES section
        //SERIES MENU
        private void SeriesMenu()
        {
            Console.WriteLine("\nSERIES MENU\n1 for list of Series\n2 to search for Series\n3 to add new Series\n4 for list of Episodes\n5 to search for Episode\n6 to add new Episode");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowSeriesList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchSeries();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddSeries();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ShowEpisodeList();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    SearchEpisode();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    AddEpisode();
                    break;

            }
        }



        // ADD SERIES
        private void AddSeries()
        {

            Series series = new Series();
            series.Title = GetString("Title: ");
            series.Length = GetLength();
            series.Genre = GetString("Genre: ");
            series.Season = GetInt("Season: ");
            series.ReleaseDate = GetReleaseDate();
            series.WWW = GetString("WWW: ");

            ShowSeries(series);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.SeriesList.Add(series);
        }


        //SEARCH SERIES
        private void SearchSeries()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Series series in data.SeriesList)
            {
                if (search != null)
                {
                    if (series.Title.Contains(search) || series.Genre.Contains(search))
                        ShowSeries(series);
                }
            }
        }
        //SEARCH SERIES
        private void SearchEpisode()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Episode episode in data.EpisodeList)
            {
                if (search != null)
                {
                    if (episode.Title.Contains(search) || episode.Genre.Contains(search))
                        ShowEpisode(episode);
                }
            }
        }


        //SHOW SERIES
        private void ShowSeries(Series y)
        {
            Console.WriteLine($"{y.Title} {y.Length} {y.Genre} {y.ReleaseDate} {y.WWW}");
        }


        //SHOW SERIES LIST
        private void ShowSeriesList()
        {
            foreach (Series y in data.SeriesList)
            {
                ShowSeries(y);
            }
        }


        //ADD EPISODE
        private void AddEpisode()
        {

            Episode episode = new Episode();
            episode.Title = GetString("Title: ");
            episode.Length = GetLength();
            episode.Genre = GetString("Genre: ");
            episode.EpisodeNumber = GetInt("Episodenumber: ");
            episode.Season = GetInt("Season: ");
            episode.ReleaseDate = GetReleaseDate();
            episode.WWW = GetString("WWW: ");

            ShowEpisode(episode);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.EpisodeList.Add(episode);
        }


        // SHOW EPISODE
        private void ShowEpisode(Episode y)
        {
            Console.WriteLine($"{y.Title} {y.Length} {y.Genre} {y.ReleaseDate} {y.WWW}");
        }


        //SHOW EPISODE LIST
        private void ShowEpisodeList()
        {
            foreach (Episode y in data.EpisodeList)
            {
                ShowEpisode(y);
            }
        }
        #endregion
        
        
        
        
        
        #region SHARE CALCULATIONS & INPUT
        //------------------------------SHARED CALCULATIONS-------------------\\


        // LENGTH CALCULATION
        private DateTime GetLength()
        {
            DateTime time;
            do
            {
                Console.Write("Length (hh:mm:ss): ");
            }
            while (!DateTime.TryParse("0001-01-01 " + Console.ReadLine(), out time));
            return time;
        }


        //RELEASE DATE CALCULATION
        private DateTime GetReleaseDate()
        {
            DateTime date;
            string input = "";
            do
            {
                Console.Write("Release Date (dd/mm/yyyy): ");
                input = Console.ReadLine();
                if (input == "") return DateTime.Today;
            }
            while (!DateTime.TryParse(input, out date));
            return date;
        }


        // GET INDPUT
        private string GetString(string type)
        {
            string? input;
            do
            {
                Console.Write(type);
                input = Console.ReadLine();
            }
            while (input == null || input == "");
            return input;
        }

        private int GetInt(string request)
        {
            int i;
            do
            {
                Console.Write(request);
            }
            while (!int.TryParse(Console.ReadLine(), out i));
            return i;
        }

        #endregion




        #region SAVE & LOAD section

        // SAVE DATA & LOAD DATA
        private void SaveDataMovie()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/MovieList.json", json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        private void LoadDataMovie()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/MovieList.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }
        private void SaveDataEpisode()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/MovieList.json", json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        private void LoadDataEpisode()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/MovieList.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }
        
        private void SaveDataAlbum()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/MovieList.json", json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        private void LoadDataAlbum()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/MovieList.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }

        private void SaveDataSong()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(data);
            File.WriteAllText(path + "/MovieList.json", json);
            Console.WriteLine("File saved succesfully at " + path);
        }

        private void LoadDataSong()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = File.ReadAllText(path + "/MovieList.json");
            data = System.Text.Json.JsonSerializer.Deserialize<Data>(json);
            Console.WriteLine("File loaded succesfully from " + path);
        }
        #endregion

    }
}
