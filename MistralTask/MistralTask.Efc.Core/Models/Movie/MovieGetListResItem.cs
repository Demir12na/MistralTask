using System.Collections.Generic;

namespace MistralTask.MistralTaskEfcCore.Models.Movie
{
    public class MovieGetListResItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public IList<Photo> Image { get; set; }
        public decimal? Rating { get; set; }
        public int? FiveStars { get; set; }
        public int? FourStars { get; set; }
        public int? ThreeStars { get; set; }
        public int? TwoStars { get; set; }
        public int? OneStars { get; set; }
        public int? TotalStars { get; set; }
        public class Photo
        {
            public int Id { get; set; }
            public string Image { get; set; }
            public string ThumbImage { get; set; }
            public string Alt { get; set; }
            public string Title { get; set; }
            public int Order { get; set; }
        }
    }
}
