using System.Drawing;

namespace ExampleConsole;

//Creating a class named thinga_ma_bobs
public class thinga_ma_bobs
{
    //We are creating a class and here we are defining the fields in that class
    string AttributeColor = "You can a set the class default color";
    
    //Constructor 1:  Implied, Hidden No-Args or No Arguments Constructor
    //Automatically generated blank constructor that's hidden
    //Gets created for every class you make without you having to type it or even see it
    //But you CAN type it if you want to
    //public thinga_ma_bobs(){}
    //If you create another constructor for this class, you will eliminate this
    //hidden, implicit constructor altogether.
  
    //Constructor 2:
    //Here we are going to set the rules for how to create an object of type thinga_ma_bobs
    //We're essentially saying "If you wanna create a new object of type thinga_ma_bobs, you have to pass a string"

    public thinga_ma_bobs(string ColorTheUserPassesUs)
    { 
        AttributeColor = ColorTheUserPassesUs;
    }

    //Constructor 3:  No-Args or No Arguments Constructor
    // Because we created our constructor (Constructor 2), it overrode the implicit
    //constructor that lets a developer create an object of type thinga_ma_bobs without providing
    //any parameters.  So if we want to let a developer create an object of type thinga_ma_bobs
    //without requiring that they provide a string for UserInputColor, we can explicitly
    //write out the blank constructor for this clsas.
    public thinga_ma_bobs()
    {

    }

    //This is an example of method overloading.  Method overloading is when you
    //create a method that has a set of parameters (or none at all) and then you creae
    //another method with the same name that has a different set of parameters.
    
    
}


//Creating an item of type thinga_ma_bobs
class Program
{
    static void Main(string[] args)
    {

        //Use Constructor 2 (you have to include a color here)
        thinga_ma_bobs Pinkthinga_ma_bob = new thinga_ma_bobs("pink");

        //Use Constructor 3
        thinga_ma_bobs mynewthinga_ma_bob = new thinga_ma_bobs(); //thingsa_ma_bobs() is calling the thinga_ma_bobs constructor



    }
}
