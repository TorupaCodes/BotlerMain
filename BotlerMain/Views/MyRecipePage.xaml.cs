using BotlerMain.Models;
using BotlerMain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BotlerMain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyRecipePage : ContentPage
    {
        public MyRecipePage()
        {
            InitializeComponent();
            BindingContext = new MyRecipePageViewModel();


        }
        protected override void OnAppearing()
        {
            // Zorgt ervoor dat voordat de applicatie opstart dat de applicatie kan worden aangepast
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<MyRecipeModel>();
                var Recipe = conn.Table<MyRecipeModel>().ToList();
                RecipeList.ItemsSource = Recipe;
                //labCount.Text = Convert.ToString("Er zijn " + Boodschappen.Count + " boodschappen gevonden in het lijstje");



            }
        }
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as MyRecipeModel;
            await Navigation.PushAsync(new MyRecipePageDetail(mydetails.Name, mydetails.Ingredients, mydetails.Bereiding, mydetails.Image));

        }
        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewRecipePage());
        }
    }
}