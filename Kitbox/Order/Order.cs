using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.Components;
using Kitbox.GUI;
using System.Windows.Forms;
namespace Kitbox.Order
{
   public class Order
    {
        private List<Cupboard> CupboardList;
        

        public Order()
        {
            CupboardList = new List<Cupboard>();
          
           
        }
        public void Add(int uid ,TreeviewManager ViewManager)
        {
            Cupboard cupboard = new Cupboard(uid);
            ViewManager.AddViewCupboard(uid, cupboard);
            CupboardList.Add(cupboard);
        }

       
       
        public void RemoveAt(int uid)
        {
            foreach (Cupboard cupboard in CupboardList)
            {
                if(cupboard.Uid == uid)
                {
                    CupboardList.Remove(cupboard);
                    break;
                }
            }
        }
     
    }
}
