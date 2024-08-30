using Microsoft.AspNetCore.Mvc;
using bpkbAPI.Data;
using bpkbAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bpkbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BpkbsController : ControllerBase
    {
        private readonly IBpkbServices _bpkbService;

        public BpkbsController(IBpkbServices trBpkbService)
        {
            _bpkbService = trBpkbService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var bpkbs = await _bpkbService.getAllData();
            return Ok(bpkbs);
        }


        [HttpPost]
        public async Task<ReturnStatus> Post(bpkb bpkb)
        {
            var result = await _bpkbService.SaveOrUpdateBpkb(bpkb);
            return new ReturnStatus
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message,
            };
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string agreement_number)
        {
            var result = await _bpkbService.DeleteBpkb(agreement_number);
            if (!result.IsSuccess)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
