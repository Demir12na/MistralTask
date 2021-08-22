using System.Collections.Generic;

namespace MistralTask.MistralTaskDatabaseEntities
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal? Rating { get; set; }
        public int? FiveStars { get; set; }
        public int? FourStars { get; set; }
        public int? ThreeStars { get; set; }
        public int? TwoStars { get; set; }
        public int? OneStars { get; set; }
        public IList<Photos> Photos { get; set; }
    }
}
