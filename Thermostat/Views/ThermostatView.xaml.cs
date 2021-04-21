using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thermostat.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Thermostat.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThermostatView : ContentPage
    {
        public ThermostatView()
        {
            InitializeComponent();
        } 
    }
}