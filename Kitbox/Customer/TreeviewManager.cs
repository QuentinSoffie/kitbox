using System;
using System.Collections.Generic;
using KitboxEcamGUI;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Kitbox.Models.Order;
using Kitbox.Customer.Views;
using Kitbox.Models.Database;
using Kitbox.Models.Components;

namespace Kitbox.Customer
{
    /// <summary>
    /// This is the treeview manager that manage the customer left-hand treeview.
    /// </summary>
    public class TreeviewManager
    {
        public PepTreeView MainTreeview;
        private Control.ControlCollection ViewList;
        private int UidTreeview = 0;
        private Order OurOrder;
        private MySqlConnection DataBase;

        public TreeviewManager(KitboxEcamGUI.PepTreeView mainTreeview, Control.ControlCollection viewCupboardList, Order ourOrder, MySqlConnection database)
        {
            this.MainTreeview = mainTreeview;
            this.ViewList = viewCupboardList;
            this.OurOrder = ourOrder;
            this.DataBase = database;
        }

        public void AddViewCupboard(int uid, Cupboard cupboard)
        {
            ViewCupboard view = new ViewCupboard(uid, cupboard, DataBase, this);
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
                if (view is ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        viewType.BringToFront();
                        break;
                    }

                }
                if (view is ViewCupboard)
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
                if (view is ViewBox)
                {
                    ViewBox viewType = (ViewBox)view;

                    if (viewType.Uid == uid)
                    {
                        ViewList.Remove(viewType);
                        break;
                    }
                }

                else if (view is ViewCupboard)
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

        public void AddCupboard(Order ourOrder, string Tag = "contains 0 Box")
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
            }

            return notAvailable;
        }

        public void AddBox(int uidCupboard, Dictionary<string, Dictionary<string, object>> components, Cupboard cupboard, string tag = "Completed ✓")
        {
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Tag = $"Contains {cupboard.CountBox() + 1} box";
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes.Add(UidTreeview.ToString(), "Box - Uid " + UidTreeview);
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].Tag = tag;
            MainTreeview.Nodes[ReturnIndexTreeview(uidCupboard)[0]].Nodes[ReturnIndexTreeview(UidTreeview)[1]].ImageIndex = 0;

            cupboard.AddBox(uidCupboard, UidTreeview, (Door)components["Door"]["Component"], (Slider)components["Slider"]["Component"], new List<Models.Components.Panel>() { (Models.Components.Panel)components["PanelBack"]["Component"], (Models.Components.Panel)components["PanelSides"]["Component"], (Models.Components.Panel)components["PanelHB"]["Component"] }, new List<Traverse>() { (Traverse)components["TraverseFront"]["Component"], (Traverse)components["TraverseBack"]["Component"], (Traverse)components["TraverseSides"]["Component"] }, (Cups)components["Cups"]["Component"], tag, this);
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
