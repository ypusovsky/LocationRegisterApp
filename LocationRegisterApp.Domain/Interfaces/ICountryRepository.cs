

using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<CountryDto>> GetAll();
        Task<CountryDto> Get(int id);
        Task<CountryDto> GetByName(string name);
    }
}
