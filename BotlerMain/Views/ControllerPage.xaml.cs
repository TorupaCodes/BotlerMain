using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BotlerMain.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllerPage : ContentPage
    {
        public ControllerPage()
        {
            InitializeComponent();
            Checkifconnected();
        }
        static readonly HttpClient client = new HttpClient();

        public static bool connected = false;
        public static string responseBody = string.Empty;

        public static string textStatus = string.Empty;
        public static string speedStatus = string.Empty;
        public async Task Main(string functie, string IpAdress)
        //string = Status;
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://" + IpAdress + "/" + functie);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                labelSlider.Text = "Snelheid: " + speedStatus;
                labelStatus.Text = textStatus;
                //ChangeTextSpeedStatus(Status: speedStatus);
                //ChangeTextStatus(Status: textStatus);
                Console.WriteLine("DIT IS DE RESPONSE " + responseBody);
                connected = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                connected = false;

                return;

            }

        }
        private async void Checkifconnected()
        {
            while (true)
            {
                Console.WriteLine("Checking if connected");
                while (!connected)
                {
                    ActivityIndicator.IsRunning = true;
                    await Task.Run(() => Main(functie: "Checkifconnected", IpAdress: EntryIp.Text));
                    await Task.Delay(300);
                }
                ActivityIndicator.IsRunning = false;
                Console.WriteLine("Arduino is connected!");
                while (connected)
                {
                    await Task.Run(() => Main(functie: "Checkifconnected", IpAdress: EntryIp.Text));
                    await Task.Delay(3000);
                }
            }
        }
        private void ChangeText(string Status)
        {
            labelStatus.Text = Status;
        }
        private void ChangeTextSpeedStatus(string Status)
        {
            labelSlider.Text = "Snelheid: " + Status;
        }

        private async void Button_Vooruit(object sender, EventArgs e)
        {
            //textStatus = "Vooruit";
            ChangeText(Status: "Vooruit");
            await Task.Run(() => Main(functie: "vooruit", IpAdress: EntryIp.Text));

        }

        private async void Button_Achteruit(object sender, EventArgs e)
        {
            await Task.Run(() => Main(functie: "achteruit", IpAdress: EntryIp.Text));
            ChangeText(Status: "Stoppen");
            //textStatus = "Achteruit";
        }

        private async void Button_Stoppen(object sender, EventArgs e)
        {
            await Task.Run(() => Main(functie: "stilstaan", IpAdress: EntryIp.Text));
            ChangeText(Status: "Stoppen");
            textStatus = "Stoppen";
        }

        private async void Button_Links(object sender, EventArgs e)
        {
            await Task.Run(() => Main(functie: "links", IpAdress: EntryIp.Text));
            ChangeText(Status: "Links");
            //textStatus = "Links";
        }

        private async void Button_Rechts(object sender, EventArgs e)
        {
            await Task.Run(() => Main(functie: "rechts", IpAdress: EntryIp.Text));
            ChangeText(Status: "Rechts");
            //textStatus = "Rechts";
        }
        private async void Button_Midden(object sender, EventArgs e)
        {
            await Task.Run(() => Main(functie: "midden", IpAdress: EntryIp.Text));
            ChangeText(Status: "Midden");
            //textStatus = "Midden";
        }
        private async void Button_Monitor(object sender, EventArgs e)
        {
            bool boolMonitor = false;
            if (boolMonitor == true)
            {
                buttonMonitor.BackgroundColor = Color.FromHex("#E63721");
                boolMonitor = false;
            }
            else boolMonitor = true;
            while (boolMonitor)
            {
                await Task.Run(() => Main(functie: "MonitorRequest", IpAdress: EntryIp.Text));
                buttonMonitor.BackgroundColor = Color.FromHex("#337704");
                labelMonitor.Text = responseBody;
                Console.WriteLine("button_monitor number" + responseBody);
                await Task.Delay(150);

            }
        }
        private double StepValue;
        private async void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepValue = 1.0;
            var newStep = Math.Round(e.NewValue / StepValue);

            SpeedSlider.Value = newStep * StepValue;
            // SOURCE : https://forums.xamarin.com/discussion/22473/can-you-limit-a-slider-to-only-allow-integer-values-hopefully-snapping-to-the-next-integer
            if (SpeedSlider.Value == 0)
            {
                await Task.Run(() => Main(functie: "50", IpAdress: EntryIp.Text));
                labelSlider.Text = "50";
            }
            if (SpeedSlider.Value == 1)
            {
                await Task.Run(() => Main(functie: "75", IpAdress: EntryIp.Text));
                labelSlider.Text = "75";
            }
            if (SpeedSlider.Value == 2)
            {
                await Task.Run(() => Main(functie: "100", IpAdress: EntryIp.Text));
                labelSlider.Text = "100";
            }

        }

    }
}