using System;
using System.Collections.Generic;
using Kitbox.Customer;
using Kitbox.Models.Components;

namespace Kitbox.Models.Order
{
    /// <summary>
    /// This is the order class. It's made of cupboard.
    /// </summary>
   public class Order
    {
        private readonly List<Cupboard> CupboardList;
        public string State = "Completed ✓";

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

        public void ClearCupboardList()
        {
            CupboardList.Clear();
        }
       
        public void RemoveAt(int uid)
        {
            foreach (Cupboard cupboard in CupboardList)
            {
                if (cupboard.Uid == uid)
                {
                    CupboardList.Remove(cupboard);
                    break;
                }
                foreach (Box box in cupboard.ListeBoxes)
                {
                    if (box.Uid == uid)
                    {
                        cupboard.ListeBoxes.Remove(box);
                        break;
                    }
                }
            }
        }

        public string CheckState()
        {
            foreach(Cupboard cupboard in CupboardList)
            {
                if(cupboard.CheckState() == "Not completed")
                {
                    State = cupboard.State;
                }
            }
            return State;
        }

        public List<List<string>> MakeOrder()
        {
            List<List<string>> matrix = new List<List<string>>();
            foreach (Cupboard cupboard in CupboardList)
            {
                PrepareOrder(cupboard, matrix);
            }
            return matrix;
        }

        public int GetQuantityCode(string code)
        {
            int quantity = 0;
            foreach (Cupboard cupboard in CupboardList)
            {
            
                if (!(cupboard.CupboardAngle is null) && cupboard.CupboardAngle.Code == code)
                {
                    quantity += cupboard.CupboardAngle.CountComponents();
                }

                foreach (Box box in cupboard.ListeBoxes)
                {
                   
                    if (!(box.Door is null) && box.Door.Code == code)
                    {
                        quantity += box.Door.CountComponents();
                    }

                    if (!(box.Cups is null) && box.Cups.Code == code)
                    {
                        quantity += box.Cups.CountComponents();
                    }

                    if (box.Slider.Code == code)
                    {
                        quantity += box.Slider.CountComponents();
                    }

                    foreach (Traverse traverse in box.Traverse)
                    {
                        if (traverse.Code == code)
                        {
                            quantity += traverse.CountComponents();
                        }
                    }

                    foreach (Panel panel in box.Panels)
                    {
                        if (panel.Code == code)
                        {
                            quantity += panel.CountComponents();
                        }
                    }
                }
            }
            return quantity;
        }

        private void PrepareOrder(Cupboard cupboard, List<List<string>> matrix)
        {
            if (!(cupboard.CupboardAngle is null) && AddAngleQuantityToOrder(cupboard, cupboard.CupboardAngle.Code, matrix) == false)
            {
                List<string> line = new List<string>() { cupboard.CupboardAngle.Code, "Cornieres", cupboard.CupboardAngle.DimensionsToString, cupboard.CupboardAngle.CountComponents().ToString() }; ;
                matrix.Add(line);
            }

            foreach (Box box in cupboard.ListeBoxes)
            {
                if (!(box.Door is null) && AddQuantityToOrder(box, box.Door.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { box.Door.Code, "Porte", box.Door.DimensionsToString, box.Door.CountComponents().ToString() }; ;
                    matrix.Add(line);
                }

                if (AddQuantityToOrder(box, box.Slider.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { box.Slider.Code, "Tasseau", box.Slider.DimensionsToString, box.Slider.CountComponents().ToString() }; ;
                    matrix.Add(line);
                }

                if (!(box.Cups is null) && AddQuantityToOrder(box, box.Cups.Code, matrix) == false)
                {
                    List<string> line = new List<string>() { box.Cups.Code, "Coupelles", box.Cups.DimensionsToString, box.Cups.CountComponents().ToString() }; ;
                    matrix.Add(line);
                }

                foreach (Traverse traverse in box.Traverse)
                {
                    if (AddQuantityToOrder(box, traverse.Code, matrix) == false)
                    {
                        List<string> line = new List<string>() { traverse.Code, traverse.Type, traverse.DimensionsToString, traverse.CountComponents().ToString() }; ;
                        matrix.Add(line);
                    }
                }

                foreach (Panel panel in box.Panels)
                {
                    if (AddQuantityToOrder(box, panel.Code, matrix) == false)
                    {
                        List<string> line = new List<string>() { panel.Code, "Panneau " + panel.Type, panel.DimensionsToString, panel.CountComponents().ToString() }; ;
                        matrix.Add(line);
                    }
                }
            }
        }

        public bool AddAngleQuantityToOrder(Cupboard cupboard, string code, List<List<string>> matrix)
        {
            foreach (List<string> codeMatrix in matrix)
            {
                if(codeMatrix[1] == "Cornieres")
                {
                    codeMatrix[3] = (int.Parse(codeMatrix[3]) + cupboard.CupboardAngle.CountComponents()).ToString();
                    return true;
                }
            }
            return false;
        }

        private bool AddQuantityToOrder(Box box, string code, List<List<string>> matrix) // Return index where order contains code (else -1)
        {
          
            foreach (List<string> codeMatrix in matrix)
            {
                //indice 1 = pièce
                if (codeMatrix[0] == code) {
                    Console.WriteLine(String.Format("J'ajoute des {0}", codeMatrix[1]));

                    if (codeMatrix[1] == "Porte")
                    {
                        codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + box.Door.CountComponents()).ToString();
                        return true;
                    }
                    if (codeMatrix[1] == "Tasseau")
                    {
                        codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + box.Slider.CountComponents()).ToString();
                        return true;
                    }
                    
                    if (codeMatrix[1] == "Coupelles")
                    {
                        codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + box.Cups.CountComponents()).ToString();
                        return true;
                    }
                    foreach (Panel panel in box.Panels)
                    {
                        if (codeMatrix[1] == "Panneau " + panel.Type)
                        {
                            codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + panel.CountComponents()).ToString();
                            return true;
                        }
                    }
                    foreach (Traverse traverse in box.Traverse)
                    {
                        Console.WriteLine(codeMatrix[1]);
                        Console.WriteLine(traverse.Type);
                        if (codeMatrix[1] == traverse.Type)
                        {
                            Console.WriteLine("JE rajouter des traverses");
                            codeMatrix[3] = (Int32.Parse(codeMatrix[3]) + traverse.CountComponents()).ToString();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
