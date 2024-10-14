using System.ComponentModel.DataAnnotations;

namespace LocationRegisterApp.Infrastructure.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CountryId { get; set; }
        public CountryEntity Country { get; set; }

        public int ProvinceId { get; set; }
        public ProvinceEntity Province { get; set; }
    }
}
