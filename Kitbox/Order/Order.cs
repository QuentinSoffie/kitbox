using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kitbox.Components;

namespace Kitbox.Order
{
    class Order
    {
        private List<Cupboard> cupboardList;
        public Order()
        {
            cupboardList = new List<Cupboard>();
        }

        public void Add(int uid)
        {
            cupboardList.Add(new Cupboard(uid));
        }

        public Cupboard GetCupboard(int index)
        {
            if (index > cupboardList.Count() - 1)
            {
                return null;
            }
            else
            {
                return cupboardList[index];
            }
        }
        public void Remove(int index)
        {
            if (index < cupboardList.Count() - 1)
            {
                cupboardList.RemoveAt(index);
            }
        }
    }
}
