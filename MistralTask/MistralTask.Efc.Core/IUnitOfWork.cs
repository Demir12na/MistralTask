using MistralTask.MistralTaskEfcCore.Repositories;

namespace MistralTask.MistralTaskEfcCore
{
    public interface IUnitOfWork
    {
        public IMoviesRepository Movies { get; }
        public ITvShowsRepository TvShows { get; }
    }
}
