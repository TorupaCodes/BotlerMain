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
    public partial class GroceryPage : ContentPage
    {
        public GroceryPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            // Zorgt ervoor dat voordat de applicatie opstart dat de applicatie kan worden aangepast
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Grocery>();
                var Grocery = conn.Table<Grocery>().ToList();
                GroceryListView.ItemsSource = Grocery;
                //labCount.Text = Convert.ToString("Er zijn " + Boodschappen.Count + " boodschappen gevonden in het lijstje");



            }
        }
       /* protected override void OnDisappearing()
        {
            base.OnDisappearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Grocery>();
                var Grocery = conn.Table<Grocery>().ToList();
                GroceryListView.ItemsSource = Grocery;
                //labCount.Text = Convert.ToString("Er zijn " + Boodschappen.Count + " boodschappen gevonden in het lijstje");



            }
        } */

        private async void Add_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NavigationPage(NewGroceryPage()));
            //await Navigation.PushModalAsync(new NewGroceryPage());
            await Navigation.PushAsync(new NewGroceryPage());
            //await Navigation.PushModalAsync(new NavigationPage(new NewGroceryPage()));
        }

        private void Verwijder_Clicked(object sender, EventArgs e)
        {
            // Het geselecteerde item in de listview.
            var Geselecteerd = (Grocery)GroceryListView.SelectedItem;
            // Als er niks geselecteerd is en persoon drukt op de knop, doe niks.
            if (Geselecteerd == null)
            {
                return;
            }

            DisplayAlert("Succes!", Convert.ToString(Geselecteerd.Name) + " is verwijderd!", "Breng me terug");
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Grocery>(Geselecteerd.Id);
            OnAppearing();
        }
        private void MovetoVoorraad_Clicked(object sender, EventArgs e)
        {
            var Geselecteerd = (Grocery)GroceryListView.SelectedItem;
            // Als er niks geselecteerd is en persoon drukt op de knop, doe niks.
            if (Geselecteerd == null)
            {
                return;
            }
            Stock stock = new Stock()
            {
                Name = (String)Geselecteerd.Name,
                Number = (Int32)(Convert.ToInt32(Geselecteerd.Number))

            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<Stock>();
                connection.Insert(stock);
            }
            DisplayAlert("Succes!", Convert.ToString(Geselecteerd.Name) + " is verplaatst", "Breng me terug");
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                connection.Delete<Grocery>(Geselecteerd.Id);
            OnAppearing();

        }
    }
}