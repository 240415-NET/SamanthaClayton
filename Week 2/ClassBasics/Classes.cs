// using System.IO.Pipes;

// namespace ClassBasics.Classes
// {
//     public class ExampleClass
//     {
//         //Fields
//         //Instance fields: unique to each instance of a type
//         //Allowing individual objects to maintain distinct values

//         public string exampleString;

//         //Static Fields
//         // Belong to the type/class itself
//         //Shared across all instances
//         //Accessible only through the type name

//         public static int instanceCount;
        
//         //Access modifiers:
        
//         //public
//         //private - only accessible within the object itself
//         //internal - only accessible within the assembly itself
//         //protected - only accessible to the children of the class and the class itself

//         //
//         //readonly modifier (not an access modifier)
//         //can only be assgned during initalization or in the constructor
//         //this is an example of making a constant because once it's created
//         //it can only be read
//         //could also write the name of the field in all caps, making it private

//         private readonly int MAX_LIMIT = 300;

//         //You cannot have a set method because it's a readonly
//         //field, but we can define a get method.
//         public int GetMaxLimit()
//         {
//             return this.MAX_LIMIT;
//         }

       
//         //Object Initializers
//         //Allow properties to be initalized directly without calling constructors explicitly
//         //{get;set;} and then you use them in Program.cs


//         //Define a field named Name
//         //& make it private
//         //This makes it so that you can't 'get' this using
//         //objectname.Name and you can't 'set' it using
//         //objectname.Name = "Bob"

//         private string Name {get; set;}
    

//         //Property 
//         //These are a pattern of fields in classes
//         //public datatype name
//         //These properties can have the shorthand{get; set;}
//         //if you want the get; set; shorthand, can't use readonly
//         public int Age {get;set;}

//         /* Getter and Setter
//         Below is an example of encapsulation as you are limiting the fields to private 
//         and allowing acess to it explicitly through methods that you
//         have created yourself*/
//                 /* The above is shorthand for the following
//                 public string GetName()
//                 {
//                     return this.Name;
//                 }

//                 public void setName(string Name)
//                 {
//                     this.Name = Name;
//                 }
//             */


//         //^ the 'get' and 'set above ar ethe reason we can go to the
//         //program.cs and do ExampleClass newexampleclass = new ExampleCass {Name = "ryan", age = 30}

// public string GetName()
// {
//     return this.Name.ToUpper();
// }

// public void setName (string Name)
// {
//     this.Name = Name.Trim();
// }



//     }

// //this would be overridden by the class outside of the namespace
// //    public class OutsideNameSpaceClass
// //  {}

// public class Person
// {
//     private string FirstName = "John";
//     private string LastName = "Doe";
//     private string Email = "john.doe@gmail.com";
//     private int Age = 18;
//     private bool OnHoliday = false;

//     /* Constructor
//     Constructors in C# are special methods used to
//     initalize a new instace of a class.  They are called at the time an object
//     is created and can be used to set an initial vaues or
//     perform any setup required before hte object is used
//     */
//     /* gets used ith the new keyword 
//     no return types (not a void one either)
//     must be the same name as the class */
// //This is the default ocnsturctor created for us when we run our code.  It will
// //do nothing other than instantiate the object.  It returns an object that's created

//     public Person()
//     {
//     }

//     //The constructor is a unique method called when we use the 'new'keyword
//     //when we use new Person(), the new keyword explicitly invokes the constructor


//     public Person(string firstName, stringLastName, string Email, int Age, bool OnHoliday)
//     {
//         // this.FirstName = FirstName;
//         // this.LastName = LastName;
//         // this.Email = Email;
//         // this.Age = Age;
//         // this.OnHoliday = OnHoliday;

//         //could also do
//         SetFirstName(FirstName);
//         SetLastName(LastName);
//         SetEmail(Email);



//     }
    

//     //Design patterns are repeated patterns throughout
//     //programming languages that are repeated often enough
//     //that it is known by a specific name or phrase
    
//     //Getters and Setters are dedign patterns
//     //Getters are responsible for retrieving the value from an object
//     //Typically, this is for a private field in order to enforce
//     //encapsulation.
//     //If the field were to be public, then someone could directly update or
//     //set the field.  objectname.fieldname 

//     //The 'this' keyword' is used to refer to the object that has been
//     //created
//     public string GetFirstName()
//         {
//         return this.FirstName;
//         }

//     public void SetFirstName(string FirstName)
//         {
//         if(FirstName.Count() == 0)
//                 {
//                     return;
//                 }
//         this.FirstName = FirstName.Trim();
//         }

//     public string GetLastName()
//         {
//         return this.LastName;
//         }

//     public void SetLastName(string LastName)
//         {
//             if(LastName.Count() ==0)
//                 {
//                     return;
//                 }
//         this.LastName = LastName.Trim();
//         }
  
//    public string GetEmail()
//         {
//         return this.Email;
//         }

//     public void SetEmail(string Email)
//         {
//         this.Email = Email;
//         }

//        public string GetAge()
//         {
//         return this.Age;
//         }

//     public void SestAge(string Age)
//         {
//         this.Email = Email;
//         }



//         public override string ToString()
//         {
//             return $"FirstName: {FirstName}\nLastName: {LastName}\n
//             Email: {Email}\nAge:{Age}\nonHoliday:{onHoliday}"
//         }()
//     }
// }



// //If a class is outside of a namespace, it becomes globaly accessible
// //and will override bheaviors of other classes within the namespace
// class OutsideNameSpaceClass
// {

// }