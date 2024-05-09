namespace WednesdayPractice;
using System.Linq;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {

        string[] myArray = {"bthing1", "athing2", "thing3"};

        Array.Sort(myArray);
        foreach (string thing in myArray)
        {Console.WriteLine(thing);}

        int length = myArray.Length;
        int count = myArray.Count();



        Console.WriteLine(length);
        Console.WriteLine(count);

        List<string> myList = ["bobby", "adam", "tom"];
        Console.WriteLine(myList[0]);
        Console.WriteLine(myList.Count());

  

    }
}
