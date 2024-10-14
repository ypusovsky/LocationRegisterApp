using LocationRegisterApp.Application.Services;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using Moq;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _userService = new UserService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task Create_ReturnsTrue_WhenUserCreatedSuccessfully()
    {
        // Arrange
        var user = new UserDto(
            "test@example.com",
            "Password123",
            1,
            1);

        // Setup repository to successfully create the user
        _mockUserRepository.Setup(repo => repo.CreateAsync(It.IsAny<UserDto>())).ReturnsAsync(true);

        // Act
        var result = await _userService.Create(user);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Create_ThrowsException_WhenEmailExists()
    {
        // Arrange
        var user = new UserDto(
           "test@example.com",
           "Password123",
           1,
           1);

        // Setup repository to throw an exception when attempting to create a user with an existing email
        _mockUserRepository.Setup(repo => repo.CreateAsync(It.IsAny<UserDto>())).ThrowsAsync(new Exception("Duplicate email"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _userService.Create(user));
    }
}
