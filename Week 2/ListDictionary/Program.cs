using System.Reflection.Metadata.Ecma335;

namespace ListDictionary;

class Program
{
    static void Main(string[] args)
    {

        //Dynamically sized collection of objects of a single type.  Can 
        //hold duplicate values.
        List<string> cityList = new List<string>();
        
        cityList.Add("Miami");
        cityList.Add("Tampa");
        cityList.Add("Sarasota");
        cityList.Add("Chicago");
        cityList.Add("Clearwater");

       //For each city of type string in citylist, do something

        foreach(string city in cityList)
        {
            Console.WriteLine(city);
        }

       //This city (an accesser variable) is just within this foreach.
       //It's like a temporary field we use for each individual item
       //in this list.  So later, you can't just use city = "someotherstring";
       //because it's only in thie scope.
       
       //Dictionary - This is a dynamically sized collection that holds
       //key-value pairs.
       //Keys must be unique.
       //Keys can also be of any type - as long as it fits the type of the dictionary

        Dictionary<string, string> simplePets = new Dictionary<string,string>();
        simplePets.Add("Jonathan", "Ellie");
        simplePets.Add("Ross", "Brodie");
        simplePets.Add("Mike", "Carl");
        simplePets.Add("Marcus", "Carl");

        //This is an example of implicity typing using var in 
        //C#.  For each 'whaever the heck' the consider considers
        //one of the keys, call it a hosehold and let me do something with it.
        //Could also do foreach(KeyValuePair<string,string> household in simplePets
        foreach (var household in simplePets)
        {
            //Console.WriteLine(household.GetType());
            Console.WriteLine(household.Key + " owns " + household.Value); 
        }
        //These 2 foreach loops are functionally equivalent, one is just explicitly typed.

        foreach (KeyValuePair<string,string> household in simplePets)
        {
            Console.WriteLine(household.Key + " owns " + household.Value);
        }

        //Dictionary<string, List<string>> petDictionary  = new Dictionary <string, List<string>>();
        //Dictionary<string, List<string>>petDictionary = new();
       
       
       //This is an example of shortened object initializer
       //here:   = new() is the same as = new Dictionary<string, List<string>>
       //Dictionary (type of key, type of item)
       //so we have a string key and then the item type is a list of strings

       // declaring a new list we can then pass in
        //List<string> jonPets = new List<string>(){"Ellie","Pancake"};


       //This is an example of nesting collections.  Unrelated to what we're doing here, but
       //you can nest a dictionary within a dictionary.
       //You can create a list separately or you can crete a list 
       //while you're adding it to the dictionary.
       //But as long as it receives a value of type List<string>

        // petDictionary.Add("Jonathan", jonPets);
        // petDictionary.Add("Ross", new List<string>(){"Brodie"});
        // petDictionary.Add("Mike", new List<string>(){"Carl"});
        // petDictionary.Add ("Marcus", new List<string>(){"Ziggy", "Luna", "Amelia","Pyewacket", "Love Muffin"});

        



    }
}
