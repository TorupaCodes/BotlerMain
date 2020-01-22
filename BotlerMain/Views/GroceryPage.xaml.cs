using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
            NavigationPage.SetHasBackButton(this, false);

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

            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            try
            {
                Accelerometer.Start(SensorSpeed.Game);

            } 
            catch (Exception err)
            {

            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
            Console.WriteLine("GroceryPage disappearing");
            //Navigation.PopAsync();


        }
        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            DisplayAlert("Veel speel plezier!", "Sloop de botler niet!", "Oké!");
            Navigation.PushModalAsync(new ControllerPage());
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new N());
            await Navigation.PushAsync(new NewGroceryPage());

        }

        private void Verwijder_Clicked(object sender, EventArgs e)
        {
            // Het geselecteerde item in de listview.
            var Geselecteerd = (Grocery)GroceryListView.SelectedItem;
            // Als er niks geselecteerd is en persoon drukt op de knop, doe niks.
            if (Geselecteerd == null) return;
            Grocery grocery = new Grocery();
            grocery.Delete(Geselecteerd.Id);
            DisplayAlert("Succes!", Convert.ToString(Geselecteerd.Name) + " is verwijderd!", "Breng me terug");
            OnAppearing();
        }
        private void MovetoVoorraad_Clicked(object sender, EventArgs e)
        {
            var Geselecteerd = (Grocery)GroceryListView.SelectedItem;
            if (Geselecteerd == null) return;
            Grocery grocery = new Grocery();
            grocery.Move(Geselecteerd.Id, Geselecteerd.Name, Geselecteerd.Number);
            DisplayAlert("Succes!", Convert.ToString(Geselecteerd.Name) + " is verplaatst", "Breng me terug");
            OnAppearing();
            
        }
    }
}