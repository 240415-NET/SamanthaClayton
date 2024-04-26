using System.Drawing;

namespace ExampleConsole;

//Creating a class named thinga_ma_bobs
public class thinga_ma_bobs
{
    //Here are the fields that will be part of the thinga_ma_bobs class
    string AttributeColor = "Default class color";
    
    //Constructor 1:  (Implied, Hidden) No-Args or No Arguments Constructor
    //Automatically generated blank constructor that's hidden.
    //Gets created for every class you make without you having to type it or even see it
    //But you CAN type it if you want to
    //public thinga_ma_bobs(){}
    //If you create another constructor for this class, you will eliminate this
    //hidden, implicit constructor altogether.
  
    //Constructor 2:
    //Here we are going to set the rules for how to create an object of type thinga_ma_bobs
    //There are 2 parts to this:
    //1.  Dictate what the person creating an object has to provide you if they want to use this constructor
    //      classname(parametertype paramatername) << You tell whoever wants to use this constructor that they have to pass
    //      a parameter in order to use it
    //2.  Okay, since you're using this specific constructor, here's how we'll create an object using it
    //      {this is where you specify what will happen when someone uses this constructor} << inside the {}
    
    public thinga_ma_bobs(string ColorTheUserPassesUs) 
    //^ this is saying "if you want to use this constructor, ya gotta give us a
    //parameter named ColorTheUserPassesUs and it's gotta be a string"
    { 
        AttributeColor = ColorTheUserPassesUs;
        //^ this is saying
        //"since you're using this specific constructor, here's how we're going
        //to create an object.  We'll set the object's AttributeColor to
        //the ColorTheUserPassesUs"
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
