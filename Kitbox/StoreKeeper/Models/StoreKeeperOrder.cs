using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.StoreKeeper.Models
{
    /// <summary>
    /// This is the Order class used for the storekeeper. It instanciates the order with the json form the database 
    /// </summary>
    public class StoreKeeperOrder
    {
        public List<string> KeyList { get; set; }
        public Dictionary<string, object> Components { get; set; }
        public string State { get; set; }
        public string Customer { get; set; }
        public string CustomerId { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }

        public StoreKeeperOrder(Dictionary<string, object> item)
        {
            Components = JsonConvert.DeserializeObject<Dictionary<string, object>>(item["Components"].ToString());
            OrderNumber = item["OrderNumber"].ToString();
            State = item["State"].ToString();
            Customer = item["Customer"].ToString();
            CustomerId = item["IdClient"].ToString();
            Name = string.Format("Order number : {0}, Owner : {1}", OrderNumber, Customer);

            KeyList = new List<string>(Components.Keys);
        }

        public override string ToString()
        {
            string value = string.Format("--- Order n°{0}, owner : {1}, Status : {2} ---\n     Components :\n", OrderNumber, Customer, State);

            foreach (KeyValuePair<string, object> comp in Components)
            {
                value += string.Format("\t- {0}x{1}\n", comp.Key, comp.Value);
            }
            return value;
        }
    }
}
