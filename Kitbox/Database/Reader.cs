﻿using MySql.Data.MySqlClient;
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
        public static List<Specs> SearchComponent(int uid, string width, string depth, string height, string colorDoor, string colorPanel, Cupboard cupboard, MySqlConnection conn)
        {
            Door doorBox;
            List<Panel> panelBox = new List<Panel>();
            List<Traverses> traverseBox = new List<Traverses>();
            Slider sliderBox;

            List<Specs> components = new List<Specs>();

            conn.Open();

            var panelBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur","Ref", width, height, colorPanel, "Panneau Ar", conn);
            panelBox.Add((Panel)ReaderData(panelBack, typeof(Panel)));
            panelBack.Close();

            var panelSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "hauteur", "Couleur", "Ref", depth, height, colorPanel, "Panneau GD",  conn);
            panelBox.Add((Panel)ReaderData(panelSides, typeof(Panel)));
            panelSides.Close();

            var panelHB = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Couleur", "Ref", width, depth, colorPanel, "Panneau HB", conn);
            panelBox.Add((Panel)ReaderData(panelHB, typeof(Panel)));
            panelHB.Close();


            if (colorDoor != "I don't want a door")
            {
                var door = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", (Int32.Parse(width) / 2 + 2).ToString(), (height).ToString(), colorDoor,"Porte", conn);
                doorBox = (Door)ReaderData(door, typeof(Door));
                door.Close();
            }
            else
            {
                doorBox = null;
            }

            var slider = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "hauteur", "Couleur", "Ref", "0", height, "", "Tasseau", conn);
            sliderBox = (Slider)ReaderData(slider, typeof(Slider));
            slider.Close();

            var traverseFront = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Av", "Traverse Av", conn);
            traverseBox.Add((Traverses)ReaderData(traverseFront, typeof(Traverses)));
            traverseFront.Close();

            var traverseBack = DataBaseMethods.SqlSearchComponent("Piece", "largeur", "profondeur", "Ref", "Ref", width, "0", "Traverse Ar", "Traverse Ar", conn);
            traverseBox.Add((Traverses)ReaderData(traverseBack, typeof(Traverses)));
            traverseBack.Close();

            var traverseSides = DataBaseMethods.SqlSearchComponent("Piece", "profondeur", "largeur", "Ref", "Ref", depth, "0", "Traverse GD", "Traverse GD", conn);
            traverseBox.Add((Traverses)ReaderData(traverseSides, typeof(Traverses)));
            traverseSides.Close();

            conn.Close();

            components.Add(doorBox);
            components.Add(sliderBox);
            foreach (Panel panelComponent in panelBox)
            {
                components.Add(panelComponent);
            }
            foreach (Traverses traverseComponent in traverseBox)
            {
                components.Add(traverseComponent);
            }
          
            return components;



        }
        private static Object ReaderData(MySqlDataReader component, Type type)
        {
            if (type.Name == "Door")
            {
                component.Read();
                var test = component.GetString("Couleur");
                Door door = new Door(component.GetString("Couleur"), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"), component.GetString("Dimensions(cm)"));
                Console.WriteLine(door);
                return door;
            }
            else if (type.Name == "Panel")
            {
                component.Read();
                Panel panel = new Panel(component.GetString("Couleur"), component.GetString("Ref").Replace("Panneau ", ""), component.GetInt32("hauteur"), component.GetInt32("largeur"), component.GetInt32("profondeur"), component.GetInt32("Enstock"), component.GetInt32("Stock minimum"), component.GetString("Code"),  component.GetString("Dimensions(cm)"));
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

            return null;

        }

    }
}
