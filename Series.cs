namespace OOPSpotiflixV2
{
    internal class Series : Media
    {
        public int Season { get; set; }



    }
    internal class Episode : Media
    {

        public int Season { get; set; }

        public int EpisodeNumber { get; set; }

        public string GetLength()
        {
            return Length.ToString("mm");
        }

    }
}
