namespace IntroClass;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dog pancake = new Dog();

        //Here we call an instance method - this method needs
        //an object of type Dog to be called
        pancake.Bark();

        //Can't do pancake.DefineDog() because it doesn't belong to the instance
        //of this class dog.  It belongs to the class itself.
        
        Dog.DefineDog();

    }
}

