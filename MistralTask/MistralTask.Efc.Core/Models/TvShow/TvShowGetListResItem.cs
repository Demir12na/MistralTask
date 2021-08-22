using System.Collections.Generic;

namespace MistralTask.MistralTaskEfcCore.Models.TvShow
{
    public class TvShowGetListResItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal? Rating { get; set; }
        public IList<Photo> Image { get; set; }

        public class Photo
        {
            public int Id { get; set; }
            public string ImageUrl { get; set; }
            public string ThumbnailUrl { get; set; }
            public string ImageAlt { get; set; }
            public string Title { get; set; }
            public int Order { get; set; }
        }
    }
}
