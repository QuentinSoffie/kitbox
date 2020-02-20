using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Classes
{
    class Order
    {
        private List<Cupboard> cupboardList;
        public Order()
        {
        }
        public void Add(Cupboard newCupboard)
        {
            cupboardList.Add(newCupboard);
        }
        public void Remove(Cupboard oldCupboard)
        {
            if (cupboardList.Contains(oldCupboard))
            {
                cupboardList.Remove(oldCupboard);
            }
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
        public void RemoveAt(int index)
        {
            if (index < cupboardList.Count() - 1)
            {
                cupboardList.RemoveAt(index);
            }
        }
     
    }
}
