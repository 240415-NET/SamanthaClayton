using System.Text.Json;
using Project1.Models;
using System.Data.SqlClient;

namespace Project1.DataAccessLayer;

public class SQLUsersStorage : IUsersStorageRepo
{

    /* Things to look into:
    1. What is the benefit of having this stuff below instead of what I have?
            private readonly string _connectionString;
            public SQLMealsStorage(string connectionString)
                {
                    this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
                }
    2. Is there a nice way to check if a SQL table exists?  (For Json, we checked if the filepath existed and if not, we creae
        a new json file.  Is there something similar in SQL?)
    3.

    */

    static string path = @"C:\Users\u41046\Revature Engineer Bootcamp\SamanthaClayton\Projects\Project 1\Project 1\ConnectionString.txt";
    string connectionString = File.ReadAllText(path);

    public void StoreNewUser(Users newUser)
    {
        /*if(File.Exists(_filePath))
        {

            using SqlConnection mySQLConnection = new SqlConnection(connectionString);
            mySQLConnection.Open();

            string SQLCodeToAddNewUser =

                 @"INSERT INTO Users (UserId, UserName)
                 VALUES (@UserId, @UserName);";

            using SqlCommand AddNewUser = new SqlCommand(SQLCodeToAddNewUser, mySQLConnection);

            AddNewUser.Parameters.AddWithValue("@UserId", newUser.userId);
            AddNewUser.Parameters.AddWithValue("@UserName", newUser.userName);

            myCommandForRecipeNamesTable.ExecuteNonQuery();
            mySQLConnection.Close();

/*
        }
        else if (!File.Exists(_filePath))
        {*/
            using SqlConnection mySQLConnection = new SqlConnection(connectionString);

            mySQLConnection.Open();
       /*     string SQLCodeToCreateNewUsersTable =
                @"CREATE TABLE Users(
                UserId UNIQUEIDENTIFIER NOT NULL,
                UserName NVARCHAR(255) NOT NULL
                );";

            using SqlCommand CreateNewUsersTableCommand = new SqlCommand(SQLCodeToCreateNewUsersTable, mySQLConnection);

            CreateNewUsersTableCommand.ExecuteNonQuery();*/


            string SQLCodeToAddNewUser =

                 @"INSERT INTO Users (UserId, UserName)
                 VALUES (@UserId, @UserName);";

            using SqlCommand AddNewUserCommand = new SqlCommand(SQLCodeToAddNewUser, mySQLConnection);

            AddNewUserCommand.Parameters.AddWithValue("@UserId", newUser.userId);
            AddNewUserCommand.Parameters.AddWithValue("@UserName", newUser.userName);

            AddNewUserCommand.ExecuteNonQuery();
            mySQLConnection.Close();
            
        //}
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


        /*try
        {
            string usersInStorageJSON = File.ReadAllText(_filePath);
            List<Users> usersInStorageList = JsonSerializer.Deserialize<List<Users>>(usersInStorageJSON);
            existingUser = usersInStorageList.FirstOrDefault(findmyuser => findmyuser.userName == userNameToFind);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }*/
    }




}