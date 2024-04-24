using System.Linq;
using System;
using System.Globalization;
public class Program 
{
    
    public static void Main(string[] args)
    {
//         static string MonthName(int num) 
//     {
// 			switch (num)
// 			{	case 1:	return "January";
// 				case 2: return "February";
// 				case 3: return "March";
// 				case 4: return "April";
// 				case 5: return "May";
// 				case 6: return "June";
// 				case 7: return "July";
// 				case 8: return "August";
// 				case 9: return "September";
// 				case 10: return "October";
// 				case 11: return "November";
// 				case 12: return "December";
//             }
//                 return "invalid entry";
// 			}
//    Console.WriteLine(MonthName(3));
//     }

    static double[] FindMinMax(double[] values) 
    {
				double[] minmaxarray = {values.Min(), values.Max()};
			    return minmaxarray;
			  
    }
    Console.WriteLine(FindMinMax([0,1,2]));
    double[] myarray = {5.68, 2.99, 3, 199, -48, -23, 12, 6.4};
    double[] myarray2 = FindMinMax(myarray);
   Console.WriteLine("Here is the original array:");
   
   foreach (double number in myarray)
   {
    Console.WriteLine(number);
   }

      Console.WriteLine("Here is the min and max:");
      foreach (double number in myarray2)
   {
    Console.WriteLine(number);
   }



    }
}
