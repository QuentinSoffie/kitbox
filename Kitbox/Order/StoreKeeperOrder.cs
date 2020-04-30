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
        public List<string> KeyList { get; set; }
        public Dictionary<String, Object> Components { get; set; }
        public String State { get; set; }
        public String Customer { get; set; }
        public String OrderNumber { get; set; }

        public StoreKeeperOrder(Dictionary<String, Object> item)
        {
            Components = JsonConvert.DeserializeObject<Dictionary<String, Object>>(item["Components"].ToString());
            OrderNumber = item["OrderNumber"].ToString();
            State = item["State"].ToString();
            Customer = item["Customer"].ToString();

            KeyList = new List<string>(Components.Keys);
        }

        public override string ToString()
        {
            String value = String.Format("--- Order n°{0}, owner : {1}, Status : {2} ---\n     Components :\n", OrderNumber, Customer, State);

            foreach (KeyValuePair<String, Object> comp in Components)
            {
                value += String.Format("\t- {0}x{1}\n", comp.Key, comp.Value);
            }
            return value;
        }


    }
}
