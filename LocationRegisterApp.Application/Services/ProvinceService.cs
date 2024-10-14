using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services
{
    public class ProvinceService(IProvinceRepository provinceRepository) : IProvinceService
    {
        public async Task<IEnumerable<ProvinceDto>> GetByCountryName(string name)
        {
            return await provinceRepository.GetByCountryName(name);
        }

        public async Task<IEnumerable<ProvinceDto>> GetByCountryId(int id)
        {
            return await provinceRepository.GetByCountryId(id);
        }

        public async Task<ProvinceDto> Get(int id)
        {
            return await provinceRepository.Get(id);
        }
    }
}
