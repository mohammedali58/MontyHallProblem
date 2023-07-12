using MontyHallProblem.Enums;

namespace MontyHallProblem.Interfaces;

public interface IGame
{
    int GameCount { get; }
        
    int WinCount { get; set; }

    double WinRate { get; }
        
    string WinRatePercentage { get; }

    IDoor PlayerChoosesDoor(int doorIndex);
        
    IDoor PlayerChoosesDoor(DoorState doorState);
                
    IDoor GameOrganizerOpensDoor();
        
    void GameRestart();
}