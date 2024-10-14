using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAll();
        Task<CountryDto> GetByName(string name);
        Task<CountryDto> GetById(int id);
    }
}
