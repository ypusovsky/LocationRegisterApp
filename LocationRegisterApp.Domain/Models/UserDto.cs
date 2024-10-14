namespace LocationRegisterApp.Domain.Models
{
    public class UserDto
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int CountryId { get; private set; }
        public int ProvinceId { get; private set; }

        public UserDto(string email, string password, int countryId, int provinceId)
        {
            Email = email;
            Password = password;
            CountryId = countryId;
            ProvinceId = provinceId;
        }
    }
}
