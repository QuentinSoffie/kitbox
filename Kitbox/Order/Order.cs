using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.Components;
using Kitbox.GUI;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Kitbox.Order
{
   public class Order
    {
        private readonly List<Cupboard> CupboardList;
        

        public Order()
        {
            CupboardList = new List<Cupboard>();   
           
        }
        public void Add(int uid, TreeviewManager ViewManager)
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

        public List<List<string>> MakeOrder()
        {
            List<List<string>> matrix = new List<List<string>>();
            foreach (Cupboard cupboard in CupboardList)
            {
                PrepareOrder(cupboard,matrix);
            }
            return matrix;
        }

        public int GetQuantityCode(string code)
        {
            int quantity = 0;
            foreach (Cupboard cupboard in CupboardList)
            {
                if (!(cupboard.CupboardAngle is null))
                {
                    if (cupboard.CupboardAngle.Code == code)
                    {
                        quantity += 1;
                    }
                }

                foreach (Box box in cupboard.ListeBoxes)
                {
                    if (box.Door.Code == code)
                    {
                        quantity += 1;
                    }

                    if (box.Slider.Code == code)
                    {
                        quantity += 1;
                    }

                    foreach (Traverses traverse in box.Traverses)
                    {
                        if (traverse.Code == code)
                        {
                            quantity += 1;
                        }
                    }

                    foreach (Kitbox.Components.Panel panel in box.Panels)
                    {
                        if (panel.Code == code)
                        {
                            quantity += 1;
                        }
                    }

                }
            }
            return quantity;
        }

        private void PrepareOrder(Cupboard cupboard, List<List<string>> matrix)
        {
            if (!(cupboard.CupboardAngle is null))
            {
                if (AddQuantityToOrder(cupboard.CupboardAngle.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { cupboard.CupboardAngle.Code, "Cornieres", cupboard.CupboardAngle.DimensionsToString, "1" }; ;
                    matrix.Add(line);
                }
            }


            foreach (Box box in cupboard.ListeBoxes)
            {
                if (AddQuantityToOrder(box.Door.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { box.Door.Code, "Porte", box.Door.DimensionsToString, "1" }; ;
                    matrix.Add(line);
                }

                if (AddQuantityToOrder(box.Slider.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { box.Slider.Code, "Cornieres", box.Slider.DimensionsToString, "1" }; ;
                    matrix.Add(line);
                }

                foreach (Traverses traverse in box.Traverses)
                {
                    if (AddQuantityToOrder(traverse.Code, matrix) == false)
                    {
                        List<string> line = new List<string>() { traverse.Code, traverse.Type, traverse.DimensionsToString, "1" }; ;
                        matrix.Add(line);
                    }
                }

                foreach (Kitbox.Components.Panel panel in box.Panels)
                {
                    if (AddQuantityToOrder(panel.Code, matrix) == false)
                    {
                        List<string> line = new List<string>() { panel.Code, panel.Type, panel.DimensionsToString, "1" }; ;
                        matrix.Add(line);
                    }
                }

            }
           
        }







        private bool AddQuantityToOrder(string code, List<List<string>> matrix) // Return index where order contains code (else -1)
        {
          
            foreach (List<string> codeMatrix in matrix)
            {
                if (codeMatrix[0] == code) {
                    codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + 1).ToString();
                    return true;
                }
            }
            return false;
        }



    }
}
