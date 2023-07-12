using MontyHallProblem.Classes;
using MontyHallProblem.Interfaces;
using System;
namespace MontyHallProblem;

public static class Program
{
    private static void Main()
    {
        
        Console.WriteLine("Welcome to the Monty Hall game problem simulation!");

        // Read user input for number of simulations and whether or not to switch doors
        Console.Write("Enter the number of simulations to run: ");

        int numSimulations = NumberOfSimulation();

        IGame game = new Game(numSimulations);
        var player = new Player(game);

        Console.Write("Do you want to switch doors? (y/n): ");

        bool switchDoors = IsSwitchDoor() == "y";

        if (switchDoors) 
            player.Play(true);
        else 
            player.Play(false);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    public static int NumberOfSimulation() {

        int input;
        bool isValidInput = false;

        do
        {
            Console.Write("Enter an integer: ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out input))
            {
                // User input is a valid integer
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
            }
        } while (!isValidInput);

        return input;



    }

    public static string IsSwitchDoor() {

        string userInput;
        bool isValidInput = false;

        do
        {
           // Console.Write("Do you want to switch doors? (y/n): ");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "y" || userInput == "n")
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        } while (!isValidInput);

        return userInput;
    }
}