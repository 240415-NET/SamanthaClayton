using System.Diagnostics.CodeAnalysis;
using System.Security.Authentication;
using System.Security.Principal;

namespace MethodExceptionDemo;

class Program
{
    static void Main(string[] args)
    {
        //This is a flag for demo that will be set to true
        //if we catch an excpetion and entr our catch block
        //of code
        bool caught = false;

        try  //the code we want to make sure doesn't crash our application
        {
            Console.WriteLine("Please enter a number:");
            int firstNum = Convert.ToInt32(Console.ReadLine());
        
            Console.WriteLine("Please enter a number:");
            int secondNum = Convert.ToInt32(Console.ReadLine());

            //This sum we're defining here is a distinct
            //sum from the sum in the method below.
            int sum = AddTwoNumbers(firstNum, secondNum);

            Console.WriteLine($"The sum of {firstNum} and {secondNum} is: {sum}");

        }
        //catch (FormatException exceptionaboutformatting)
        // {
        // }
            
        catch(Exception myException) //catch a potential exception & if so, do something
        {
            //Console.Clear;
            Console.WriteLine($"{myException.Message}");
            Console.WriteLine($"{myException.StackTrace}");
            Console.WriteLine("Please make sure you enter an integer value!");

            caught = true;
        }
        finally  // optional, this runs regardless of whether an exception is caught or not
        {
            if(caught)
            {
                Console.WriteLine("Program successfully finished despite the exception!");
            } else 
            {
                Console.WriteLine("Program ran without exceptions");
            }
        }
    }
    //end main scope

    // create a method to add two numbers
    // method signature:  access_modifier return_type method_name(arguments)
    // arguments are given a type and a name like a field/variable
    static int AddTwoNumbers (int num1, int num2)
    {

        //I can access arguments passed into
        //my method within the method's block of code
        int sum = num1 + num2;

        
        return sum;
    }
    //end AddTwoNumber scope
}
