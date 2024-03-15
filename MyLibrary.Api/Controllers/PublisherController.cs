using Microsoft.AspNetCore.Mvc;
using MyLibrary.Business.Services;
using MyLibrary.Data.Dto;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {

            _publisherService = publisherService;

        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = _publisherService.GetAll();
            return Ok(list);
        }

        [HttpPut]
        public IActionResult Put(PublisherDto model)
        {
            try
            {
                _publisherService.Update(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(PublisherCreateDto model)
        {
            try
            {
                var publisher = _publisherService.Create(model);
                return Ok(publisher);
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
                _publisherService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




























    }
}
