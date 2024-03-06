using Microsoft.AspNetCore.Mvc;
using WebApplicationYeni.Services;
using WebApplicationYeni.Dto;


namespace WebApplicationYeni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase

    {
        private readonly IBooksService _booksService;


        public BooksController(IBooksService booksService)
        {

            _booksService = booksService;

        }


        [HttpGet]

        public IActionResult Get()
        {
            var list = _booksService.GetAll();
            return Ok(list);
        }


        [HttpPut]
        public IActionResult Put(BooksDto model)
        {
            try
            {
                _booksService.Update(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(BooksCreateDto model)
        {
            try
            {
                var books = _booksService.Create(model);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _booksService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}