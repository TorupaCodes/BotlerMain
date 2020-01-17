using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotlerMain.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BotlerMain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRecipePage : ContentPage
    {
        public NewRecipePage()
        {
            InitializeComponent();
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            MyRecipeModel Recipe = new MyRecipeModel()
            {
                
                      

                        Name = (String)EntryRecipe.Text,
                        Detail = (String)EntryDetail.Text,
                        Ingredients = (String)EntryIngredients.Text,
                        Bereiding = (String)EntryBereiding.Text,
            };
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection((App.DB_PATH)))
            {

                // Maak een nieuwe table aan als deze nog niet aangemaakt is.
                connection.CreateTable<MyRecipeModel>();
                // Een variable voor het toevoegen van een  nieuw Recept. 
                var numberOfRows = connection.Insert(Recipe);
                // Een string die de naam van het recept toont.
                string RecipeName = Recipe.Name + " is toegevoegd aan het boodschappenlijstje!";
                // Als dus numberofrows groter is dan 0 is er iets toegevoegd. (Dus success)
                if (numberOfRows > 0)
                    DisplayAlert("Gedaan!", RecipeName, "Terug");
                else
                    DisplayAlert("Fout", "Het recept is niet toegevoegd.", "Terug");


                // Er kan maar een connectie tergelijke tijd zijn!
                // connection.Dispose(); // Dit zorgt er voor dat de connectie weg gaat!!
                // Maar de using statement doet dat al voor ons.
            };




           



            }
            
        }

    }