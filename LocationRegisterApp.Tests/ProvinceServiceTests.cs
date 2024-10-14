using LocationRegisterApp.Application.Services;
using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using Moq;

public class ProvinceServiceTests
{
    private readonly Mock<IProvinceRepository> _mockRepository;
    private readonly IProvinceService _provinceService;

    public ProvinceServiceTests()
    {
        _mockRepository = new Mock<IProvinceRepository>();
        _provinceService = new ProvinceService(_mockRepository.Object);
    }

    [Fact]
    public async Task GetByCountryName_ReturnsListOfProvinces()
    {
        // Arrange
        var provinces = new List<ProvinceDto>
        {
            new ProvinceDto { Id = 1, Name = "Province1" },
            new ProvinceDto { Id = 2, Name = "Province2" }
        };

        _mockRepository.Setup(repo => repo.GetByCountryName("Country1")).ReturnsAsync(provinces);

        // Act
        var result = await _provinceService.GetByCountryName("Country1");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Province1", result.First().Name);
    }

    [Fact]
    public async Task GetByCountryId_ReturnsListOfProvinces()
    {
        // Arrange
        var provinces = new List<ProvinceDto>
        {
            new ProvinceDto { Id = 1, Name = "Province1" },
            new ProvinceDto { Id = 2, Name = "Province2" }
        };

        _mockRepository.Setup(repo => repo.GetByCountryId(1)).ReturnsAsync(provinces);

        // Act
        var result = await _provinceService.GetByCountryId(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("Province1", result.First().Name);
    }

    [Fact]
    public async Task Get_ReturnsProvince_WhenProvinceExists()
    {
        // Arrange
        var province = new ProvinceDto { Id = 1, Name = "Province1" };
        _mockRepository.Setup(repo => repo.Get(1)).ReturnsAsync(province);

        // Act
        var result = await _provinceService.Get(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(province.Id, result.Id);
        Assert.Equal(province.Name, result.Name);
    }

    [Fact]
    public async Task Get_ReturnsNull_WhenProvinceDoesNotExist()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((ProvinceDto?)null);

        // Act
        var result = await _provinceService.Get(99);

        // Assert
        Assert.Null(result);
    }
}
