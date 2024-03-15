using Microsoft.AspNetCore.Mvc;
using MyLibrary.Business.Services;
using MyLibrary.Data.Dto;

namespace MyLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _loanService.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Loaned")]
        public async Task<IActionResult> Loaned(LoanedDto model)
        {
            try
            {
                await _loanService.LoanedBook(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Borrow")]
        public async Task<IActionResult> Borrow(BorrowDto model)
        {
            try
            {
                await _loanService.BorrowBook(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
