using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BotlerMain.Views
{
    public partial class MyRecipePageDetail : ContentPage
    {
        public MyRecipePageDetail(string Name, string Ingredients, string source, string Bereiding)
        {
            InitializeComponent();

            MyItemNameShow.Text = Name;
            MyIngrediantItemShow.Text = Ingredients;
            MyBereidingItem.Text = Bereiding;
            try
            {
                MyImageCall.Source = new UriImageSource()

                {
                    Uri = new Uri(source)
                };
            } catch (Exception err)
            {
                Console.WriteLine(err);

            }


        }
    }
}