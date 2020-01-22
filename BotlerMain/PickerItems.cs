using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace BotlerMain
{
    public class PickerItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public void Add(string Name)
        {
            PickerItems pickerItems = new PickerItems() { Name = Name };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<PickerItems>();
                connection.Insert(pickerItems);
            }
        }
        public void DefaultValues()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<PickerItems>();
                var AmountOfRows = connection.Table<PickerItems>().Count();
                if(AmountOfRows < 1)
                {
                    Console.WriteLine("Minder dan 1 row gevonden");
                    string[] arrayDefaultValues = { "Appel", "Boter", "Brood", "Cola", "Diepvries Pizza", "Friet", "Frikandel", "Ham", "Kaas", "Karnemelk", "Kipfilet", "Koek", "Macaroni", "Melk", "Pasta", "Peer", "Peperoten", "Popcorn", "Sinaasappel" };
                    foreach (string i in arrayDefaultValues)
                    {
                        PickerItems pickerItems = new PickerItems() { Name = i };
                        connection.CreateTable<PickerItems>();
                        connection.Insert(pickerItems);
                        var test1 = connection.Table<PickerItems>().Count();
                        Console.WriteLine(i + " Dit is toegevoegd");
                    }
                }
            }
        }
        public void DefaultValuesv2()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {

            }
                  
        }
    }
}
