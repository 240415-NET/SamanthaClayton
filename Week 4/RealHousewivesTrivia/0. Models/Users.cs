namespace RealHousewivesTrivia.Models;

public class Users {
    private Guid userId {get;} //needed to add get; in order for json to store the value
    private string userName {get;} //needed to add get; in order for json to store the value

   // {
        //get {return userName;}
        //set {userName = value;}
    //};//{get;}//needed to add get; in order for json to store the value
    
    public Users(){}

    public Users(string _userName)
    {
        userId = Guid.NewGuid();
        userName = _userName;
    }

}