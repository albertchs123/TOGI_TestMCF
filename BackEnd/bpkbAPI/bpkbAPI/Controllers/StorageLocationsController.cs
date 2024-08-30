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
        private readonly IStorageLocationService _storageLocationService;

        public StorageLocationsController(IStorageLocationService storageLocationService)
        {
            _storageLocationService = storageLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locations = await _storageLocationService.getAllDataLocation();
            return Ok(locations);
        }
    }
}
