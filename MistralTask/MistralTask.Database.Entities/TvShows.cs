using System.Collections.Generic;

namespace MistralTask.MistralTaskDatabaseEntities
{
    public class TvShows
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal? Rating { get; set; }
        public IList<Photos> Photos { get; set; }
    }
}
