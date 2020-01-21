using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLRoadStatus.Exceptions
{
    class RoadIdRequiredException: Exception
    {
        public RoadIdRequiredException()
        {

        }
        public RoadIdRequiredException(string message) : base(message)
        {

        }
    }
}
