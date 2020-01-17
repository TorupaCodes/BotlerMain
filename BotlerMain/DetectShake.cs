using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace BotlerMain
{
    public class DetectShake
    {
        SensorSpeed speed = SensorSpeed.Game;
        public DetectShake()
        {
            // Register for reading changes, be sure to unsubscribe when finished
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
        }

        void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            // Process shake event
        }

        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}
