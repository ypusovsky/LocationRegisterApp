using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<ProvinceDto>> GetByCountryName(string name);
        Task<IEnumerable<ProvinceDto>> GetByCountryId(int id);
        Task<ProvinceDto> Get(int id);
    }
}
