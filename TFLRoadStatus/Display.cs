using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFLRoadStatus.Model;

namespace TFLRoadStatus
{
   public class Display
    {
        public static void DisplayInformation(Road road)
        {
            if (road!=null)
            {
                
                    Console.WriteLine($"The Status of {road.displayName} is as follows");
                    Console.WriteLine("Road Status is " + road.statusSeverity);
                    Console.WriteLine("Road Status Description is " + road.statusSeverityDescription);
                
            }
        }
    }
}
