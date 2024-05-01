namespace CodeChallengeArrayQuestion;

class Program
{
    static void Main(string[] args)
    {

        int[] intarray = {5, 10, 20, 3};

        int minNum = 10000;
          
        foreach (int num in intarray)
        {
           if(num < minNum)
            {
                minNum = num;
            }
        }


        for (int i = 0; i<intarray.Length(); i++)
        {
            if (intarray[i]<minNum)
            {
                minNum = intarray[i];
            }
        }
        

    }
    
    }
