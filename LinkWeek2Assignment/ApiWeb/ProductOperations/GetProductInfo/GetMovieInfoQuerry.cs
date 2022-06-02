using ApiWeb.ProductOperations.GetProducts;

namespace ApiWeb.ProductOperations.GetProductInfo
{
    public class GetMovieInfoQuerry
    {
        private readonly ProductContext _dbContext;

        public int MovieId { get; set; }

        public GetMovieInfoQuerry(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MovieInfoViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(x => x.Id == MovieId).SingleOrDefault();
            if (movie is null)
                throw new InvalidOperationException("Movie is not found!");
            MovieInfoViewModel vm = new MovieInfoViewModel();
            vm.Title = movie.Title;
            vm.Genre = movie.Genre;
            return vm;
        }
    }

    public class MovieInfoViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
