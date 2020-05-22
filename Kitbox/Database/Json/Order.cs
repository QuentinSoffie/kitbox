using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Database.Json
{
    public class Order
    {
        //public List<string> Code = new List<string>();
        //public List<int> Quantity = new List<int>();
        public Dictionary<string, int> Command = new Dictionary<string, int>();
    }
}
