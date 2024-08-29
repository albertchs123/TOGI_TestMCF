using Microsoft.AspNetCore.Mvc;
using bpkbAPI.Data;
using bpkbAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace bpkbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StorageLocationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StorageLocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locations = await _context.ms_storage_location.ToListAsync();
            return Ok(locations);
        }
    }
}
