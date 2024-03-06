using Microsoft.AspNetCore.Mvc;
using WebApplicationYeni.Dto;
using WebApplicationYeni.Services;

namespace WebApplicationYeni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
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

