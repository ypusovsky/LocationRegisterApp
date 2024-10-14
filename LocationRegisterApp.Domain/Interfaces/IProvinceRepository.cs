using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Domain.Interfaces
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<ProvinceDto>> GetByCountryName(string name);
        Task<IEnumerable<ProvinceDto>> GetByCountryId(int id);
        Task<ProvinceDto> Get(int id);
    }
}
