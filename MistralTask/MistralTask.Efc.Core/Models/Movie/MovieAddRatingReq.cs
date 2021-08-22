using System.ComponentModel.DataAnnotations;

namespace MistralTask.MistralTaskEfcCore.Models.Movie
{
    public class MovieAddRatingReq
    {
        [Required]
        [Range(1,5)]
        public int Star { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
