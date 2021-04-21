using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thermostat.ViewModels.Base;
using Xamarin.Forms;

namespace Thermostat.ViewModels
{
    public enum Mode
    {
        Heating,
        Cooling
    }

    public class ThermostatViewModel : BaseViewModel
    {
        public ThermostatViewModel()
        {
            SegmentBindings();
        }
        public override Task OnAppearing()
        {
            return base.OnAppearing();
        }

        bool isInitial = true;

        private ObservableCollection<SfSegmentItem> _segmentedCollection;
        public ObservableCollection<SfSegmentItem> SegmentedCollection
        {
            get
            {
                return _segmentedCollection;
            }
            set
            {
                _segmentedCollection = value;
                RaisePropertyChanged(() => SegmentedCollection);
            }
        }

        private int _selectedMode;
        public int SelectedMode
        {
            get
            {
                return _selectedMode;
            }
            set
            {
                _selectedMode = value;
                SetupThermostat(value);

                RaisePropertyChanged(() => SelectedMode);
            }
        }

        private Color _modeColor = Color.FromHex("#F6392F");
        public Color ModeColor
        {
            get
            {
                return _modeColor;
            }
            set
            {
                _modeColor = value;
                RaisePropertyChanged(() => ModeColor);
            }
        }
        private void SetupThermostat(int value)
        {
            if (isInitial)
            {
                SegmentedCollection.ElementAt(1).FontIconFontColor = Color.FromHex("#888889");
                DesiredTemperature = 22.0;
                isInitial = false;
                return;
            }
            if (value == (int)Mode.Heating)
            {
                DesiredTemperature = ActualTemperature + 1.0;
                ModeColor = Color.FromHex("#F6392F");
                SegmentedCollection.ElementAt(0).FontIconFontColor = Color.White;
                SegmentedCollection.ElementAt(1).FontIconFontColor = Color.FromHex("#888889");
            }
            else
            {
                DesiredTemperature = ActualTemperature - 1.0;
                ModeColor = Color.FromHex("#392ff6");
                SegmentedCollection.ElementAt(1).FontIconFontColor = Color.White;
                SegmentedCollection.ElementAt(0).FontIconFontColor = Color.FromHex("#888889");
            }
        }

        private double _actualTemperature = 17.0;
        public double ActualTemperature
        {
            get
            {
                return _actualTemperature;
            }
            set
            {
                _actualTemperature = value;
                RaisePropertyChanged(() => ActualTemperature);
            }
        }

        private double _desiredTemperature;
        public double DesiredTemperature
        {
            get
            {
                return _desiredTemperature;
            }
            set
            {
                _desiredTemperature = value;
                RaisePropertyChanged(() => DesiredTemperature);
            }
        }

        public ICommand IncreaseTemperatureCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedMode == (int)Mode.Heating && DesiredTemperature >= 36.0)
                        return;
                    if (SelectedMode == (int)Mode.Cooling && DesiredTemperature >= ActualTemperature)
                        return;

                    ++DesiredTemperature;
                });
            }
        }
        public ICommand DecreaseTemperatureCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (SelectedMode == (int)Mode.Heating && DesiredTemperature <= ActualTemperature)
                        return;
                    if (SelectedMode == (int)Mode.Cooling && DesiredTemperature <= 0.0)
                        return;

                    --DesiredTemperature;
                });
            }
        }
        private void SegmentBindings() => SegmentedCollection = new ObservableCollection<SfSegmentItem>
        {
            new SfSegmentItem(){IconFont = "\xf2c8", Text = "Heating"},
            new SfSegmentItem(){IconFont = "\xf2dc", Text = "Cooling"}
        };
    }
}
