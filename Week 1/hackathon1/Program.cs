using System.Net.Quic;

namespace hackathon1;
// Create a C# console app with the following requirements
// 1. Prompt the user for some input
// 2. Do something with the input
// 3. Handles exceptions
// 4. Continues to run until the user quits the app from within the app
//      (no CTRL + C to exit)

class Program
{
    static void Main(string[] args)
    {
        bool keepGoing= true;
      
        do
        {
        int maxValue = 0;

            Console.WriteLine("Provide a maximum value or Q to quit");
            string userInput = Console.ReadLine().ToUpper();
            if (userInput == "Q")
            {
                keepGoing = false;
            }
            else
            {
                try
                {
                    maxValue = Convert.ToInt32(userInput);
                }
                catch (Exception e)
                {
                    Console.WriteLine("BAD USER (invalid input)");
                }
            }

        for(int i=1; i<=maxValue; i++)
		{
			if (i%3 == 0 && i%5 == 0)
			{
				Console.WriteLine("fizzbuzz");
			}
		else if(i%3 == 0)
			{
			Console.WriteLine("fizz");
			}
		else if (i%5 == 0)
			{
			Console.WriteLine("buzz");
			}
		else 
	    	{
			Console.WriteLine(i);
		    }
		}
        }
        while (keepGoing == true);
	}
}
