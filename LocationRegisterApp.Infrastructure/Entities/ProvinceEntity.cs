namespace LocationRegisterApp.Infrastructure.Entities
{
    public class ProvinceEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CountryEntity Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<UserEntity> Users { get; set; } = [];
    }
}
