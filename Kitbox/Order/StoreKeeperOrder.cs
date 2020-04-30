using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Order
{
    class StoreKeeperOrder
    {
        List<string> keyList;

        public StoreKeeperOrder(String item)
        {
            Dictionary<String, Object> a = JsonConvert.DeserializeObject<Dictionary<String, Object>>(item);
            keyList = new List<string>(a.Keys);
        }

    }
}
