using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace BotlerMain.Droid
{
    [Activity(Label = "BotlerMain", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            // Database file name
            string fileName = "botler_db.sqlite";
            // De folder van de android telefoon waar het opgeslagen wordt.
            string fileLocation = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Door path.combine te doen combineren we de file location en filename naar bijvoorbeeld: 
            string full_path = Path.Combine(fileLocation, fileName);

            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(full_path));

        }
        protected override void OnStart()
        {
            base.OnStart();
            PickerItems pickerItems = new PickerItems();
            pickerItems.DefaultValues();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}