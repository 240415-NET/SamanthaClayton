namespace TrackMyStuff.Data;

using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Nodes;
using TrackMyStuff.Models;

public class UserStorage
{

    // This is allowing the filePath to be used by all the methods in this class
    // If I find myself re-using the same string, object, etc., I can go ahead
    // and make it a member of my class.  This way I can reuse this same data
    // without having to continuously re-initialize it.
    // The underscore is a common convention to denote variables that are
    // common to the entire class.

    //The readonly here is making the _filePath variable read only so we can never
    //inadvertently change the exact place that _filePath is pointing to.
    //It's not making the file itself readonly.
    public static readonly string _filePath = "./DataAccess/UsersFile.json";
    // Jonathan's code uses the below instead of the above
    // public static readonly string _filePath = "UserFiles.json";

    // Static means it belongs to the class itself, not to objects created by that class


    // A method to store a user
    public static void StoreUser(User user)
    {
        // String representing our file path and name.
        // This can take just a file name or it can take absolute
        // or relative file paths

        // Filepaths begin at root directory of the application.
        // In our case, this is the TrackMyStuff folder
        // that holds our entire console app.
        // Here we used a relative file path starting at
        // TrackMyStuff to go into our DataAccess folder
        // and create the UsersFile.json inside that folder
        //string filePath = "./DataAccess/UsersFile.json";
                

        // We want to create a JSON file from our method if one
        // does not already exist.
        if(File.Exists(_filePath))
        {

             // We need to de-serialize the existing json text string
            // in our file and store it in our list.

            // Here we will probably read the file for a collection of 
            // users and then add and rewrite the file
            // When we deserialize we have to be explicit with our type,
            // the deserialize method NEEDS to know what kind of object
            // it's going to create


            //Look into the file and get the string rather than trying to
            //deserialize the whole file.  Don't forget to read the actual
            //string from the file BEFORE deserialization

            string existingUsersJson = File.ReadAllText(_filePath);

            //once you get the string from the file, then you can dserialize it
            
            //We could put a ? after List<User> to make it stop warning us
            // that it could be null
            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);
  
            //Once we deserialize the existing JSON text from the file into a new
            //List<User> object, we will then simply add it to the list
            //using the Add() method
            existingUsersList.Add(user);

            // Here we will serialize our list of users into
            // a JSON text string
            
            string jsonExistingUsersListString = JsonSerializer.Serialize(existingUsersList);
            
            // Now we will store our jsonUsersString to our file
            File.WriteAllText(_filePath, jsonExistingUsersListString);
            
        }
        else if (!File.Exists(_filePath)) // The first time the program runs, the file probably doesn't exist
        {
            // Creating a blank list to use later
            List<User> initialUsersList = new List<User>();

            // Adding our user to our list PRIOR to serializing it
            initialUsersList.Add(user);

            // Here we will serialize our list of users into
            // a JSON text string
            
            string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);
            
            // Now we will store our jsonUsersString to our file
            File.WriteAllText(_filePath, jsonUsersListString);

            
            

        }
        
        // If it does, we want to append the object to the file.
        
        // If it doesn't, create the file and store our object.

    }

    public static User FindUser(string usernameToFind)
    {

        //User object to store a user if they are found or a null if they are not

        User foundUser = new User();

        try
        {
            // First, read the string back from our .json file
            string existingUsersJson = File.ReadAllText(_filePath);

            // Then we need to serialize the string back into a list of user objects
            List<User> existingUsersList = JsonSerializer.Deserialize<List<User>>(existingUsersJson);


            // Then we need to check if there is a user object with the given username
            // that came in as an argument when the method was called inside of our list
            // To do this we're going to use a LINQ method to query our collection
            // called FirstOrDefault()
            // Inside the parenthesis is a lambda method or anonymous function
            // Lambda expressions have the same basic syntax
            // The => is called the lambda operator.  It is not actually functioning
            // any sort of comparator.

            // To the left of the lambda operator (=>) is the input to our
            // anonymous function or method

            // To the right of the => is the code that will be executed or
            // against when the lambda runs

            // We tried to use the Where() method, but it was going to potentially return 
            // a collection/list of users with the same name instead of just 1 user

            // Lists have access to LINQ methods.  We use dot notation to call the methods
            // on a list.

            foundUser = existingUsersList.FirstOrDefault(user => user.userName == usernameToFind);

            // The stuff in () above is called the lambda expression.  
            // user is essentially the input parameter for tihs mehod
            // after the => is the condition we're trying to satisfy
            // it's like doing a foreach
            //The above lamda function is essentially iterating through and
            //querying the list for us as if we are doing the foreach loop below
            /*foreach (User user in existingUsersList)
            {
                if (user.userName == usernameToFind)
                {return user;
                }
            }
            */

            // If it exists, return the user
                   


            // If it doesn't do something else




        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);

        }

        return foundUser;


    }





}