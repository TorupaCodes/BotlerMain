using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace BotlerMain
{
   public class Stock
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public void Add(string Name, int Number)
        {
            Stock stock = new Stock()
            {
                Name = Name,
                Number = Number
            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<Stock>();
                connection.Insert(stock);
            }
        }
        public void Delete(int StockId)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Stock>(StockId);
        }
    }

}
