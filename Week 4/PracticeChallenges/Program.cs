namespace PracticeChallenges;

class Program
{

    static void Main(string[] args)
    {
        QuestionFour();

    }
    public static int CountDistinctCharacters(string str)
    {
        int countdistinct = 0;
        string distinctletters ="";
        if (string.IsNullOrEmpty(str))
        {
            return 0;
        }
        else
        {
            distinctletters = Convert.ToString(str[0]);

            for (int i = 0; i<str.Length; i++) // go through each letter of the main word
            {
                bool lettersmatch = false;

                    for (int j = 0; j<distinctletters.Length; j++) // compare the letter from the main word to each letter of the distinct letters set
                    {
                        if (str[i] == distinctletters[j])
                        {
                            lettersmatch = true; //as soon as you get a match, set flag to true & move to the next letter of the main word
                            break;
                        }
                    }
                    if(!lettersmatch) // if the letter of the main word does not match any of the letters in the distinct set, add that letter to the distinct set
                    {
                        distinctletters = distinctletters + str[i];
                    }

            }

        }
        countdistinct = distinctletters.Length;

        return countdistinct; // Placeholder return
    }  



    static void QuestionFour()
    {
        // Call method 4: CountDistinctCharacters
        Console.WriteLine("Question 4: CountDistinctCharacters");
        int result1 = CountDistinctCharacters("Hello World");
        int result2 = CountDistinctCharacters("aabbcc");
        int result3 = CountDistinctCharacters("");
        int result4 = CountDistinctCharacters("Aaron");

        Console.WriteLine("Test 1: " + (result1 == 8 ? "Success" : "Fail"));
        Console.WriteLine("Test 2: " + (result2 == 3 ? "Success" : "Fail"));
        Console.WriteLine("Test 3: " + (result3 == 0 ? "Success" : "Fail"));
        Console.WriteLine("Test 4: " + (result4 == 5 ? "Success" : "Fail"));
        Console.WriteLine();
    }

}
