namespace thursdayProgram;
// Goal:  Build a console app that prints the numbers 1 to 100
// to the console, but
// a) for each number divisible by 3, it prints "fizz"
//      instead of that number.
// b) for each number divisible by 5, it prints "buzz"
//      instead of that number, &
// c) for each number divisible by both 3 & 5, it prints
//      "fizzbuzz" instead of that number
class Program
{
    static void Main(string[] args)
    {
        for(int i=1; i<101; i++)
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
}
