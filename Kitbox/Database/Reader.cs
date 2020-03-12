using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBMethods;
using Kitbox.Components;

using Kitbox.Order;

namespace Kitbox.Database
{
    public class Reader
    {
        public static void InitializeComponents(MySqlConnection conn)
        {
            conn.Open();
            Components.Doors.ClearDoor();
            Components.Panels.ClearPanel();
            SetDoorComponents("Porte", conn);
            SetPanelComponents("Panneau GD", conn);
            SetPanelComponents("Panneau Ar", conn);
            SetPanelComponents("Panneau HB", conn);
            conn.Close();
        }
        private static void SetDoorComponents(string value, MySqlConnection conn)
        {
            var reader = DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Doors.AddDoor(reader.GetString("Couleur"), reader.GetInt32("hauteur"), reader.GetInt32("largeur"), 0, reader.GetInt32("Enstock"), reader.GetInt32("Stock minimum"));
            }
            reader.Close();
        }

        private static void SetPanelComponents(string value, MySqlConnection conn)
        {
            var reader = DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Panels.AddPanel(reader.GetString("Couleur"), value.Replace("Panneau ", ""), reader.GetInt32("hauteur"), reader.GetInt32("largeur"), reader.GetInt32("profondeur"), reader.GetInt32("Enstock"), reader.GetInt32("Stock minimum"));
            }
            reader.Close();
        }
        public static void SearchComponent(string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard, MySqlConnection conn)
        {
            Door doorBox;
            List<Panel> panelBox = new List<Panel>();
            List<Traverses> traverseBox = new List<Traverses>();
            Slider sliderBox;

            conn.Open();

            var panelBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", width, height, colorPanel, conn);
            panelBox.Add((Panel)ReaderData(panelBack, typeof(Panel)));
            panelBack.Close();

            var panelSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "hauteur", "Couleur", depth, height, colorPanel, conn);
            panelBox.Add((Panel)ReaderData(panelSides, typeof(Panel)));
            panelSides.Close();

            var panelHB = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Couleur", width, depth, colorPanel, conn);
            panelBox.Add((Panel)ReaderData(panelHB, typeof(Panel)));
            panelHB.Close();

            var door = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", width, height, colorDoor, conn);
            doorBox = (Door)ReaderData(door, typeof(Door));
            door.Close();

            var slider = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "0", height, "", conn);
            sliderBox = (Slider)ReaderData(slider, typeof(Slider));
            slider.Close();

            var traverseFront = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", width, "0", "", conn);
            traverseBox.Add((Traverses)ReaderData(traverseFront, typeof(Traverses)));
            traverseFront.Close();

            var traverseBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", width, "0", "", conn);
            traverseBox.Add((Traverses)ReaderData(traverseBack, typeof(Traverses)));
            traverseBack.Close();

            var traverseSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "hauteur", "Couleur", width, "0", "", conn);
            traverseBox.Add((Traverses)ReaderData(traverseSides, typeof(Traverses)));
            traverseSides.Close();

            conn.Close();

            cupboard.AddBox(2, doorBox, sliderBox, panelBox, traverseBox);

        }
        private static Object ReaderData(MySqlDataReader component, Type type)
        {
            if (type.Name == "Door")
            {
                component.Read();
                return new Door(component.GetString("Couleur"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"));
            }
            else if (type.Name == "Panel")
            {
                component.Read();
                return new Panel(component.GetString("Couleur"), component.GetString("Ref").Replace("Panneau ", ""), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"));
            }
            else if (type.Name == "Slider")
            {
                component.Read();
                return new Slider(component.GetInt32("hauteur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"));
            }
            else if (type.Name == "Traverses")
            {
                component.Read();
                return new Traverses(component.GetString("Couleur"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"));

            }
            return null;

        }

    }
}
