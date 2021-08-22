namespace MistralTask.MistralTaskDatabaseEntities
{
    public class Ratings
    {
        public int Id { get; set; }
        public int Star { get; set; }
        public int? MovieId { get; set; }
        public bool IsMovie { get; set; }
        public int? TvShowId { get; set; }
        public bool IsTvShow { get; set; }
    }
}
