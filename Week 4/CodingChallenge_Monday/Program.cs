namespace CodingChallenge_Monday;

class Program
{
    static void Main(string[] args)
    {

        int N = int.Parse(Console.ReadLine());
        char newcharacter;
        string newrow ="";
        for (int i = 0; i < N; i++)
        {
            string ROW = Console.ReadLine();
            for (int j = 0; j<ROW.Length; j++)
            
                {
                    if (ROW[j] == '0')
                    {
                        newcharacter = '-';
                    }
                    else
                    {
                        newcharacter = ROW[j];
                    }
                    newrow = newrow + newcharacter.ToString();
                }
            
            Console.WriteLine(newrow);

            
        }

        
    }
}
