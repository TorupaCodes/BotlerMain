using BotlerMain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BotlerMain.ViewModel
{
    public class MyRecipePageViewModel
    {
        public ObservableCollection<MyRecipeModel> FoodList { get; set; }

        public MyRecipePageViewModel()
        {


            FoodList = new ObservableCollection<MyRecipeModel>();

            FoodList.Add(new MyRecipeModel { Name = "Lasagne", Image = "https://images.smulweb.nl/recepten/201512/1437768/high_res/lasagne.jpg", Detail = "Italiaanse lasagne" });

            FoodList.Add(new MyRecipeModel { Name = "Spaghetti Bolognese", Image = "https://static.ah.nl/static/recepten/img_RAM_PRD121467_890x594_JPG.jpg", Detail = "Italiaanse Spaghetti" });

            FoodList.Add(new MyRecipeModel { Name = "Biefstuk", Image = "https://img.static-rmg.be/a/food/image/q75/w640/h400/1067760/steak-met-puree-van-zoete-aardappelen-en-granaatappelpitjes.jpg", Detail = "Biefstuk met aardappelpuree en dillesaus" });

            FoodList.Add(new MyRecipeModel { Name = "Kofta", Image = "https://eviekookt.nl/wp-content/uploads/2019/01/PSX_20190130_191940.jpg", Detail = "Griekse kofta, gehakt balletjes in een rijke saus van tomaat en courgette en boontjes" });

            FoodList.Add(new MyRecipeModel { Name = "Stampot", Image = "https://wkcatering.nl/wp-content/uploads/2016/11/Stampot-buffet.jpg", Detail = "Varierende traditioneel hollandse stampot" });

            FoodList.Add(new MyRecipeModel { Name = "Salada", Image = "https://www.francescakookt.nl/wp-content/uploads/2019/06/salade-met-avocado-ei-en-sriracha-1.jpg", Detail = "Frisse salade" });

            FoodList.Add(new MyRecipeModel { Name = "FruitSalade", Image = "https://www.24kitchen.nl/files/styles/300h_300w/public/2014-12/145627.original.jpg?itok=LZBk5eKx", Detail = "Heerlijk frisse zomerse fruit salade" });

            FoodList.Add(new MyRecipeModel { Name = "Roerei met Bacon", Image = "https://i1.wp.com/kitchenista.nl/wp-content/uploads/2016/03/roerei-met-bacon.jpg?resize=600%2C320&ssl=1", Detail = "Heerlijk stevig ontbijt" });



        }


    }
}
