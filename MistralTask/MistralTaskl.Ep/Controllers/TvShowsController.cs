using Microsoft.AspNetCore.Mvc;
using MistralTask.MistralTaskEfcCore;
using MistralTask.MistralTaskEfcCore.Models.TvShow;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MistralTask.MistralTasklEp.Controllers
{
    [Route("/api/tv-shows")]
    public class TvShowsController : Controller
    {
        public IUnitOfWork _unitOfWork { get; }

        public TvShowsController(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<TvShowGetListResItem>> GetList(TvShowGetListReq req)
        {
            IEnumerable<TvShowGetListResItem> res = await _unitOfWork.TvShows.GetListAsync(req);

            return res;
        }

    }
}
