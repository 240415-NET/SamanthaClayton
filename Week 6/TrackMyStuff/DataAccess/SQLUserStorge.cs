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
    // If I moe my entire project directory, this file path will still
    // work because it's an exact address to my connection string
    // Because of Windows file paths vs. Linux file paths having different
    // forward and back slashes and escape characters, @ is ignore all of that


    public static string connectionString = File.ReadAllText(@"C:\Users\u41046\Revature Engineer Bootcamp\TrackMyStuffConnectionString.txt");

    public User FindUser(string usernameToFind)
    {
        throw new NotImplementedException();
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