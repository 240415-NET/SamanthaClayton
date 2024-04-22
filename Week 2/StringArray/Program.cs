using System.Diagnostics;
using System.Runtime.InteropServices;

namespace StringArray {
    class Program {
        static void Main(string[] args)
        {
            // int student_one_grade = 97;
            // int student_two_grade = 93;
            // int student_three_grade = 100;
            // int student_four_grade = 85;

            // Console.WriteLine(student_one_grade);
            // Console.WriteLine(student_two_grade);
            // Console.WriteLine(student_three_grade);
            // Console.WriteLine(student_four_grade);

            // int[] student_grades = new int[4];

            // student_grades[0] = 97;
            // student_grades[1] = 93;
            // student_grades[2] = 100;
            // student_grades [3] = 85;

            // int[] student_grades2 = {97, 93, 100, 85};

            // Console.WriteLine(student_grades);

            // for(int i = 0; i < 4; i++)
            // // {
            // //    Console.WriteLine(i);
            // //    Console.WriteLine(student_grades[i]);
            // // }

            // //Enhanced For Loop: Not doing anything different
            // //than the for loop above.  It's just more concise.

            // // foreach(int grade in student_grades2)
            // // {
            // //     Console.WriteLine(grade);
            // // }

            // char[] hello_chars = {'H', 'e', 'l', 'l', 'o'};
            // string hello_string = new string(hello_chars);
            // Console.WriteLine(hello_string);
            // Console.WriteLine(hello_chars);

            // //.ToCharArray() method

            // string world_string = "world!";
            // char[] world_chars = world_string.ToCharArray();

            // Console.WriteLine(world_string);
            // Console.WriteLine(world_chars);

            // //More String Methods
            // string new_word = "Banana";
            // Console.WriteLine(new_word);

            // string new_word_upper = new_word.ToUpper();
            // Console.WriteLine(new_word);
            // Console.WriteLine(new_word_upper);

            // Console.WriteLine(new_word.ToLower());

            // string cool_word = Console.ReadLine();
            // string new_cool_word = cool_word.ToUpper();
            // Console.WriteLine(cool_word);
            // Console.WriteLine(new_cool_word);
            // Console.WriteLine(new_cool_word.ToLower());
            // Console.WriteLine(new_cool_word);

            // foreach(char c in cool_word)
            // {
            //     Console.WriteLine(c);
            // }

            // // for (int i =0; i <=cool_word.Count(); i++)
            // // {
            // //     Console.WriteLine(cool_word[i]);
            // // }
            // for (int i =1; i <cool_word.Count(); i++)
            // {
            //     Console.WriteLine(cool_word[i]);
            // }

            // //substring
            // Console.WriteLine(cool_word.Substring(0,3));

            // Console.WriteLine(cool_word.Substring(cool_word.Count() -4, 3));

            // //contains
            // string phrase1 = "Hello there, Mike!";
            // Console.WriteLine(phrase1.Contains("Mike"));

            // Console.WriteLine("Please write your name!");
            // string name = Console.ReadLine();

            // if (name.ToLower().Contains("Mike"))
            // {
            //     Console.WriteLine("Hello Mike!");
            // }
            // else
            // {
            //     Console.WriteLine("Hello, Not Mike!");
            // }    
        //Trim() - remove all leading and trailing whitespace from a string

        Console.WriteLine("Please write your name!");
        // string name2 = Console.ReadLine().Trim().ToLower();

        // Console.WriteLine(name2);

        //Replace - replaces all occurrences of a specified substirng

        string text = "Hello Hello, World!";
        string newtext = text.Replace(" ","_");
        Console.WriteLine(newtext);

        }
    }
}