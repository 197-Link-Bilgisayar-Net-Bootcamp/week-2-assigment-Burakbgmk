using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiWeb.Models;
using ApiWeb.ProductOperations.GetProducts;
using ApiWeb.ProductOperations.CreateProduct;
using ApiWeb.ProductOperations.GetProductInfo;
using ApiWeb.ProductOperations.UpdateProduct;
using ApiWeb.ProductOperations.DeleteProduct;

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
            GetMoviesQuerry querry = new GetMoviesQuerry(_context);
            var result = querry.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            MovieInfoViewModel result;
            try
            {
                GetMovieInfoQuerry querry = new GetMovieInfoQuerry(_context);
                querry.MovieId = id;
                result = querry.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context);
            try
            {
                command.Model = newMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, UpdateMovieModel updatedMovie)
        {
            try
            {
                UpdateMovieInfoCommand command = new UpdateMovieInfoCommand(_context);
                command.MovieId = id;
                command.Model = updatedMovie;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                DeleteMovieCommand command = new DeleteMovieCommand(_context);
                command.MovieId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}
