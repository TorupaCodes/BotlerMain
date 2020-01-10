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
    public partial class NewGroceryPage : ContentPage
    {
        public NewGroceryPage()
        {
            InitializeComponent();
        }
        private bool CrashCheck()
        {
            bool boolError = false;
            if (PickerGrocery.SelectedItem == null && boolError == false)
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
            await Navigation.PushAsync(new GroceryPage());

        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrashCheck())
                {
                    Grocery grocery = new Grocery()

                    {
                        // Zet de naam van de binding 'Name' die gedefineeërd is in de MainPage.
                        Name = (String)PickerGrocery.SelectedItem,
                        // Zet de Nummer van de binding 'Name' die gedefineeërd is in de MainPage.
                        Number = (Int32)(Convert.ToInt32(EntryAmount.Text))
                    };
                    using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
                    {

                        // Maak een nieuwe table aan als deze nog niet aangemaakt is.
                        connection.CreateTable<Grocery>();
                        // Een variable voor het toevoegen van een  nieuwe boodschap. 
                        var numberOfRows = connection.Insert(grocery);
                        // Een string die de naam van de boodschap en het aantal toont. (Temporary fix)
                        string Aantalstring = grocery.Name + " is " + Convert.ToString(EntryAmount.Text) + " keer toegevoegd aan het boodschappenlijstje!";
                        // Als dus numberofrows groter is dan 0 is er iets toegevoegd. (Dus success)
                        if (numberOfRows > 0)
                            DisplayAlert("Gedaan!", Aantalstring, "Terug");
                        else
                            DisplayAlert("Fout", "De boodschap is niet toegevoegd.", "Terug");


                        // Er kan maar een connectie tergelijke tijd zijn!
                        // connection.Dispose(); // Dit zorgt er voor dat de connectie weg gaat!!
                        // Maar de using statement doet dat al voor ons.
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception has been caught! " + ex);
            }
        }
    }
}