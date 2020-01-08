using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BotlerMain.Views
{
    public partial class MyRecipePageDetail : ContentPage
    {
        public MyRecipePageDetail(string Name, string Ingredients, string source)
        {
            InitializeComponent();

            MyItemNameShow.Text = Name;
            MyIngrediantItemShow.Text = Ingredients;
            MyImageCall.Source = new UriImageSource()

            {
                Uri = new Uri(source)
            };

        }
    }
}