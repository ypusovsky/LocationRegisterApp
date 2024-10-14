using LocationRegisterApp.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocationRegisterApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountryService countryService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var country = await countryService.GetById(id);
            if (country == null) return NotFound();

            return Ok(country);
        }

        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var country = await countryService.GetByName(name);
            if (country == null) return NotFound();

            return Ok(country);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await countryService.GetAll();

            return Ok(countries);
        }
    }
}
