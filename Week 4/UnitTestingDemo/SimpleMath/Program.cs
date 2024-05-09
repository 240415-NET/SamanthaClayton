using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace SimpleMath;

public class Program
{
    static void Main(string[] args)
    {

    }

    public static Boolean IsPrime(int x)
        {
            if (x <= 1)
            return false; // no {} needed if it's 1 line
            else if (x==2)
            return true;
            else
            {
                for (int i = 2; i < x; i++)
                {
                    if (x % i ==0)
                    return false;
                }
                return true;
            }

        }
}
