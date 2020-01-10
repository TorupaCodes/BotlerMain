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
    public partial class Stockpage : ContentPage
    {
        public Stockpage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            // Zorgt ervoor dat voordat de applicatie opstart dat de applicatie kan worden aangepast
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Stock>();
                var Stock = conn.Table<Stock>().ToList();
                StockListView.ItemsSource = Stock;
                //labCount.Text = Convert.ToString("Er zijn " + Boodschappen.Count + " boodschappen gevonden in het lijstje");



            }
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewStockPage()));
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            // Het geselecteerde item in de listview.
            var Geselecteerd = (Stock)StockListView.SelectedItem;
            // Als er niks geselecteerd is en persoon drukt op de knop, doe niks.
            if (Geselecteerd == null)
            {
                return;
            }
            DisplayAlert("Succes!", Convert.ToString(Geselecteerd.Name) + " is verwijderd!", "Breng me terug");
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Stock>(Geselecteerd.Id);
            OnAppearing();
        }
    }

}
