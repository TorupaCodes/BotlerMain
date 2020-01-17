
using System;
using System.Collections.Generic;
using System.Text;

using SQLite;


namespace BotlerMain
{
    public class Grocery
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        public void Add(string Name, int Number)
        {
            Grocery grocery = new Grocery()
            {
                Name = Name,
                Number = Number
            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<Grocery>(); 
                connection.Insert(grocery);
            }
        }
        public void Delete(int GroceryId)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Grocery>(GroceryId);
        }
        public void Move(int GroceryId, string GroceryName, int GroceryNumber)
        {
            Stock stock = new Stock()
            {
                Name = GroceryName,
                Number = GroceryNumber
            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<Stock>();
                connection.Insert(stock);
            }
            // Delete uit huidige lijst
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Grocery>(GroceryId);  
        }
    }

    
}
