namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        string FIRST = "ata";
        string SECOND = "atlantaaatatl";

        // Replace letters in the first word
        // FIRST.Replace(Old Char, New Char)
        // If first word has X letters,
        // FIRST.Replace(the first X letters of second string, the letters in the first string)


        // Look at the first word "ata"
        // In the first word ("ata"), replace first 2 letters of the second word ("at") with "ata"
        // In the first word, we have "ata" which includes "at"
        // In the first word, replace the "at" in "ata" with "ata" and leave the plain "a" so you get "ata"
        // Original First Word              Revised First Word
        // "ata" = "at" + "a"               "ata" + "a" = "ataa"                      
        string NEWWORD = FIRST.Replace(SECOND.Substring(0, FIRST.Length-1), FIRST);
        // This is wrong for 2 reasons
        // 1) We want to replace the leters in the second word, not the first word
        // 2) We don't want to replace any time those letters happen, just the first 3 letters of the word.
        // 3) I should've used FIRST.LENGTH not FIRST.LENGTH - 1.


        string substring1 = SECOND.Substring(0,FIRST.Length);
        string substring2 = SECOND.Substring(0, FIRST.Length-1);
        string NEWWORD2 = SECOND.Substring(FIRST.Length,(SECOND.Length-FIRST.Length));


        Console.WriteLine($"First word: {FIRST}");
        Console.WriteLine($"Second word: {SECOND}");
        Console.WriteLine($"Second word substring to FIRST.Length: {substring1}");
        Console.WriteLine($"Second word substring to FIRST.Length-1: {substring2}");
        Console.WriteLine($"New word: {NEWWORD}");
        Console.WriteLine($"New word2: {NEWWORD2}");
        Console.WriteLine($"New word + new word2: {NEWWORD + NEWWORD2}");


        // This is better because it is replacing the letters in the second word
        // but it will still replace those 3 first letters anytime those 3 letters
        // are in the same order
        string answer = SECOND.Replace(SECOND.Substring(0, FIRST.Length), FIRST);
        Console.WriteLine($"Answer: {answer}");
        

        string result = FIRST + SECOND.Substring(FIRST.Length);
        Console.WriteLine($"Corey's result: {result}");

    }
}
