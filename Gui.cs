namespace OOPSpotiflixV2
{
    #region MAIN BODY section and start up Menu
    internal class Gui
    {
        private Data data = new Data();
        //private Media media = new Media();
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
            Console.WriteLine("\nMENU\n1 for Movies\n2 for Series\n3 for Music");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SeriesMenu();

                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    MusicMenu();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    break;
                default:
                    break;
            }
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



        #region  GET INPUT DATA
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
                if (input == "") return "Unknown";
            }
            while (input == null);
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
            string? search = Console.ReadLine().ToLower();
            foreach (Movie movie in data.MovieList)
            {
                if (search != null)
                {

                    if (movie.Title.ToLower().Contains(search) || movie.Genre.ToLower().Contains(search))
                        ShowMovie(movie);
                }
            }
        }


        //SHOW MOVIE
        private void ShowMovie(Movie m)
        {
            Console.WriteLine($"{m.Title} {m.GetLength()} {m.Genre} {m.GetReleaseDate()} {m.WWW}");
        }


        //SHOW MOVIE LIST
        private void ShowMovieList()
        {
            if (data.MovieList == null || data.MovieList.Count == 0) return;
            foreach (Movie m in data.MovieList)
            {
                ShowMovie(m);
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
            string? search = Console.ReadLine().ToLower();
            foreach (Series series in data.SeriesList)
            {
                if (search != null)
                {
                    if (series.Title.ToLower().Contains(search) || series.Genre.ToLower().Contains(search))
                        ShowSeries(series);
                }
            }
        }
        //SEARCH Episode
        private void SearchEpisode()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Episode episode in data.EpisodeList)
            {
                if (search != null)
                {
                    if (episode.Title.ToLower().Contains(search) || episode.Genre.ToLower().Contains(search))
                        ShowEpisode(episode);
                }
            }
        }


        //SHOW SERIES
        private void ShowSeries(Series s)
        {
            Console.WriteLine($"{s.Title} {s.GetLength()} {s.Genre} {s.GetReleaseDate()} {s.WWW}");
            foreach (Episode e in s.Episodes)
            {

                Console.WriteLine($"{e.Title}");
            }
        }


        //SHOW SERIES LIST
        private void ShowSeriesList()
        {
            foreach (Series s in data.SeriesList)
            {
                ShowSeries(s);
            }
        }


        //ADD EPISODE
        private void AddEpisode()
        {

            Episode episode = new Episode();
            episode.Title = GetString("Title: ");
            episode.Season = GetInt("Season: ");
            episode.EpisodeNumber = GetInt("Episode number: ");
            episode.Length = GetLength();
            episode.Genre = GetString("Genre: ");
            episode.ReleaseDate = GetReleaseDate();


            ShowEpisode(episode);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.EpisodeList.Add(episode);
        }


        // SHOW EPISODE
        private void ShowEpisode(Episode e)
        {
            Console.WriteLine($"{e.Title} {e.GetLength()} {e.Genre} {e.GetReleaseDate()} {e.WWW}");
        }


        //SHOW EPISODE LIST
        private void ShowEpisodeList()
        {
            foreach (Episode e in data.EpisodeList)
            {
                ShowEpisode(e);
            }
        }
        #endregion






        #region Music section
        // MUSIC MENU

        private void MusicMenu()
        {
            Console.WriteLine("\nMusic MENU\n1 for list of Albums\n2 to search for Albums \n3 to add new Album \n4 for list of Songs \n5 to search for Song \n6 to add a new Song");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowAlbumList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchAlbum();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddAlbum();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    ShowSongList();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    SearchSongs();
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    AddSong();
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
            album.WWW = GetString("WWW: ");

            ShowAlbum(album);
            Console.WriteLine("Add album to list? Confirm adding to list (Y/N)");
            if (Console.ReadKey(true).Key == ConsoleKey.Y) data.AlbumList.Add(album);
                        
        }

        //SEARCH ALBUM
        private void SearchAlbum()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine().ToLower();
            foreach (Album album in data.AlbumList)
            {
                if (search != null)
                {
                    if (album.Title.ToLower().Contains(search) || album.Genre.ToLower().Contains(search))
                        ShowAlbum(album);
                }
            }
        }

        // SHOW ALBUM 
        private void ShowAlbum(Album s)
        {
            Console.WriteLine($"{s.Title} {s.GetLength()} {s.Genre} {s.GetReleaseDate()} {s.Artist}");
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
            song.Genre = GetString("Genre: ");
            song.ReleaseDate = GetReleaseDate();
            song.Length = GetLength();

            ShowSong(song);
            Console.WriteLine("Confirm adding to list (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y) data.SongList.Add(song);
        }

        //SEARCH SONG 

        private void SearchSongs()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine().ToLower();
            foreach (Song song in data.SongList)
            {
                if (search != null)
                {
                    if (song.Title.ToLower().Contains(search) || song.Genre.ToLower().Contains(search))
                        ShowSong(song);
                }
            }
        }

        // SHOW SONGS
        private void ShowSong(Song s)
        {
            Console.WriteLine($"{s.Title} {s.GetLength()} {s.Genre} {s.GetReleaseDate()} {s.Artist}");
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

    }
}
