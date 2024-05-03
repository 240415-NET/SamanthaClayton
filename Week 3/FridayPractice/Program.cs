using System.Diagnostics.Metrics;

namespace FridayPractice;

class Program
{
    static void Main(string[] args)
    {
        // If you want to do something 1x, don't need a loop
        int userEnteredNumber = int.Parse(Console.ReadLine());
        Console.WriteLine(userEnteredNumber);


        // If you want to print from 0 to whatever number the user enters
        // int userEnteredNumber = int.Parse(Console.ReadLine());
        Console.WriteLine($"User Typed:{userEnteredNumber}");

        //Do-while:  Do it 1x then repeat until something is no longer true
        //           Do it 1x and repeat WHILE something is true

        int counter = 0;
        do
        {
            Console.WriteLine(counter);
            counter++;
        }
        while (counter <= userEnteredNumber);

        //While Loop

        int counter_forthewhileloop = 0;

        while(counter_forthewhileloop<=userEnteredNumber)
        {
            Console.WriteLine(counter_forthewhileloop);
            counter_forthewhileloop++;
        }


        // For

        for (int counter_fortheforloop = 0; counter_fortheforloop<=userEnteredNumber; counter_fortheforloop++)
        {Console.WriteLine(counter_fortheforloop);
        }




        int[] mynewarray = [5, 10, 12, 20];

        // Console.WriteLine(mynewarray[0]);
        // Console.WriteLine(mynewarray[1]);
        // Console.WriteLine(mynewarray[2]);
        // Console.WriteLine(mynewarray[3]);

        //For

        Console.WriteLine("This is the for loop output");
        for (int i = 0; i <= 3; i = i + 1)
        {
            Console.WriteLine(mynewarray[i]);
        }



        Console.WriteLine("This is the foreach loop output");
        // foreach
        foreach (int element in mynewarray) // This is referring to each item in the array, print it, go to the next item
        {
            Console.WriteLine(element);
        }


        //Do While

        Console.WriteLine("This is the do-while loop output");

        int i_forthedowhileloop = 0;
        do
        {
            Console.WriteLine(mynewarray[i_forthedowhileloop]);
            i_forthedowhileloop = i_forthedowhileloop + 1;
            //^ this is the same as  i_forthedowhileloop++
        } while (i_forthedowhileloop <= 3);



        //While

        Console.WriteLine("This is the while loop output");
        int i_forthewhileloop = 0;
        while (i_forthewhileloop <= 3)
        {
            Console.WriteLine(mynewarray[i_forthewhileloop]);
            i_forthewhileloop = i_forthewhileloop + 1;
        }








    }
}
