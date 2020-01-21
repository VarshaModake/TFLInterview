using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFLRoadStatus.Interfaces
{
   public interface IConfigurationWrapper
    {
        string GetValue(string key);
        bool HasKey(string key);
    }
}
