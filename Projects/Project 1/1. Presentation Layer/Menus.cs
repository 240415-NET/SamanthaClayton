using Project1.Models;
using Project1.LogicLayer;

namespace Project1.PresentationLayer;


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

            try
            {
                userSelection = int.Parse(Console.ReadLine() ?? "");
                validUserInput = true;

                switch(userSelection)
                {
                    case 1: // Create new profile
                    CreateNewUserPrompts();
                    break;

                    case 2: // Log into existing profile
                    LogInPrompts();
                    break;

                    case 3: //Exit the application
                    break;

                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        validUserInput = false;
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{exception.Message}\nPlease enter a valid selection.");
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
            if(string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username can't be blank. Please try again.");
                validUserInput = false;
            }
            else if (UsersLogic.CheckIfUserExists(userInput) == true)
            {
                Console.WriteLine("Username already exists. Please enter another username.");
                validUserInput = false;
            }
            else
            {
                Users newUser = UsersLogic.CreateNewUser(userInput);
                Console.WriteLine("Profile created!");
                Console.WriteLine($"Username: {newUser.userName}");
                Console.WriteLine($"UserId: {newUser.userId}");
                validUserInput = true;
            }
        } while (!validUserInput);
    }


    public static void LogInPrompts()
    {
        bool validUserInput;
        string userInput;

        do
        {
            Console.Write("Please enter your username: ");
            userInput = Console.ReadLine() ?? "";
            if(string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username can't be blank. Please try again.");
                validUserInput = false;
            }
            else if (UsersLogic.CheckIfUserExists(userInput) == false)
            {
                Console.WriteLine("Profile does not exist. Please try again.");
                validUserInput = false;
            }
            {        
                Users currentUser = UsersLogic.FindExistingUser(userInput);
                validUserInput = true;
                Console.WriteLine("Profile found! You are now logged in.");
                Console.WriteLine($"Username: {currentUser.userName}");
                Console.WriteLine($"UserId: {currentUser.userId}");
            }

        } while (!validUserInput);
    }

}