namespace MistralTask.MistralTaskDatabaseEntities
{
    public class Photos
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ImageAlt { get; set; }
        public string Title { get; set; }
        public int? MovieId { get; set; }
        public Movies Movie { get; set; }
        public bool IsMovie { get; set; }
        public int? TvShowId { get; set; }
        public TvShows TvShow { get; set; }
        public bool IsTvShow { get; set; }
        public int Order { get; set; }
    }
}
