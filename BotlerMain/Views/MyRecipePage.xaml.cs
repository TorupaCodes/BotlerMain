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
        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {
            var mydetails = e.Item as MyRecipeModel;
            await Navigation.PushAsync(new MyRecipePageDetail(mydetails.Name, mydetails.Ingredients, mydetails.Bereiding, mydetails.Image));

        }
        private void Add_Clicked(object sender, EventArgs e)
        {

        }
    }
}