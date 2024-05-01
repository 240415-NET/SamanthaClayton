namespace CodingChallengeRocks;

using System;

public class Test{

    public static int rockGame(int b, int s, int t){

        //WRITE YOUR CODE HERE

        int rocksremaining = b; // variable is how many rocks are left after each turn, we're starting with all the rocks (b)
        int srocks = 0; // this is how many rocks s has collected
        int trocks = 0; // this is how many rocks t has collected
        int turncount = 1; // we're starting on turn 1
        int answer = 0;  //this is where I'll store my answer and then I'll be able to 'return' this at the end of the method
        
        //find count of last 'full turn'

        // Do-While:  Do the "do" block of code 1x then check the "while" condition
        // and if the "while" condition is true, repeat the "do" block.  If not, move on
        // to whatever the next line of code is.
        do 
        {
            if (turncount%2 == 0)
            {
                rocksremaining = rocksremaining - t;
                turncount++;
            }
            else
            {
                rocksremaining = rocksremaining - s; // on turn 1, rocks remaining = 9 - 7 
                turncount++;
            }
        } while (rocksremaining > 0);


        int secondtolastturncount = turncount - 2;


        // If the last 'full turn' was Steve, then game will end with Tommy

        // So count Tommy's rocks

        // If the last 'full turn' was Tommy, then game will end with Steve

        // So count Steve's rocks

    

        if (secondtolastturncount%2 == 0)

        {
            srocks = ((s*secondtolastturncount)/2) + (s+rocksremaining);
            answer = srocks;
        }

        else 

        {
            trocks = ((t*(secondtolastturncount-1))/2) + (t+rocksremaining);
            answer = trocks;

        }

        



        return answer;



    }





    //DO NOT TOUCH THE CODE BELOW

    public static void Main(){

        Console.WriteLine("How many rocks do you want to start with?");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("How many rocks will Steven take per turn?");
        int s = int.Parse(Console.ReadLine());

        Console.WriteLine("How many rocks will Tommy take per turn?");
        int t = int.Parse(Console.ReadLine());

        Console.WriteLine($"Total rocks to start: {b}\nSteve will take: {s}\nTommy will take: {t}");

        Console.WriteLine($"The number of rocks whoever finishes the game has:");
        Console.WriteLine(rockGame(b,s,t));


    }

}