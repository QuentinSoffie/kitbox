using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitbox.Database
{
    public class Reader
    {
       public static void InitializeComponents(MySqlConnection conn)
        {
            Components.Doors.ClearDoor();
            Components.Panels.ClearPanel();
            SetDoorComponents("Porte",conn);
            SetPanelComponents("Panneau GD", conn);
            SetPanelComponents("Panneau Ar", conn);
            SetPanelComponents("Panneau HB", conn);
        }
        private static void SetDoorComponents( string value, MySqlConnection conn)
        {
            var reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Doors.AddDoor(reader.GetString("Couleur"), Int32.Parse(reader.GetString("hauteur")), Int32.Parse(reader.GetString("largeur")), 0);
            }
            reader.Close();
        }

        private static void SetPanelComponents(string value, MySqlConnection conn)
        {
            var reader = DBMethods.DataBaseMethods.SqlSearch("Piece", "Ref", "'" + value + "'", conn);

            while (reader.Read())
            {
                Kitbox.Database.Components.Panels.AddPanel(reader.GetString("Couleur"), value.Replace("Panneau ",""), Int32.Parse(reader.GetString("hauteur")), Int32.Parse(reader.GetString("largeur")), Int32.Parse(reader.GetString("profondeur")));
            }
            reader.Close();
        }

    }
}
