using Project1.LogicLayer;
using Project1.Models;

namespace Project1.PresentationLayer;

public class UserProfileUI
{
    public static Guid CreateNewUserPrompts()
    {
        bool validUserInput;
        string userInput;
        Guid userId = Guid.NewGuid();
        Users newUser;

        // Have the new user provide a username.  If the username is blank or already exists, alert the user and have them try again.
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
                newUser = UsersLogic.CreateNewUser(userInput);  // This kicks off the process of storing the new user
                Console.WriteLine("Profile created!");
                Console.WriteLine($"Username: {newUser.userName}");
                Console.WriteLine($"UserId: {newUser.userId}");
                validUserInput = true;
                userId = newUser.userId;
            }
        } while (!validUserInput);
        Console.WriteLine("Hit enter to continue.");
        Console.ReadLine();
        Console.Clear();
        return userId;

    }


    public static Guid LogInPrompts()
    {
        bool validUserInput;
        string userInput;
        Guid userId = Guid.NewGuid();

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
            else
            {        
                Users currentUser = UsersLogic.GetExistingUser(userInput);
                validUserInput = true;
                Console.WriteLine("Profile found! You are now logged in.");
                Console.WriteLine($"Username: {currentUser.userName}");
                Console.WriteLine($"UserId: {currentUser.userId}");
                userId = currentUser.userId;
            }

        } while (!validUserInput);
        Console.WriteLine("Hit enter to continue.");
        Console.ReadLine(); 
        Console.Clear();
        return userId;
    }



}