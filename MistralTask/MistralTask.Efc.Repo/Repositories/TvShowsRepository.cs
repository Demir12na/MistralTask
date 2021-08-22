using Microsoft.EntityFrameworkCore;
using MistralTask.MistralTaskDatabase;
using MistralTask.MistralTaskDatabaseEntities;
using MistralTask.MistralTaskEfcCore.Models.TvShow;
using MistralTask.MistralTaskEfcCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralTask.MistralTaskEfcRepo.Repositories
{
    public class TvShowsRepository : ITvShowsRepository
    {
        public MistralTaskDbContext _dbContext { get; }

        public TvShowsRepository(MistralTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TvShows> CreateScope()
        {
            return _dbContext.TvShows;
        }

        public IQueryable<TvShows> SearchFilter(TvShowGetListReq req)
        {
            IQueryable<TvShows> scope = CreateScope();

            switch (req.SearchByTerm)
            {
                case "5 stars":
                    return scope = scope.Where(ts => ts.Rating == 5);
                case "at least 3 stars":
                    return scope = scope.Where(ts => ts.Rating >= 3);
                case "after 2015":
                    return scope = scope.Where(ts => ts.Year > 2015);
                case "older than 5 years":
                    return scope = scope.Where(ts => ts.Year > DateTime.Now.Year - 5);
                default:
                    return scope = scope.Where(ts => ts.Name.Contains(req.SearchByTerm));
            }

        }

        public async Task<IEnumerable<TvShowGetListResItem>> GetListAsync(TvShowGetListReq req)
        {
            IQueryable<TvShows> scope = CreateScope();

            scope = SearchFilter(req);

            IEnumerable<TvShowGetListResItem> res = await scope
                .Select(m => new TvShowGetListResItem
                {
                    Id = m.Id,
                    Name = m.Name,
                    Year = m.Year,
                    Rating = m.Rating
                }).OrderByDescending(m => m.Rating).ToListAsync();

            return res;
        }

    }
}
