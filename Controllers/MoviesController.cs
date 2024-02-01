using Microsoft.AspNetCore.Mvc;
using Blockbuster.Data;
using Blockbuster.Models;
using Blockbuster.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blockbuster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApiDbContext dbContext;

        public MoviesController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            return dbContext.Movies;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = dbContext.Movies.FirstOrDefault(s => s.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public ActionResult Post([FromBody] MoviesDTO newMovie)
        {
            var movie = new Movies
            {
                Title = newMovie.Title,
                Genre = newMovie.Genre,
                Duration = newMovie.Duration,


            };
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();

            return Ok();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movies updatedMovie)
        {
            if (updatedMovie == null || id != updatedMovie.Id)
            {
                return BadRequest();
            }

            var existingMovie = dbContext.Movies.FirstOrDefault(s => s.Id == id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Genre = updatedMovie.Genre;
            existingMovie.Duration = updatedMovie.Duration;

            dbContext.SaveChanges();

            return NoContent();

        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = dbContext.Movies.FirstOrDefault(s => s.Id == id);

            if (movieToDelete == null)
            {
                return NotFound();
            }

            dbContext.Movies.Remove(movieToDelete);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
