using System.Dynamic;
using RealHousewivesTrivia.LogicLayer;
using RealHousewivesTrivia.Models;

namespace RealHousewivesTrivia.PresentationLayer;

public class Menus
{
    public static void StartMenu()
    {
        bool validUserInput;
        int userSelection;

        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create new profile");
            Console.WriteLine("2. Log into existing profile");
            Console.WriteLine("3. Exit");

            // This try-catch provides an error message if the user enters a
            // value that can't be turned into an integer.
            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;
                switch (userSelection)
                {
                    case 1: // Create a new user
                    CreateNewUserPrompts();
                    break;

                    case 2: // Log in as an existing user
                    break;

                    case 3: // Exit
                    break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        validUserInput = false;
                        break;
                }
            }
            catch (Exception error)
            {
            Console.WriteLine($"{error.Message}\nPlease enter a valid selection.");
            validUserInput = false;
            }
        } while (!validUserInput);
    }

    public static void CreateNewUserPrompts()
    {
        bool validUserInput;
        string userInput;

        do
        {
            Console.Write("Please provide a username: ");
            userInput = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username can't be blank. Please try again.");
                validUserInput = false;
            }
            // Want to add another check to see if the user already exists
            // Call a method in the UsersLogic namespace
            else 
            {
                Users newUser = UsersLogic.CreateNewUser(userInput);
                Console.WriteLine("Profile created!");
                Console.WriteLine($"User name: {newUser.userName}");
                //Console.WriteLine($"User ID: {newUser.userId}");
                Console.WriteLine($"Username: {newUser.GetName()}");
                validUserInput = true;
            }

        } while (!validUserInput);
    }


}