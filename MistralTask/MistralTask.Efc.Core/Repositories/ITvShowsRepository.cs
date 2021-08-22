using MistralTask.MistralTaskEfcCore.Models.TvShow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MistralTask.MistralTaskEfcCore.Repositories
{
    public interface ITvShowsRepository
    {
        Task<IEnumerable<TvShowGetListResItem>> GetListAsync(TvShowGetListReq req);
    }
}
