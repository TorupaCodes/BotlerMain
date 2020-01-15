using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotlerMain.Models;
using BotlerMain.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BotlerMain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecipePage : ContentPage
    {
        public NewRecipePage()
        {
            InitializeComponent();
        }
        private void AddRecepipe_Clicked(object sender, EventArgs e)
        {
            MyRecipeModel myrecipemodel = new MyRecipeModel()
            {

                Name = EntryRecipe.Text,
                Detail = EntryDetail.Text,
                Ingredients = EntryIngredients.Text,
                Bereiding = EntryBereiding.Text,



            };
            
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
        }
    }
}