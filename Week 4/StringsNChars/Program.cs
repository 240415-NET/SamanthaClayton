using System.Security.Cryptography.X509Certificates;

namespace StringsNChars;
//using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        string string1 = Console.ReadLine();
        Console.WriteLine(string1);

        //Reverses a string 
        string reversestring1 = new string(string1.Reverse().ToArray());
        Console.WriteLine(reversestring1);

        string string2 = "hello";
        var string2letter1 = string2[0];
        string2letter1 = 'i';
        Console.WriteLine(string2);
        string firstletter = Convert.ToString(string2[0]);
        Console.WriteLine(firstletter);
        string firstletteragain = "";

        // Convert a char into an int where a = 1, b = 2, c = 3, etc.
        char character = new char();
        character = 'L';
        character = char.ToLower(character);
        int charactervalue;
        charactervalue = character - 'a' + 1;
        Console.WriteLine(charactervalue);

        // Another way, but you just have to know to subtract off the integer value of 'a'

        char character2 = new char();
        character2 = 'm';
        char character3 = new char();
        character3 = 'M';
        int charactervalue2;
        charactervalue2 = Convert.ToInt32(character2);
        int charactervalue3;
        charactervalue3 = Convert.ToInt32(character3);
        Console.WriteLine("m int value: "+ charactervalue2);
        Console.WriteLine("M int value: " +charactervalue3);

        Console.WriteLine("a Int value: "+Convert.ToInt32('a'));


        string string8 = Console.ReadLine();
        char[] charArrayofString8 = string8.ToCharArray();
        Array.Reverse(charArrayofString8);
        string reversestring8 = new string(charArrayofString8);

        if (string8 == reversestring8)
        {
            Console.WriteLine("Palindrome");
        }
        else
        {
            Console.WriteLine("Not A Palindrome");
        }


List<string> myList = ["item 1 in list", "item 2", "item 3"];
Console.WriteLine("# of in my list: "+myList.Count());
Console.WriteLine("Item 1: "+myList[0]);

string[] myArray = ["item 1 in array", "item 2", "item 3", "item 4"];
Console.WriteLine("# of items in my array: " +myArray.Count());
Console.WriteLine("Item 1: "+myArray[0]);

string myString = "hello";
char[] myCharArrayformyString = myString.ToCharArray();
Console.WriteLine($"{myString} has {myString.Length} letters");

Console.WriteLine(myArray[0].Length);




        


    }
}
