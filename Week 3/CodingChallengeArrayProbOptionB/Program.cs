using System.ComponentModel.DataAnnotations;

namespace CodingChallengeArrayProb;

class Program
{

    public static void Main()
    {
        string[] inputArray = Console.ReadLine().Replace("[","").Replace("]","").Split(",");
        int[] intArray = new int[inputArray.Length];
        for(int i=0;i<intArray.Length;i++)
        {
            intArray[i]=Int32.Parse(inputArray[i]);
        }

        int min = intArray[0];

        foreach (int value in intArray)
            {
            if (value < min)
            min = value;
            }
        

        Console.WriteLine(min);

    }



}
