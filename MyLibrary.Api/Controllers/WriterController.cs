using Microsoft.AspNetCore.Mvc;
using MyLibrary.Business.Services;
using MyLibrary.Data.Dto;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly WriterService _writerService;

        public WriterController(WriterService writerService)
        {

            _writerService = writerService;

        }


        [HttpGet]

        public ActionResult Get()
        {
            var list = _writerService.GetAll();
            return Ok(list);
        }

        [HttpPut]
        public IActionResult Put(WriterDto model)
        {
            try
            {
                _writerService.Update(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(WriterCreateDto model)
        {
            try
            {
                var writer = _writerService.Create(model);
                return Ok(writer);
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
                _writerService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }








    }
}

