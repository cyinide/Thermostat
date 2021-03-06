using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;

namespace Thermostat.Android
{
    [Activity(Label = "Thermostat", Icon = "@drawable/thermostat", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("NDMzNTM3QDMxMzkyZTMxMmUzMFdyL1BjcFhFWkF5bGJxSktQbXI1aWM0d0lPVEViZkNad2htd1lXRCtLd0k9");

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

