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
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Console.WriteLine("NewGroceryPage is verlaten");
            var vUpdatedPage = new GroceryPage(); Navigation.InsertPageBefore(vUpdatedPage, this); Navigation.PopAsync();
            Navigation.PopAsync();

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

        private void Add_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrashCheck())
                {
                    Grocery grocery = new Grocery();
                    grocery.Add((String)PickerGrocery.SelectedItem, Convert.ToInt32(EntryAmount.Text));
                    string AlertString = PickerGrocery.SelectedItem + " is " + EntryAmount.Text + " keer  toegevoegd aan de boodschappenlijst!";
                    DisplayAlert("Success", AlertString, "Terug");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Error is opgevanggen in NewGroceryPage!" + err);
                DisplayAlert("Oops", "Er is iets fout gegaan, probeer het nog eens.", "Terug");
            }
        }
    }
}