using AutoMapper;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationRegisterApp.Infrastructure.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProvinceRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProvinceDto>> GetByCountryName(string name)
        {
            var entities = await _context.Provinces
                .Include(p => p.Country)
                .AsNoTracking()
                //.Where(p => p.Country.Name == name)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProvinceDto>>(entities);
        }
        public async Task<IEnumerable<ProvinceDto>> GetByCountryId(int id)
        {
            var entities = await _context.Provinces
                .Include(p => p.Country)
                .AsNoTracking()
                .Where(p => p.Country.Id == id)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProvinceDto>>(entities);
        }

        public async Task<ProvinceDto> Get(int id)
        {
            var entity = await _context.Provinces
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<ProvinceDto>(entity);
        }
    }
}
