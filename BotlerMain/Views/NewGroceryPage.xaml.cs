using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotlerMain.Views;

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
        protected override void OnAppearing()
        {
            base.OnAppearing();
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<PickerItems>();
                var PickerItems = conn.Table<PickerItems>().ToList();
                PickerGrocery.ItemsSource = PickerItems;

            }
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Console.WriteLine("NewGroceryPage is verlaten");
            var vUpdatedPage = new GroceryPage(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
            Navigation.PopAsync();
            NavigationPage.SetHasBackButton(this, false);

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

        private async void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrashCheck())
                {
                    
                    Grocery grocery = new Grocery();
                    try
                        var Geselecteerd = (PickerItems)
                    {
                        grocery.Add((String)TempFixLabel.Text, Convert.ToInt32(EntryAmount.Text));
                        string AlertString = TempFixLabel.Text + " is " + EntryAmount.Text + " keer  toegevoegd aan de boodschappenlijst!";
                        DisplayAlert("Success", AlertString, "Terug");
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine("C# MACHINE BROKE" + error);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error is opgevanggen in NewGroceryPage!" + err);
                DisplayAlert("Oops", "Er is iets fout gegaan, probeer het nog eens.", "Terug");
            }
        }

        private void ButtonPicker_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryPicker.Text)) return;
            PickerItems pickerItems = new PickerItems();
            pickerItems.Add(Name: EntryPicker.Text);

            // Update picker lijst

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                connection.CreateTable<PickerItems>();
                var PickerItems = connection.Table<PickerItems>().ToList();
                PickerGrocery.ItemsSource = PickerItems;
            }

        }
        private void ButtonResetPicker_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                //Console.Writeline(PickerGrocery.SelectedItem.Name);
                connection.DropTable<PickerItems>(); 
                PickerItems pickerItems = new PickerItems();
                pickerItems.DefaultValues();

            }
        }
    }
}