using System;
using System.Collections.Generic;
using System.Text;
using BotlerMain;
using SQLite;

namespace BotlerMain.Models
{
    public class MyRecipeModel
    {
        [PrimaryKey]
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Image { get; set; }
        public string Ingredients { get; set; }
        public string Bereiding { get; set; }




    }
}
