namespace TuesdayPractice_Strings;

class Program


{

    //Removed the strings practice and instead wanted to save/tweak my
    //code challenge 1 answers
    static void Main(string[] args)
    {
        int b = 444;
        int s = 15;
        int t = 20;
        int rocksremaining = b;
        int srocks = 0;
        int trocks = 0;
        int turncount=1;
        int answer;
        
        //find count of 2nd to last turn
     do 
        {
            if (turncount%2 == 0)
            {
                rocksremaining = rocksremaining - t;
                turncount++;
            }
            else
            {
                rocksremaining = rocksremaining - s;
                turncount++;
            }
        
        } while (rocksremaining >0);
        //during the test, i put >= 0 

   int secondtolastturncount = turncount - 2;
            //}
        
        
        
        //if the last 'full turn' was Steve, then game will end with Tommy
        //if the last 'full turn' was Tommy, then game will end with Steve
        if (secondtolastturncount%2 == 0)
        {
            srocks = ((s*secondtolastturncount)/2) + (s+rocksremaining);
            answer = srocks;
        }
        else 
        {
            trocks = (t*(secondtolastturncount-1)/2) + (t+rocksremaining);
            answer = trocks;
        }
        
        Console.WriteLine(turncount);
        Console.WriteLine(answer);
  
    }


    }

    

