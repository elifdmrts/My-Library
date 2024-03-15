using Microsoft.AspNetCore.Mvc;
using MyLibrary.Business.Services;
using MyLibrary.Data.Dto;


namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase

    {
        private readonly BooksService _booksService;


        public BooksController(BooksService booksService)
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
        public IActionResult Put(BookUpdateDto model)
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
        public IActionResult Post(BookCreateDto model)
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