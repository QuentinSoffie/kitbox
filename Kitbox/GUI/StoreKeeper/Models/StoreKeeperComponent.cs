using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.GUI.StoreKeeper.Models
{
    public class StoreKeeperComponent
    {

        public string Ref { get; set; }
        public string Code { get; set; }
        public string Dimensions { get; set; }
        public string Couleur { get; set; }
        public int Stock { get; set; }
        public int StockMin { get; set; }
        public string SupplierOnePrice { get; set; }
        public string SupplierTwoPrice { get; set; }
        public string SupplierOneDelay { get; set; }
        public string SupplierTwoDelay { get; set; }

        public StoreKeeperComponent(Dictionary<String, Object> item)
        {
            Ref = item["Ref"].ToString();
            Code = item["Code"].ToString();
            Dimensions = item["Dimensions"].ToString();
            Couleur = item["Couleur"].ToString();
            Stock = int.Parse(item["Stock"].ToString());
            StockMin = int.Parse(item["StockMin"].ToString());
            SupplierOnePrice = item["SupplierOnePrice"].ToString();
            SupplierTwoPrice = item["SupplierTwoPrice"].ToString();
            SupplierOneDelay = item["SupplierOneDelay"].ToString();
            SupplierTwoDelay = item["SupplierTwoDelay"].ToString();
        }
        public override string ToString()
        {
            String value = String.Format("--- Component {0} ---", Code);
            return value;
        }
    }
}
