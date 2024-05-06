namespace SettersandGettersPractice;

class Program
{
    static void Main(string[] args)
    {
        User newUser = new User();
        newUser.name_nogetset = "Bob - No Get Set";
        newUser.name_simplegetset2 = "Bob - Simple Get & Set";
        newUser.name_shorthandsimplegetset = "Bob - Shorthand Simple Get & Set";
        //newUser.name_setrequirescapital1stletter = "bob - Requires capital 1st letter";
        // Can't do this because the set is private:
        //newUser.name_publicattribute_privateset = "Bob";
       
       Console.WriteLine(newUser.name_nogetset);
       Console.WriteLine(newUser.name_simplegetset2);
       Console.
       Console.WriteLine(newUser.name_shorthandsimplegetset);
       //Console.WriteLine(newUser.name_setrequirescapital1stletter);

    }
}



public class User
{
    public string? name_nogetset;
    public string? name_simplegetset;
    public string? name_simplegetset2
        {
        get {return name_simplegetset;}
        set {name_simplegetset = value;}
        }
    
    
    public string? name_shorthandsimplegetset {get; set;}
}
    /*

    public string? name_setrequirescapital1stletter
        {
            get {return name_setrequirescapital1stletter;}
            */
            /*set
            {
                if (!string.IsNullOrEmpty(value) && char.IsLower(value[0]))
                {
                    throw new ArgumentException("Username must start with a capital letter.");
                }
                else
                {
                    name_setrequirescapital1stletter = value;
                }
                */
           // }   
    
        

// Cannot have a private attribute with a public get and set because
// Get and set must be more restrictive
/*  private string? name_privatestringpublicgetset
        {
            public get;
            public set;
        }
*/

    /*public string? name_publicattribute_privateset
        {
            get;
            private set;
        }*/
//}


