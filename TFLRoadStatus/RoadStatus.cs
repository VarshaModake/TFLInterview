
using System.Net;
using System;
using TFLRoadStatus.Model;
using TFLRoadStatus.Exceptions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace TFLRoadStatus
{
    
    class RoadStatus
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //checking for input roadId
                if (args.Length > 0)
                {
                    foreach (string RoadId in args)
                    {
                        GetRoadInformation getRoadInformation = new GetRoadInformation(new AppConfigWrapper());
                        Task<IEnumerable<Road>> response = getRoadInformation.GetRoadById(RoadId);
                        if (response.Result!= null)
                        {
                            foreach (Road rd in response.Result)
                            {
                                Display.DisplayInformation(rd);
                                Console.WriteLine();
                            }
                        }
                    }
                    Console.ReadLine();
                }
                else
                {
                    throw new RoadIdRequiredException("Road no / Road Id required");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        
    }
}
