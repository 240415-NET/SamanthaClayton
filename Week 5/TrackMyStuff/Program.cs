namespace TrackMyStuff.App;

using TrackMyStuff.Models;
using TrackMyStuff.Presentation;

class Program
{
    static void Main(string[] args)
    {
        // Can't do this because we made the attribute's set method private
        // User myUser = new User();
        // myUser.userId = 0;
        // Console.WriteLine(myUser.userId);

        Menu.StartMenu();
        
    }
}