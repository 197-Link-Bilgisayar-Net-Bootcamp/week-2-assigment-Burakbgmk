using ApiWeb.Models;

namespace ApiWeb.ProductOperations.GetProducts
{
    public class GetMoviesQuerry
    {
        private readonly ProductContext _dbContext;

        public GetMoviesQuerry(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.OrderBy(x => x.Id).ToList<Movie>();
            List<MoviesViewModel> vm = new List<MoviesViewModel>();
            foreach (var movie in movieList)
            {
                vm.Add(new MoviesViewModel()
                {
                    Title = movie.Title,
                    Genre = movie.Genre
                });
            }
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
