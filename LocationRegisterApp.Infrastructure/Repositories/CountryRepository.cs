using AutoMapper;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationRegisterApp.Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CountryDto> Get(int id)
        {
            var entity = await _context.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CountryDto>(entity);
        }

        public async Task<CountryDto> GetByName(string name)
        {
            var entity = await _context.Countries
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name);

            return _mapper.Map<CountryDto>(entity);
        }

        public async Task<IEnumerable<CountryDto>> GetAll()
        {
            var entities = await _context.Countries
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<CountryDto>>(entities);
        }
    }
}
