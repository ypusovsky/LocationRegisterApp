using LocationRegisterApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocationRegisterApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController(IProvinceService provinceService) : ControllerBase
    {
        [HttpGet("ByCountryName")]
        public async Task<IActionResult> GetByCountryName(string name)
        {
            var provinces = await provinceService.GetByCountryName(name);
            if (!provinces.Any()) return NotFound();

            return Ok(provinces);
        }

        [HttpGet("ByCountryId/{id}")]
        public async Task<IActionResult> GetByCountryId(int id)
        {
            var provinces = await provinceService.GetByCountryId(id);
            if (!provinces.Any()) return NotFound();

            return Ok(provinces);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var province = await provinceService.Get(id);
            if (province == null) return NotFound();

            return Ok(province);
        }
    }
}
