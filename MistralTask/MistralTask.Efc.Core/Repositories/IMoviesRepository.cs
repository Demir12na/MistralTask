using MistralTask.MistralTaskEfcCore.Models.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MistralTask.MistralTaskEfcCore.Repositories
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<MovieGetListResItem>> GetListAsync(MovieGetListReq req);
    }
}
