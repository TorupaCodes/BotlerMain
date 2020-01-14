using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BotlerMain
{
    public class Grocery
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; } 

        public int Number { get; set; }
    }
}
