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
    public partial class NewStockPage : ContentPage
    {
        public NewStockPage()
        {
            InitializeComponent();
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GroceryPage());

        }

        private void Add_Clicked(object sender, EventArgs e)
        {

        }
            
    }
}