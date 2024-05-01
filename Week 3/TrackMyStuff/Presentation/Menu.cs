using System.Runtime.Intrinsics.Arm;
using TrackMyStuff.Controllers;

namespace TrackMyStuff.Presentation;

public class Menu
{

    // This method displays the initial menu when the use rruns the program
    public static void StartMenu(){
        
        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to TrackMyStuff!");
        Console.WriteLine("1. New user");
        Console.WriteLine("2. Returning user");
        Console.WriteLine("3. Exit program");

        // Setting up the try-catch to handle the user input with
        // do-while to let them try again

        do{
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch(userChoice)
                {
                    case 1: // Creating a new user profile
                        UserController.CreateUser();
                        break;

                    case 2:
                        break;

                    case 3:
                        return; // If you put a return, exit this method and go back to wherever called it.
                        
                    default:  // If the uesr enters an integer that is not 1, 2, or 3
                        Console.WriteLine("Please enter a valid choice!");
                        validInput = false;
                        break; // breaks us out of the switch, there's no more of the switch, so we continue the try, there's nothing else, so we 
                }
            }
            catch (Exception ex)
            {
                validInput = false;
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice!");
            }
            
        } while(!validInput);
    }


}