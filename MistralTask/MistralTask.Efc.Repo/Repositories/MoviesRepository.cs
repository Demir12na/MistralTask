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

            //To do: Extract words (with "String.Split" or Regex) from req.SearchByTerm and improve switch-case 
            //(Example if first word is after and second is number, return all movies where year > second word)

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

            try
            {
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
                        Rating = m.Rating,
                        FiveStars = m.FiveStars,
                        FourStars = m.FourStars,
                        ThreeStars = m.ThreeStars,
                        TwoStars = m.TwoStars,
                        OneStars = m.OneStars,
                        Image = m.Photos.Where(i => i.IsMovie == true)
                                        .Select(i => new MovieGetListResItem.Photo
                                        {
                                            Image = i.ImageUrl,
                                            ThumbImage = i.ThumbnailUrl,
                                            Alt = i.ImageAlt,
                                            Title = i.Title,
                                            Order = i.Order
                                        }).ToList()

                    }).OrderByDescending(m => m.Rating)
                    .ToListAsync();

                foreach (MovieGetListResItem resItem in res)
                {
                    resItem.TotalStars = resItem.FiveStars + resItem.FourStars + resItem.ThreeStars + resItem.TwoStars + resItem.OneStars;
                }

                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<MovieAddRatingRes> AddRatingAsync(MovieAddRatingReq req)
        {
            try
            {
                IQueryable<Movies> scope = CreateScope();
                IQueryable<Ratings> ratingScope = _dbContext.Ratings;

                if (req.Star == 0 || req.MovieId == 0)
                {
                    throw new ArgumentException("Star or MovieId can't be 0");
                }

                Ratings rating = new Ratings
                {
                    Star = req.Star,
                    MovieId = req.MovieId,
                    IsMovie = true,
                    IsTvShow = false
                };

                _dbContext.Ratings.Add(rating);
                await _dbContext.SaveChangesAsync();

                List<int> ratings = await ratingScope.Where(r => r.MovieId == req.MovieId)
                    .Select(r => r.Star)
                    .ToListAsync();

                Movies movie = await scope
                    .Where(m => m.Id == req.MovieId)
                    .FirstOrDefaultAsync();

                decimal? ratingSum = ratings.Sum();
                decimal? ratingCount = ratings.Count();

                if (ratingCount == null || ratingCount == 0)
                {
                    throw new ArgumentException("Movie must have at least one rating");
                }

                movie.Rating = ratingSum / ratingCount;

                switch (req.Star.ToString())
                {
                    case "5":
                        movie.FiveStars++;
                        break;
                    case "4":
                        movie.FourStars++;
                        break;
                    case "3":
                        movie.ThreeStars++;
                        break;
                    case "2":
                        movie.TwoStars++;
                        break;
                    default:
                        movie.OneStars++;
                        break;
                }

                await _dbContext.SaveChangesAsync();

                return new MovieAddRatingRes { Id = rating.Id };
            }
            catch (ArgumentException argex)
            {
                Console.WriteLine(argex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
