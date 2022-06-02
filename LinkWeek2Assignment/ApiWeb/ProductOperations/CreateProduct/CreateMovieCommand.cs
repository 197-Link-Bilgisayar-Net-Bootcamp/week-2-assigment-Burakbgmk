using ApiWeb.Models;

namespace ApiWeb.ProductOperations.CreateProduct
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }

        private readonly ProductContext _dbContext;

        public CreateMovieCommand(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);
            if (movie is not null)
                throw new InvalidOperationException("Movie already exists");

            movie = new Movie();
            movie.Title = Model.Title;
            movie.Genre = Model.Genre;

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
    }
}
