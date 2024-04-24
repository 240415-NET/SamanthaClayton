// using ClassBasics.Classes;

// namespace ClassBasics;

// public class Program
// {
//     public static void Main(string[] args)
//     {
//        ExampleClass exampleClass; //Declaration

//        exampleClass = new ExampleClass(); //Setting through instantiation

//        exampleClass.Age = 55; //Updating

//        //Initialization is all of this at once ^



//          //This is how you use the object initalizers by bypassing the constructors

//         /*ExampleClass exampleClass = new ExampleClass{Name = "Ryan",
//             Age = 30};
//         */
//        //accessing it directly -- this will not ocmpile because we are
//        //accessing a private variable
//        // exampleClass.Name = "Hello";

//         //passing it off to the object
//         exampleClass.SetName("Hello");

//         exampleClass.Age =55;//this works because the age field is public

//         //I thikn you can't do this Console.WriteLine(exampleClass.MAX_LIMIT);
//         Console.WriteLine(exampleClass.GetMaxLimit());


//         //Person Class Examples

//         Person personA = new Person();
//         Console.WriteLine(personA.GetFirstName());
//         Console.WriteLine(personA.GetLastName());
//         Console.WriteLine(personA.GetEmail());
//         Console.WriteLine(personA.GetAge());
//         Console.WriteLine(personA.GetOnHoliday());
//         personA.SetFirstName=""; //will default to John because
//         //of the default in the setter


//         Person personB = new Person();
//         personB.SetFirstName("Brian");
//         personB.SetLastName("Jones");
//         personB.SetEmail("brian@jones.com");

//         Person personC = new Person("Jane", "Smith", "jane.smith@email.com", 33, true);
//         Console.WriteLine(personC.GetFirstName());
//         Console.WriteLine(personC.GetLastName());
//         Console.WriteLine(personC.GetEmail());
//         Console.WriteLine(personC.GetAge());
//         Console.WriteLine(personC.GetOnHoliday());

        
//         Console.WriteLine(personB.GetFirstName());
//         Console.WriteLine(personB.GetLastName());


//         Console.WriteLine(personC.ToString());

// List<Person> people = new List<Person>();

// people.Add(personA);
// people.Add(personB);
// people.Add(personC);

// foreach(var person in people)
// {
//     Console.WriteLine(person);
// }


// Console.WriteLine(people);

        
//     }
// }
