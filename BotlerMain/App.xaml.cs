using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using BotlerMain.Services;
using BotlerMain.Views;

namespace BotlerMain
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public App(string DB_Path)
        {
            InitializeComponent();
            DB_PATH = DB_Path;
            //DependencyService.Register<MockDataStore>();
            //MainPage = new NavigationPage(new AppShell());
            MainPage = new AppShell();
            //NavigationPage.SetHasBackButton(new NewGroceryPage(), false);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
