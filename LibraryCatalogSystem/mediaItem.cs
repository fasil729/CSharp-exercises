namespace LibraryCatalogSystem
{
    class MediaItem
    {
        public string Title { get; set; }
        public string MediaType { get; set; }
        public int Duration { get; set; }

        public MediaItem(string title, string mediaType, int duration)
        {
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }
    }
}