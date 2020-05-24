using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitbox.Components;
using KitboxEcamGUI;
using System.Windows.Forms;
using Kitbox.Order;
using MySql.Data.MySqlClient;
using Kitbox.Database;
using Panel = Kitbox.Components.Panel;

namespace Kitbox.GUI
{
    public class TreeviewManager
    {
        public PepTreeView MainTreeview;
       
        private Control.ControlCollection ViewList;

        private int UidTreeview = 0;

        private Order.Order OurOrder;

        private MySqlConnection DataBase;

        public TreeviewManager(KitboxEcamGUI.PepTreeView mainTreeview, Control.ControlCollection viewCupboardList, Order.Order ourOrder, MySqlConnection database)
        {
            this.MainTreeview = mainTreeview;
            this.ViewList = viewCupboardList;
            this.OurOrder = ourOrder;
            this.DataBase = database;
        }

        public void AddViewCupboard(int uid, Cupboard cupboard)
        {
            Kitbox.GUI.ViewCupboard view = new Kitbox.GUI.ViewCupboard(uid, cupboard, DataBase, this);
            view.Dock = DockStyle.Fill;
            ViewList.Add(view);
            view.Hide();
        }

        public void AddViewBox(int uidCupboard,int uid, Box box)
        {
            ViewBox viewBox = new ViewBox(uidCupboard, uid, box, this);
            viewBox.Dock = DockStyle.Fill;
            ViewList.Add(viewBox);
            viewBox.BringToFront();
        }
       
        public void BringToFrontView(int uid)
        {
            foreach (Object view in ViewList)
            {
                if (view is Kitbox.GUI.ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        viewType.BringToFront();
                        break;
                    }

                }
                if (view is Kitbox.GUI.ViewCupboard)
                {
                    ViewCupboard viewType = (ViewCupboard)view;

                    if (viewType.Uid == uid)
                    {
                        viewType.RefreshView();
                        viewType.Show();
                        viewType.BringToFront();
                        break;
                    }
                }              
            }
        }

        public void ClearTreeview()
        {
            OurOrder.ClearCupboardList();
            ViewList.Clear();
            MainTreeview.Nodes.Clear();
        }

        private void RemoveView(int uid)
        {
            foreach (Object view in ViewList)
            {
                if (view is Kitbox.GUI.ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        ViewList.Remove(viewType);
                        break;
                    }
                }

                else if (view is Kitbox.GUI.ViewCupboard)
                {
                    ViewCupboard viewType = (ViewCupboard)view;

                    if (viewType.Uid == uid)
                    {
                        ViewList.Remove(viewType);
                        break;
                    }
                }
            }
        }

        public void AddCupboard(Order.Order ourOrder, string Tag = "contains 0 Box")
        {
            UidTreeview += 1;
            MainTreeview.Nodes.Add(UidTreeview.ToString(), "Cupboard - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)[0]].Tag = Tag;
            MainTreeview.Nodes[ReturnIndexTreeview(UidTreeview)[0]].ImageIndex = 1;
            ourOrder.Add(UidTreeview, this);
        }

        private int[] ReturnIndexTreeview(int uid)
        {
            for (int countCupboard = 0; countCupboard < MainTreeview.Nodes.Count; countCupboard++)
            {
                for (int countBox = 0; countBox < MainTreeview.Nodes[countCupboard].Nodes.Count; countBox++)
                {
                    if (MainTreeview.Nodes[countCupboard].Nodes[countBox].Name == uid.ToString())
                    {
                        return new int[] {countCupboard, countBox};
                    }
                }
                if (MainTreeview.Nodes[countCupboard].Name == uid.ToString())
                {
                    return new int[] { countCupboard, 0 };
                }
            }

            return new int[] { -1, -1 };
        }

        public void RemoveCupboard(int uid, Cupboard cupboard)
        {
            foreach (Box box in cupboard.ListeBoxes)
            {
                RemoveView(box.Uid);
            }
            OurOrder.RemoveAt(uid);
            MainTreeview.Nodes.RemoveAt(ReturnIndexTreeview(uid)[0]);
            RemoveView(uid);
        }


        public Dictionary<string, Dictionary<string, object>> GetBoxComponents(string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard)
        {
            return Reader.SearchComponent(UidTreeview, width, depth, height, colorDoor, colorPanel, cupboard, OurOrder, DataBase);
        }

        public Dictionary<string, Specs> CheckBox(int uidCupboard, Dictionary<string, Dictionary<string, object>> components , string tag = "Completed ✓")
        {
            UidTreeview += 1;
            Dictionary<string, Specs> notAvailable = new Dictionary<string, Specs>();
            foreach (KeyValuePair<string, Dictionary<string, object>> component in components)
            {
                if (!(component.Value["Component"] is null))
                {
                    if (component.Value["Available"] is false)
                    {
                        notAvailable.Add(component.Key, (Specs)component.Value["Component"]);
                    }
                }

                //if (!(component.Value is null) && component.Value.IsInStock(OurOrder.GetQuantityCode(component.Value.Code) + component.Value.CountComponents()) == false  )
                //{
                //    return component.Key;
                //}
                //else if (component.Value == new Specs(0, 0, 0, 0 ,0, "", ""))
                //{
                //    return component.Key;
                //}
            }

            //Door door = (Components.Door)components["Door"]["Component"];
            //Slider slider = (Components.Slider)components["Slider"]["Component"];
            //Panel panelBack = (Panel)components["PanelBack"]["Component"];
            //Panel panelSides = (Panel)components["PanelSides"]["Component"];
            //Panel panelHB = (Panel)components["PanelHB"]["Component"];
            //Traverses traverseFront = (Traverses)components["TraverseFront"]["Component"];
            //Traverses traverseBack = (Traverses)components["TraverseBack"]["Component"];
            //Traverses traverseSides = (Traverses)components["TraverseSides"]["Component"];
            //Cups cups = (Cups)components["Cups"]["Component"];

            return notAvailable;
        }

        public void AddBox(int uidCupboard, Dictionary<string, Dictionary<string, object>> components, Cupboard cupboard, string tag = "Completed ✓")
        {
            //UidTreeview += 1;
            //Dictionary<string, Dictionary<string, object>> components = Reader.SearchComponent(UidTreeview, width, depth, height, colorDoor, colorPanel, cupboard, OurOrder, DataBase);
            //Dictionary<string, Specs> notAvailable = new Dictionary<string, Specs>();
            //foreach (KeyValuePair<string, Dictionary<string, object>> component in components)
            //{
            //    if (!(component.Value["Component"] is null))
            //    {
            //        if (component.Value["Available"] is false)
            //        {
            //            notAvailable.Add(component.Key, (Specs)component.Value["Component"]);
            //        }       
            //    }

            //    //if (!(component.Value is null) && component.Value.IsInStock(OurOrder.GetQuantityCode(component.Value.Code) + component.Value.CountComponents()) == false  )
            //    //{
            //    //    return component.Key;
            //    //}
            //    //else if (component.Value == new Specs(0, 0, 0, 0 ,0, "", ""))
            //    //{
            //    //    return component.Key;
            //    //}
            //}


            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Tag = $"Contains {cupboard.CountBox() + 1} box";
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Add(UidTreeview.ToString(), "Box - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].Tag = tag;
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].ImageIndex = 0;

            cupboard.AddBox(uidCupboard, UidTreeview, (Components.Door)components["Door"]["Component"], (Components.Slider)components["Slider"]["Component"], new List<Panel>() { (Panel)components["PanelBack"]["Component"], (Panel)components["PanelSides"]["Component"], (Panel)components["PanelHB"]["Component"] }, new List<Traverses>() { (Traverses)components["TraverseFront"]["Component"], (Traverses)components["TraverseBack"]["Component"], (Traverses)components["TraverseSides"]["Component"] }, (Cups)components["Cups"]["Component"], tag, this);
        }

        public void UpdateTag(int uidCupboard, string certified = "false")
        {
            if (certified == "false")
            {
                MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Tag = $"Contains {MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Count} box";
            }
            else if (certified == "true")
            {
                MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Tag = $"Contains {MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Count} box ✓";
            }
            else if(certified is null){
                MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Tag = $"Contains {MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Count} box (Components not in stock)";
            }
            MainTreeview.Refresh();
        }

        public void RemoveBox(int uid,int uidCupboard)
        {
            Console.WriteLine(uid);
            MainTreeview.Nodes[ReturnIndexTreeview(uid)[0]].Nodes.RemoveAt(ReturnIndexTreeview(uid)[1]);
            RemoveView(uid);
            OurOrder.RemoveAt(uid);
            UpdateTag(uidCupboard);
            BringToFrontView(uidCupboard);
        }

        public bool CheckAngle(CupboardAngle cupboardAngle)
        {
        if ((OurOrder.GetQuantityCode(cupboardAngle.Code) + cupboardAngle.CountComponents()) < cupboardAngle.AvailableStock + 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckIfAllCupboardAreVerified()
        {
            int allIsChecked = 0;
            for (int i = 0; i < MainTreeview.Nodes.Count; i++)
            {
                if (MainTreeview.Nodes[i].Tag.ToString().Contains("✓") || MainTreeview.Nodes[i].Tag.ToString().Contains("stock"))
                {
                    allIsChecked += 1;
                }
            }
            return MainTreeview.Nodes.Count == allIsChecked;
        }
    }
}
