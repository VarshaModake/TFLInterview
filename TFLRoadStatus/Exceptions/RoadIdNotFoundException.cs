using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TFLRoadStatus.Exceptions
{
    class RoadIdNotFoundException : Exception
    {
        public RoadIdNotFoundException(HttpStatusCode Status, string RoadId):base(RoadId + " Is not a valid road")
        {
            if (Status.Equals(HttpStatusCode.NotFound))
            {
                Console.WriteLine(RoadId + " Is not a valid road");
            }
        }
    }
}
