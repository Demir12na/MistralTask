using Microsoft.EntityFrameworkCore;
using MistralTask.MistralTaskDatabase;
using MistralTask.MistralTaskDatabaseEntities;
using MistralTask.MistralTaskEfcCore.Models.Movie;
using MistralTask.MistralTaskEfcCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MistralTask.MistralTaskEfcRepo.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        public MistralTaskDbContext _dbContext { get; }

        public MoviesRepository(MistralTaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Movies> CreateScope()
        {
            return _dbContext.Movies;
        }

        public IQueryable<Movies> SearchFilter(MovieGetListReq req)
        {
            IQueryable<Movies> scope = CreateScope();

            switch (req.SearchByTerm)
            {
                case "5 stars":
                    return scope = scope.Where(m => m.Rating == 5);
                case "at least 3 stars":
                    return scope = scope.Where(m => m.Rating >= 3);
                case "after 2015":
                    return scope = scope.Where(m => m.Year > 2015);
                case "older than 5 years":
                    return scope = scope.Where(m => m.Year > DateTime.Now.Year - 5);
                default:
                    return scope = scope.Where(m => m.Name.Contains(req.SearchByTerm));
            }

        }

        public async Task<IEnumerable<MovieGetListResItem>> GetListAsync(MovieGetListReq req)
        {
            IQueryable<Movies> scope = CreateScope();

            if (req.SearchByTerm != null)
            {
                scope = SearchFilter(req);
            }

            IEnumerable<MovieGetListResItem> res = await scope
                .Select(m => new MovieGetListResItem
                {
                    Id = m.Id,
                    Name = m.Name,
                    Year = m.Year,
                    Rating = m.Rating
                })
                .OrderByDescending(m => m.Rating)
                .ToListAsync();

            return res;
        }

    }
}
