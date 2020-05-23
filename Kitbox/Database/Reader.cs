using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBMethods;
using Kitbox.Components;

using Kitbox.Order;
using System.Drawing;

namespace Kitbox.Database
{
    public class Reader
    {
        public static void InitializeComponents(MySqlConnection conn)
        {
            conn.Open();
            Components.Doors.ClearDoor();
            Components.Panels.ClearPanel();
            Components.CupboardAngles.ClearCupboardAngle();
            SetDoorComponents("Porte", conn);
            SetPanelComponents("Panneau GD", conn);
            SetPanelComponents("Panneau Ar", conn);
            SetPanelComponents("Panneau HB", conn);
            SetCupboardAnglesComponents("Cornieres", conn);
            conn.Close();
        }
        private static void SetDoorComponents(string value, MySqlConnection conn)
        {
            var reader = DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Doors.AddDoor(reader.GetString("Couleur"), reader.GetInt32("hauteur"), reader.GetInt32("largeur"), 0, reader.GetInt32("Enstock"), reader.GetInt32("Stock minimum"),reader.GetString("Code"), reader.GetString("Dimensions(cm)"));
            }
            reader.Close();
        }

        private static void SetPanelComponents(string value, MySqlConnection conn)
        {
            var reader = DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Panels.AddPanel(reader.GetString("Couleur"), value.Replace("Panneau ", ""), reader.GetInt32("hauteur"), reader.GetInt32("largeur"), reader.GetInt32("profondeur"), reader.GetInt32("Enstock"), reader.GetInt32("Stock minimum"),reader.GetString("Code"), reader.GetString("Dimensions(cm)"));
            }
            reader.Close();
        }


        private static void SetCupboardAnglesComponents(string value, MySqlConnection conn)
        {
            var reader = DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.CupboardAngles.AddCupboardAngle(reader.GetString("Couleur"), reader.GetInt32("hauteur"), 0, 0, reader.GetInt32("Enstock"), reader.GetInt32("Stock minimum"), reader.GetString("Code"), reader.GetString("Dimensions(cm)"));
            }
            reader.Close();
        }

        /// <summary>
        /// Search all the components with the box dimensions
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="width"></param>
        /// <param name="depth"></param>
        /// <param name="height"></param>
        /// <param name="colorDoor"></param>
        /// <param name="colorPanel"></param>
        /// <param name="cupboard"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static Dictionary<string, Dictionary<string, object>> SearchComponent(int uid, string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard, Order.Order order, MySqlConnection conn)
        {

            Dictionary<string, Dictionary<string, object>> componentDict = new Dictionary<string, Dictionary<string, object>>();

            conn.Open();

            var panelBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", width, height, colorPanel, "Panneau Ar", conn);
            componentDict.Add("PanelBack", ReaderData(order, panelBack, typeof(Panel)));

            var panelSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "hauteur", "Couleur", "Ref", depth, height, colorPanel, "Panneau GD", conn);
            //componentDict.Add("PanelSide", (Panel)ReaderData(panelSides, typeof(Panel)));
            componentDict.Add("PanelSides", ReaderData(order, panelSides, typeof(Panel)));

            var panelHB = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Couleur", "Ref", width, depth, colorPanel, "Panneau HB", conn);
            //componentDict.Add("PanelHB", (Panel)ReaderData(panelHB, typeof(Panel)));
            componentDict.Add("PanelHB", ReaderData(order, panelHB, typeof(Panel)));


            if (colorDoor != "I don't want a door")
            {
                string size;
                if (width == "62") {
                    size = ((Int32.Parse(width) + 2) / 2).ToString();
                }
                else
                {
                    size = (Int32.Parse(width) / 2 + 2).ToString();
                }

                var door = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", size, (height).ToString(), colorDoor, "Porte", conn);
                //componentDict.Add("Door", (Specs)ReaderData(door, typeof(Door)));
                componentDict.Add("Door", ReaderData(order, door, typeof(Door)));
            }
            else
            {
                Console.WriteLine("No doors");
                componentDict.Add("Door", new Dictionary<string, object>(){ {"Component", null} });
            }

            var slider = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", "0", height, "", "Tasseau", conn);
            //componentDict.Add("Slider", (Slider)ReaderData(slider, typeof(Slider)));
            componentDict.Add("Slider", ReaderData(order, slider, typeof(Slider)));

            var traverseFront = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Av", "Traverse Av", conn);
            //componentDict.Add("TraverseFront", (Traverses)ReaderData(traverseFront, typeof(Traverses)));
            componentDict.Add("TraverseFront", ReaderData(order, traverseFront, typeof(Traverses)));

            var traverseBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Ar", "Traverse Ar", conn);
            //componentDict.Add("TraverseBack", (Traverses)ReaderData(traverseBack, typeof(Traverses)));
            componentDict.Add("TraverseBack", ReaderData(order, traverseBack, typeof(Traverses)));

            var traverseSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "largeur", "Ref", "Ref", depth, "0", "Traverse GD", "Traverse GD", conn);
            //componentDict.Add("TraverseSide", (Traverses)ReaderData(traverseSides, typeof(Traverses)));
            componentDict.Add("TraverseSides", ReaderData(order, traverseSides, typeof(Traverses)));

            var cups = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "largeur", "Ref", "Ref", "0", "0", "Coupelles", "Coupelles", conn);
            //componentDict.Add("Cups", colorDoor !=  "I don't want a door" && colorDoor != "Verre" ? (Cups)ReaderData(cups, typeof(Cups)) : null);
            componentDict.Add("Cups", colorDoor != "I don't want a door" && colorDoor != "Verre" ? ReaderData(order, cups, typeof(Cups)) : new Dictionary<string, object>() { {"Component", null} });

            conn.Close();

            return componentDict;

        }

        /// <summary>
        /// Transform the given reader to the component of type type
        /// </summary>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Dictionary<string, object> ReaderData(Order.Order order, MySqlDataReader component, Type type)
        {
 
            if (type.Name == "Panel")
            {
                component.Read();

                Panel panel = new Panel(component.GetString("Couleur"), component.GetString("Ref").Replace("Panneau ", ""), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                var dict = new Dictionary<string, object>();
                dict.Add("Component", panel);
                dict.Add("Available", CheckAvailable(order, panel));

                component.Close();

                return dict;
            }
            else if (type.Name == "Door")
            {
                component.Read();

                Door door = new Door(component.GetString("Couleur"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                var dict = new Dictionary<string, object>();
                dict.Add("Component", door);
                dict.Add("Available", CheckAvailable(order, door));

                component.Close();


                return dict;
            }
            else if (type.Name == "Slider")
            {
                component.Read();

                Slider slider = new Slider(component.GetInt32("hauteur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                var dict = new Dictionary<string, object>();
                dict.Add("Component", slider);
                dict.Add("Available", CheckAvailable(order, slider));

                component.Close();

                return dict;
            }
            else if (type.Name == "Traverses")
            {
                component.Read();

                Traverses traverses = new Traverses(component.GetString("Ref"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                var dict = new Dictionary<string, object>();
                dict.Add("Component", traverses);
                dict.Add("Available", CheckAvailable(order, traverses));

                component.Close();

                return dict;
            }
            else if (type.Name == "Cups")
            {
                component.Read();

                Cups cups = new Cups(component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                var dict = new Dictionary<string, object>();
                dict.Add("Component", cups);
                dict.Add("Available", CheckAvailable(order, cups));

                component.Close();

                return dict;
            }
            
            return null;

        }

        public static bool CheckAvailable(Order.Order order, Specs component)
        {
            return component.IsInStock(order.GetQuantityCode(component.Code) + component.CountComponents());
        }

        public static CupboardAngle SearchCupboardAngle(int height, string color, MySqlConnection conn)
        {

            CupboardAngle cupboardAngle;
            conn.Open();

            if (height%36 == 0 || height%46 == 0 || height%56 == 0)
            {
                var cupboardReader = DBMethods.DataBaseMethods.SqlSearchComponent("Piece", "Ref", "hauteur", "Couleur", "Couleur", "Cornieres", height.ToString(), color, color, conn);
                cupboardReader.Read();

                cupboardAngle = new CupboardAngle(cupboardReader.GetString("Couleur"), cupboardReader.GetInt32("hauteur"), cupboardReader.GetInt32("largeur"), cupboardReader.GetInt32("profondeur"), cupboardReader.GetInt32("Enstock"), cupboardReader.GetInt32("Stock minimum"), cupboardReader.GetString("Code"), cupboardReader.GetString("Dimensions(cm)"));

                cupboardReader.Close();
            }
            else
            {
                var reader = DBMethods.DataBaseMethods.SqlSearchCupboardAngle(color, height, conn);

                Dictionary<string, string> min = new Dictionary<string, string>() { {"Height", "50000"} };
                while (reader.Read())
                {
                    if (int.Parse(reader["hauteur"].ToString()) < int.Parse(min["Height"]))
                    {
                        min = new Dictionary<string, string>(){
                            { "Ref", reader["Ref"].ToString() },
                            { "Code", reader["Code"].ToString() },
                            { "Dimensions", reader["Dimensions(cm)"].ToString() },
                            { "Height", reader["hauteur"].ToString() },
                            { "Width", reader["largeur"].ToString() },
                            { "Depth", reader["profondeur"].ToString() },
                            { "Color", reader["Couleur"].ToString() },
                            { "Stock", reader["Enstock"].ToString() },
                            { "StockMin", reader["Stock minimum"].ToString() },
                            { "SupplierOnePrice", reader["Prix-Fourn 1"].ToString() },
                            { "SupplierTwoPrice", reader["Prix-Fourn2"].ToString() },
                            { "SupplierOneDelay", reader["Delai-Fourn 1"].ToString() },
                            { "SupplierTwoDelay", reader["Delai-Fourn2"].ToString() },
                        };
                    }
                }
                Console.WriteLine($"Cupboard angle fund :{min["Height"]} cm !");
                cupboardAngle = new CupboardAngle(min["Color"], int.Parse(min["Height"]), int.Parse(min["Width"]), int.Parse(min["Depth"]), int.Parse(min["Stock"]), int.Parse(min["StockMin"]), min["Code"], min["Dimensions"]);
                reader.Close();
            }

            conn.Close();
            return cupboardAngle;
        }


    }
}
