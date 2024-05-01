using System.ComponentModel.DataAnnotations;

namespace CodingChallengeArrayProb;

class Program
{

    public static int findMin(int[] intArray)
    {
        // Look at the array that is given to us
        // It's called intArray
        // Take the 1st element in intArray and assign
        // it's value to a new integer variable named min
        int min = intArray[0];

        foreach (int value in intArray)
            {
            if (value < min)
            min = value;
            }

        return min;

    }


    public static void Main()
    {
        string[] inputArray = Console.ReadLine().Replace("[","").Replace("]","").Split(",");
        int[] intArray = new int[inputArray.Length];
        for(int i=0;i<intArray.Length;i++)
        {
            intArray[i]=Int32.Parse(inputArray[i]);
        }

        Console.WriteLine(findMin(intArray));


    }



}
