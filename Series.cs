namespace OOPSpotiflixV2
{
    internal class Series : Media
    {
        public List<Episode> Episodes { get; set; } = new();

        public string GetLength()
        {
            return Length.ToString("hh:mm");
        }

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
