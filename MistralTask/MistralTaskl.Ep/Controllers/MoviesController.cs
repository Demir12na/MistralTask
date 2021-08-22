using Microsoft.AspNetCore.Mvc;
using MistralTask.MistralTaskEfcCore;
using MistralTask.MistralTaskEfcCore.Models.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MistralTask.MistralTasklEp.Controllers
{
    [Route("/api/movies")]
    public class MoviesController : Controller
    {
        public IUnitOfWork _unitOfWork { get; }

        public MoviesController(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieGetListResItem>> GetList(MovieGetListReq req)
        {
            IEnumerable<MovieGetListResItem> res = await _unitOfWork.Movies.GetListAsync(req);

            return res;
        }

    }
}
