using System;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes;

public class Player : IPlayer
{
    private IGame Game { get; }
    private readonly Random _random;

    public Player(IGame game)
    {
        Game = game;
        _random = new Random();
    }

    public void Play(bool changeinitialChosenDoor)
    {
        Game.WinCount = 0;

        for (var i = 0; i < Game.GameCount; i++)
        {
            var initialChoose = _random.Next(0, 3);

            Game.PlayerChoosesDoor(initialChoose);
            Game.GameOrganizerOpensDoor();

            var chosenDoor = changeinitialChosenDoor
                ? Game.PlayerChoosesDoor(DoorState.FirstChosenDoor)
                : Game.PlayerChoosesDoor(DoorState.ChosenOpenedDoor);

            if (chosenDoor.ItemBehindDoor == Classes.Game.Car)
                Game.WinCount++;

            Game.GameRestart();
        }

        var chosenAction = changeinitialChosenDoor
            ? "you have chosen to change the initial chosen door"
            : "you have chosen not to change the initial chosen door\"";


        Console.WriteLine($"Action: {chosenAction} \n" +
                          $"Number of games played is {Game.GameCount} games " +
                          $"wins: {Game.WinCount}." +
                          $"loses: {Game.GameCount-Game.WinCount}." +
                          $"\nWin rate {Game.WinRate} and in percentage is  {Game.WinRatePercentage}. \n");
    }
}