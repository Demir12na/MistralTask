using MistralTask.MistralTaskEfcCore;
using MistralTask.MistralTaskEfcCore.Repositories;

namespace MistralTask.MistralTaskEfcRepo
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMoviesRepository Movies { get; }
        public ITvShowsRepository TvShows { get; }

        public UnitOfWork(IMoviesRepository movies,
            ITvShowsRepository tvShows)
        {
            Movies = movies;
            TvShows = tvShows;
        }
    }
}
