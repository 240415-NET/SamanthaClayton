using System.Diagnostics;

namespace MondayPractice;

class Program
{
    static void Main(string[] args)
    {
    // Method 1: Individually declare, initialize, and print student grades
        int student_one_grade = 97;
        int student_two_grade = 93;
        
        //Console.WriteLine(student_one_grade);
        //Console.WriteLine(student_two_grade);
    
    // Method 2: Create a new array, set the individual values in the array, & print
        int[] student_grades = new int[2];
        student_grades[0] = 97;
        student_grades[1] = 93;
        Console.WriteLine(student_grades); // Just prints out System.Int32[]
        

    // Method 3: Create a new array & set the values at the same time

        int[] student_grades2 = {97, 93};

        int index = 0;
        foreach (int grade in student_grades2)
        {
            Console.WriteLine(index);
            index++;
            Console.WriteLine(grade);
        }


        char[] hello_chars = {'h', 'e', 'l', 'l', 'o'};
        string hello_string = new string(hello_chars);

        Console.WriteLine(hello_string);
        Console.WriteLine(hello_chars);


        string world_string = "world";
        char[] world_chars = world_string.ToCharArray();
        Console.WriteLine(world_string);
        Console.WriteLine(world_chars);




    }
}
