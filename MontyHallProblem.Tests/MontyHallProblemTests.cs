using FluentAssertions;
using MontyHallProblem.Classes;
using MontyHallProblem.Interfaces;
using Xunit;

namespace MontyHallProblem.Tests;

public class MontyHallProblemTests
{
    [Theory]
    [InlineData(20000)]
    [InlineData(300000)]
    [InlineData(400000)]
    public void ChangeDoorWinRateResult(int numberOfGames)
    {
        // Arrange
        IGame game = new Game(numberOfGames);
        var player = new Player(game);

        // Act
        player.Play(changeinitialChosenDoor: true);

        // Assert
        game.WinRate.Should().BeGreaterThan(0.66d);
    }

    [Theory]
    [InlineData(20000)]
    [InlineData(300000)]
    [InlineData(400000)]
    public void ChangeDoorWinRatePercentage(int numberOfGames)
    {
        // Arrange
        IGame game = new Game(numberOfGames);
        var player = new Player(game);

        // Act
        player.Play(changeinitialChosenDoor: true);

        // Assert
         game.WinRatePercentage.Should().Be("66%");
    }

    [Theory]
    [InlineData(20000)]
    [InlineData(300000)]
    [InlineData(400000)]
    public void DoNotChangeDoorResult(int numberOfGames)
    {
        // Arrange
        IGame game = new Game(numberOfGames);
        var player = new Player(game);

        // Act
        player.Play(changeinitialChosenDoor: false);

        // Assert
        game.WinRate.Should().BeGreaterThan(0.33d);
    }

    [Theory]
    [InlineData(20000)]
    [InlineData(300000)]
    [InlineData(400000)]
    public void DoNotChangeDoorWinPercentage(int numberOfGames)
    {
        // Arrange
        IGame game = new Game(numberOfGames);
        var player = new Player(game);

        // Act
        player.Play(changeinitialChosenDoor: false);

        // Assert
        game.WinRatePercentage.Should().Be("33%");
    }
}