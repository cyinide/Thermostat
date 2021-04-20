using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

using Syncfusion.SfImageEditor.XForms.iOS;

using Syncfusion.SfGauge.XForms.iOS;

using Syncfusion.SfNumericTextBox.XForms.iOS;

using Syncfusion.SfNumericUpDown.XForms.iOS;

using Syncfusion.XForms.iOS.Buttons;

namespace Thermostat.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("NDMzNTM3QDMxMzkyZTMxMmUzMFdyL1BjcFhFWkF5bGJxSktQbXI1aWM0d0lPVEViZkNad2htd1lXRCtLd0k9");

            global::Xamarin.Forms.Forms.Init();
            
			SfImageEditorRenderer.Init();
			
			
			SfGaugeRenderer.Init();
			
			
			SfNumericTextBoxRenderer.Init();
			
			
			SfNumericUpDownRenderer.Init();
			
			
			SfSegmentedControlRenderer.Init();
			
			LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
