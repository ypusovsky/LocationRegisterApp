using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services
{
    public class CountryService(ICountryRepository countryRepository) : ICountryService
    {
        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            return await countryRepository.GetAll();
        }

        public async Task<CountryDto> GetByName(string name)
        {
            return await countryRepository.GetByName(name);
        }
        public async Task<CountryDto> GetById(int id)
        {
            return await countryRepository.Get(id);
        }
    }
}
