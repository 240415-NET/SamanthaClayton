using TrackMyStuff.Models;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace TrackMyStuff.Data;

public class SQLUserStorage : IUserStorageRepo
{
    // We need to read the connection string here
    // Just like in the Json version, we have the
    // filepath that's visible to the whole class
    // We can do that with the connection string

    
    // The @ symbol treats it as a verbatim string literal
    // Ignore all issues related to the slashes with Windows file paths 
    // and using an absolute file path, starting from my C drive to avoid
    // any relative file path issues
    // If I move my entire project directory, this file path will still
    // work because it's an exact address to my connection string
    // Because of Windows file paths vs. Linux file paths having different
    // forward and back slashes and escape characters, @ is ignore all of that


    public static string connectionString = File.ReadAllText(@"C:\Users\u41046\Revature Engineer Bootcamp\TrackMyStuffConnectionString.txt");

    public User FindUser(string usernameToFind)
    {
       // Just like in the JsonUserStorage method, we will create an empty user
       // to hold a potential user we find in our DB
        User foundUser = new User();
            // Just like with our INSERT, we will create a 
            // SQLConnection object

            using SqlConnection connection = new SqlConnection(connectionString);

        try
        {

            // We then open the connection
            connection.Open();

            // We start creating our command/query text
            // He said to expliclty tell is te specific columns you want and in
            // the order you want it.  And to explicitly tell it dbo.tablename
            // so there's no ambiguity
            string cmdText = @"SELECT userId, userName 
                                FROM dbo.Users
                                WHERE userName = @userToFind;";

            // We create our SQLCommand object
            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            // We then fill in the parameter @userToFind with our 
            // string userNameToFind thta comes in as an argument to our method
            cmd.Parameters.AddWithValue("@userToFind", usernameToFind);

            // To execue a query, we need to use a SqlDataReader object
            // This object reads whatever is returned from our query, row by
            // row - column by column
            // As the reader passes over the columns and rows, we need to take steps
            // to store or work with the data that comes back.
            // Once the reader moves on fro ma row, we would need to execue
            // the command again to re-read the row.
            // It is forward only!  No going back up to another row we have already passed.

            // We are going to use a while-loop to read through our data coming back
            // from our SqlDataReader and execute code until it is done reading.

            using SqlDataReader reader = cmd.ExecuteReader();
            // This will create a sql data reader beased on our command that we've already fleshed out
            // and store it as reader.  The cmd.ExecuteReader() sends the command text and everything it would
            // need and we send it off and it returns a new SQLDataReader.  It builds it for us and
            // returns it to the new SQLDataReader.
            while (reader.Read())
            {
                //While we are on a particular row, we have to save stuff if we find it
                //When using reader.GetType() methods, we have to specify which
                // columns we are targeting via an index.  Like arrays, these start at position 0.
                foundUser.userId = reader.GetGuid(0);
                foundUser.userName = reader.GetString(1);

            
            }
            // once we're done reading and no more records are coming back to be read, we exit the while loop
        
        //If we get to this point and found a user, we return the filled out user object

        //Option 1:  If the username on foundUser is empty, we manually return a null 
        /*if(string.IsNullOrEmpty(foundUser.userName))
        {return null;
        }*/

        //Option 2:  If the userId on foundUser is empty, we manually return a null.
        if (foundUser.userId == Guid.Empty)
        {return null;}
        
        //Otherwise, we return the found filled out user object
        return foundUser;

        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally // We will leverage the finally block to close our connection in case
                // either nothing is found or we actually catch some exception
        {
            // Close our connection if we find nothing or if something bad happens
            connection.Close();

        }
        // We may never actualy hit this?  Warrants futher investigation
        return null;
    }

    public void StoreUser(User user)
    {
        // Create a SQLConnection object to be able to connect to our database
        // We want this object to be "disposable" - that is to say, we want it to be
        // destroyed or de-referneced as soon as this method is done executing
        // We do this with a "using" statement.

        using SqlConnection connection = new SqlConnection(connectionString);
        //sqlConnection connection = new SqlConnection(connectionString);
        // Could do this way, but if you have enough people using it, you could
        // run out of ports.  You're creating a lasting connection.  So you want to
        // make sure that once you're done, the connection gets scrubbed.  So do
        // using to prevent that issue.

        //After e create our connection object, we call an instance method called
        // Open() to open the connection
        connection.Open();

        // After this, we start to create our command. We can do this with a templated
        // strng as shown below.
        // Doing this we we can avoid any issues with SQL injection, as well as not
        // have to mess with manual string concatenation
        string cmdText = @"INSERT INTO dbo.Users (userId, userName)
                            VALUES (@userId, @userName);";


        //We use the connection we created and opened as well as the command text
        // template that we created above to create a new SQLCommand object
        // that we will eventually send to do stuff on our database
        using SqlCommand cmd = new SqlCommand(cmdText, connection);

        // Now that we have our SQLCommand object, in thi case named cmd, 
        // we can call a method AddWithVaue() to fill out the templated
        // INSERT command string
        // We call this a little differently than other instance methods
        // because we are reaching deeper into the cmd object.
        cmd.Parameters.AddWithValue("@userId", user.userId);
        cmd.Parameters.AddWithValue("@userName", user.userName);

        // We then execute our INSERT statement that we created
        // and fleshed out above by running the instance method
        // ExecuteNonQuery() off of our cmd object.

        cmd.ExecuteNonQuery();

        //Once that is done, we simply cloes the connection
        connection.Close();


    }

}