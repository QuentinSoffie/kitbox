using System.Collections.Generic;

namespace Kitbox.Models.Database.Json
{
    /// <summary>
    /// *DEPRECIATE* This class is used to serialize the order.
    /// </summary>
    public class Order
    {
        public Dictionary<string, int> Command = new Dictionary<string, int>();
    }
}
