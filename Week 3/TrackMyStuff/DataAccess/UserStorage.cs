namespace TrackMyStuff.Data;

using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Nodes;
using TrackMyStuff.Models;

public class UserStorage
{
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
        string filePath = "./DataAccess/UsersFile.json";
                

        // We want to create a JSON file from our method if one
        // does not already exist.
        if(File.Exists(filePath))
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

            string existingUsersJson = File.ReadAllText(filePath);

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
            File.WriteAllText(filePath, jsonExistingUsersListString);
            
        }
        else if (!File.Exists(filePath)) // The first time the program runs, the file probably doesn't exist
        {
            // Creating a blank list to use later
            List<User> initialUsersList = new List<User>();

            // Adding our user to our list PRIOR to serializing it
            initialUsersList.Add(user);

            // Here we will serialize our list of users into
            // a JSON text string
            
            string jsonUsersListString = JsonSerializer.Serialize(initialUsersList);
            
            // Now we will store our jsonUsersString to our file
            File.WriteAllText(filePath, jsonUsersListString);

            
            

        }
        
        // If it does, we want to append the object to the file.
        
        // If it doesn't, create the file and store our object.






    }




}