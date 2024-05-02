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


    // This method handles the prompts for creating a new user profile
    public static void UserCreationMenu()
    {
        // We want to ask for a user name

        
        // We want to make sure the user didn't just hit enter 
        // and provide an empty string.

        // We want to call the Controller's UserExists() method
        // to see if a given user name is already taken

        // If it is taken, we prompt the user to try again with a
        // new username

        // Pass the username to the controller


        /*
            Let's sketch out the logic here

            We are going to need a boolean "flag"

            Do-while loop checking against our flag
            {
                check if the given input is null or empty
                    if-else to check if our input is null or empty

                assuming the input is valid according to our
                business rules (since we set the requirement
                that we cnanot have a blank username), we then want
                to check that a given uesrname exists using the
                UserExists method in the UserController

                    if the name isn't taken, great
                    if the name is taken, prompt user to try again
            }
            We stay in the do-while until the input passes
            both checks


        */
        
        //Declaring our flag boolean outside of our loop
        
        bool validInput = true;
        string userInput = "";

        do
        {
            // Prompting the user for a uesrname
            
            Console.WriteLine("Please enter a username: ");

            // The ?? "" after Console.ReadLine() gets rid of a
            // warning.  If it's null, then it's an empty string.
            // The ?? is called the null-coalescing operator
            // If the input comes back null, then we manually set it
            // to an empty string to avoid the posisbility of this
            // userInput string every being null.
            userInput = Console.ReadLine() ?? "";

            // Here we are going to trim the string to remove
            // any leading or trailing spaces
            userInput = userInput.Trim();


            // If-else to check both of our conditions - empty string and existing username
            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank; please try again.");
                validInput = false;
            } else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists.  Please choose another.");
                validInput = false;
            } else //If neither check trips, we simply call CreateUser from the User Controller
            {
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created!");
                validInput = true;
            }

        } while(!validInput); // Continue running the above block UNTIL input is valid
    }


}