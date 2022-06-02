using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiWeb.Models;

namespace ApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductContext _context;
        public ProductController(ProductContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var movieList = _context.Movies.OrderBy(x => x.Id).ToList();
            return Ok(movieList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _context.Movies.Where(x => x.Id == id).SingleOrDefault();
            if (movie is null)
                return BadRequest();
            return Ok(movie);
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Title == newMovie.Title);
            if (movie is not null)
                return BadRequest();
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie is null)
                return BadRequest();
            movie.Title = updatedMovie.Title != default ? updatedMovie.Title : movie.Title;
            movie.Genre = updatedMovie.Genre != default ? updatedMovie.Genre : movie.Genre;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie is null)
                return BadRequest();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok();
        }

    }
}
