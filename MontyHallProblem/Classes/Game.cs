using System;
using System.Collections.Generic;
using System.Linq;
using MontyHallProblem.Enums;
using MontyHallProblem.Interfaces;

namespace MontyHallProblem.Classes;

public class Game : IGame
{
    public const string Goat = "Goat";
    public const string Car = "Car";

    private List<IDoor> _doors = new List<IDoor>
    {
        new Door { DoorState = DoorState.FirstChosenDoor, ItemBehindDoor = Goat },
        new Door { DoorState = DoorState.FirstChosenDoor, ItemBehindDoor = Goat },
        new Door { DoorState = DoorState.FirstChosenDoor, ItemBehindDoor = Car }
    };

    public int GameCount { get; }
    public int WinCount { get; set; }

    public Game(int gameCount)
    {
        GameCount = gameCount;
    }

    public double WinRate => (double)WinCount / GameCount;

    public string WinRatePercentage => $"{(int)(WinRate * 100)}%";

    public IDoor PlayerChoosesDoor(int doorIndex)
    {
        _doors[doorIndex].DoorState = DoorState.ChosenOpenedDoor;
        return _doors[doorIndex];
    }

    public IDoor PlayerChoosesDoor(DoorState state)
    {
        var door = _doors.First(x => x.DoorState == state);

        door.DoorState = DoorState.ChosenOpenedDoor;

        return door;
    }

    public IDoor GameOrganizerOpensDoor()
    {
        var door = _doors.First(x => x.ItemBehindDoor == Goat && x.DoorState != DoorState.ChosenOpenedDoor);

        door.DoorState = DoorState.DoorOpened;

        return door;
    }

    public void GameRestart()
    {
        _doors.ForEach(x => x.DoorState = DoorState.FirstChosenDoor);

        _doors = _doors.OrderBy(x => new Random().Next()).ToList();
    }
}