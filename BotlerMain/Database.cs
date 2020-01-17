using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace BotlerMain
{
    class Persoon
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Leeftijd { get; set; }

        public Persoon(string name, int leeftijd)
        {
            Name = name;
            Leeftijd = leeftijd;
        }

        public bool VoegToe()
        {


            return true;

        }

        public class ExecuteDatabase
        {
            public void Main()
            {
                // Intialize a new object.
                Persoon persoon1 = new Persoon("Pieter", 55);
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                {

                    // Maak een nieuwe table aan als deze nog niet aangemaakt is.
                    connection.CreateTable<Grocery>();
                    connection.Insert(persoon1);
                };
            }

        }
    }


}
