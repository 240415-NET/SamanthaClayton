using System.Text.Json;
using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccessLayer;

public class SQLUsersStorage : IUsersStorageRepo
{
    static string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
    string connectionString = File.ReadAllText(path);

    public void StoreNewUser(Users newUser)
    {
            using SqlConnection mySQLConnection = new SqlConnection(connectionString);

            mySQLConnection.Open();

            string SQLCodeToAddNewUser =
                 @"INSERT INTO Users (UserId, UserName)
                 VALUES (@UserId, @UserName);";

            using SqlCommand AddNewUserCommand = new SqlCommand(SQLCodeToAddNewUser, mySQLConnection);

            AddNewUserCommand.Parameters.AddWithValue("@UserId", newUser.userId);
            AddNewUserCommand.Parameters.AddWithValue("@UserName", newUser.userName);

            AddNewUserCommand.ExecuteNonQuery();
            mySQLConnection.Close();
    }


    public Users RetrieveStoredUser(string userNameToFind)
    {
        Users existingUser = new Users("User name not found");

        try
        {
            using SqlConnection myConnectionObject = new SqlConnection(this.connectionString);
            myConnectionObject.Open();
            
            string SQLCodeToRetrieveUser = @"SELECT * FROM Users WHERE UserName = @UserName;";
            
            using SqlCommand RetrieveUserCommand = new SqlCommand(SQLCodeToRetrieveUser, myConnectionObject);
            RetrieveUserCommand.Parameters.AddWithValue("@UserName", userNameToFind);

            using SqlDataReader reader = RetrieveUserCommand.ExecuteReader();
        
            while (reader.Read())
                {
                    Guid userId = reader.GetGuid(0);
                    string userName = reader.GetString(1);
                    existingUser.userId = userId;
                    existingUser.userName = userName;
                }
            myConnectionObject.Close();  

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            
        }

        if (existingUser.userName == "User name not found")
        {
            return null;
        }
        else
        {
            return existingUser;
        }
    }
}