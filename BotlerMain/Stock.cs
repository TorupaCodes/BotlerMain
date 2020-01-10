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
    }
}
