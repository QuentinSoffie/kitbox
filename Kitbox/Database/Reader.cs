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
        public static Dictionary<string, Specs> SearchComponent(int uid, string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard, MySqlConnection conn)
        {

            Dictionary<String, Specs> componentDict = new Dictionary<string, Specs>();

            conn.Open();

            var panelBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", width, height, colorPanel, "Panneau Ar", conn);
            componentDict.Add("PanelBack", (Panel)ReaderData(panelBack, typeof(Panel)));
            panelBack.Close();

            var panelSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "hauteur", "Couleur", "Ref", depth, height, colorPanel, "Panneau GD",  conn);
            componentDict.Add("PanelSide", (Panel)ReaderData(panelSides, typeof(Panel)));
            panelSides.Close();

            var panelHB = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Couleur", "Ref", width, depth, colorPanel, "Panneau HB", conn);
            componentDict.Add("PanelHB", (Panel)ReaderData(panelHB, typeof(Panel)));
            panelHB.Close();


            if (colorDoor != "I don't want a door")
            {
                string size;
                if (width == "62") {
                    size = ((Int32.Parse(width) + 2 ) / 2).ToString();
                }
                else
                {
                    size = (Int32.Parse(width) / 2 + 2).ToString();
                }

                var door = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", size, (height).ToString(), colorDoor,"Porte", conn);
                componentDict.Add("Door", (Specs)ReaderData(door, typeof(Door)));
                door.Close();
            }
            else
            {
                Console.WriteLine("No doors");
                componentDict.Add("Door", null);
            }

            var slider = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", "0", height, "", "Tasseau", conn);
            componentDict.Add("Slider", (Slider)ReaderData(slider, typeof(Slider)));
            slider.Close();

            var traverseFront = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Av", "Traverse Av", conn);
            componentDict.Add("TraverseFront", (Traverses)ReaderData(traverseFront, typeof(Traverses)));
            traverseFront.Close();

            var traverseBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Ar", "Traverse Ar", conn);
            componentDict.Add("TraverseBack", (Traverses)ReaderData(traverseBack, typeof(Traverses)));
            traverseBack.Close();

            var traverseSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "largeur", "Ref", "Ref", depth, "0", "Traverse GD", "Traverse GD", conn);
            componentDict.Add("TraverseSide", (Traverses)ReaderData(traverseSides, typeof(Traverses)));
            traverseSides.Close();

            var cups = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "largeur", "Ref", "Ref", "0", "0", "Coupelles", "Coupelles", conn);
            componentDict.Add("Cups", colorDoor !=  "I don't want a door" && colorDoor != "Verre" ? (Cups)ReaderData(cups, typeof(Cups)) : null);
            cups.Close();

            conn.Close();

            return componentDict;

        }

        /// <summary>
        /// Transform the given reader to the component of type type
        /// </summary>
        /// <param name="component"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static Object ReaderData(MySqlDataReader component, Type type)
        {
            
            if (type.Name == "Door")
            {
                Specs door = new Specs(0, 0, 0, 0, 0, "", "");
                while (component.Read())
                {
                    door = new Door(component.GetString("Couleur"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                }

                Console.WriteLine(door);
                return door;
            }
            else if (type.Name == "Panel")
            {
                component.Read();
                Panel panel = new Panel(component.GetString("Couleur"), component.GetString("Ref").Replace("Panneau ", ""), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                Console.WriteLine(panel);
                return panel;
            }
            else if (type.Name == "Slider")
            {
                component.Read();
                Slider slider = new Slider(component.GetInt32("hauteur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                Console.WriteLine(slider);
                return slider;
            }
            else if (type.Name == "Traverses")
            {
                component.Read();
                Traverses traverses = new Traverses(component.GetString("Ref"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                Console.WriteLine(traverses);
                return traverses;
            }
            else if (type.Name == "Cups")
            {
                component.Read();
                Cups cups = new Cups(component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                Console.WriteLine(cups);
                return cups;
            }
            
            return null;

        }

    }
}
