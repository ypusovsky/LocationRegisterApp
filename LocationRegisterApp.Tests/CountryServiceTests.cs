using LocationRegisterApp.Application.Services;
using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using Moq;

public class CountryServiceTests
{
    private readonly Mock<ICountryRepository> _mockRepository;
    private readonly ICountryService _countryService;

    public CountryServiceTests()
    {
        _mockRepository = new Mock<ICountryRepository>();
        _countryService = new CountryService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsListOfCountries()
    {
        // Arrange
        var countries = new List<CountryDto>
        {
            new() { Id = 1, Name = "Country1" },
            new() { Id = 2, Name = "Country2" }
        };

        _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(countries);

        // Act
        var result = await _countryService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Country1", result.First().Name);
    }

    [Fact]
    public async Task GetByName_ReturnsCountry_WhenCountryExists()
    {
        // Arrange
        var country = new CountryDto { Id = 1, Name = "Country1" };
        _mockRepository.Setup(repo => repo.GetByName("Country1")).ReturnsAsync(country);

        // Act
        var result = await _countryService.GetByName("Country1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(country.Id, result.Id);
        Assert.Equal(country.Name, result.Name);
    }

    [Fact]
    public async Task GetById_ReturnsCountry_WhenCountryExists()
    {
        // Arrange
        var country = new CountryDto { Id = 1, Name = "Country1" };
        _mockRepository.Setup(repo => repo.Get(1)).ReturnsAsync(country);

        // Act
        var result = await _countryService.GetById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(country.Id, result.Id);
        Assert.Equal(country.Name, result.Name);
    }

    [Fact]
    public async Task GetByName_ReturnsNull_WhenCountryDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetByName("NonExistentCountry")).ReturnsAsync((CountryDto)null);

        // Act
        var result = await _countryService.GetByName("NonExistentCountry");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetById_ReturnsNull_WhenCountryDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((CountryDto)null);

        // Act
        var result = await _countryService.GetById(99);

        // Assert
        Assert.Null(result);
    }
}