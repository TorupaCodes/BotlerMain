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
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Console.WriteLine("Stockpage is verlaten");
            var vUpdatedPage = new Stockpage(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
            Navigation.PopAsync();

        }
        private bool CrashCheck()
        {
            bool boolError = false;
            if (PickerStock.SelectedItem == null && boolError == false)
            {
                DisplayAlert("Fout", "Voer een boodschap in", "Probeer het overnieuw.");
                boolError = true;
                Console.WriteLine("CrashCheck1 " + boolError);

            }
            if (string.IsNullOrWhiteSpace(EntryAmount.Text) && boolError == false)
            {
                DisplayAlert("Fout", "Voer een aantal in", "Probeer het overnieuw.");
                boolError = true;
                Console.WriteLine("CrashCheck2" + boolError);
            }
            if (EntryAmount.Text.Length > 9 && boolError == false)
            {
                DisplayAlert("Fout", "Te veel boodchappen ", "Probeer het overnieuw.");
                boolError = true;
                Console.WriteLine("CrashCheck3 " + boolError, "Probeer het overnieuw.");
            }
            if (EntryAmount.Text.Contains("-") || (EntryAmount.Text.Contains(".") && boolError == false))
            {
                DisplayAlert("Failed", "Het aantal kan geen '-' of '.' bevatten.", "Try again");
                boolError = true;
                Console.WriteLine("CrashCheck4 " + boolError);
            }
            if (Convert.ToInt32(EntryAmount.Text) <= 0 && boolError == false)
            {
                DisplayAlert("Failed", "You need to enter a value higher than 0 you bonobo ", "Go back you and try again ");
                boolError = true;
                Console.WriteLine("CrashCheck4 " + boolError);
            }
            return boolError;
        }
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            var vUpdatedPage = new GroceryPage(); Navigation.InsertPageBefore(vUpdatedPage, this); await Navigation.PopAsync();
            await Navigation.PopModalAsync();

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                if(!CrashCheck())
                {
                    Stock stock = new Stock()
                    {
                        Name = (String)PickerStock.SelectedItem,
                        Number = (Int32)(Convert.ToInt32(EntryAmount.Text))

                    };
                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                    {
                        connection.CreateTable<Stock>();

                        var NumberOfRows = connection.Insert(stock);

                        string Aantalstring = stock.Name + " is " + Convert.ToString(EntryAmount.Text) + " keer toegevoegd aan de voorraad!!";
                        // Als dus numberofrows groter is dan 0 is er iets toegevoegd. (Dus success)
                        if (NumberOfRows > 0)
                            DisplayAlert("Gedaan!", Aantalstring, "Terug");
                        else
                            DisplayAlert("Fout", "De boodschap is niet toegevoegd.", "Terug");
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("error op gevange in NewStockPage " + ex);
            }
        }
            
    }
}