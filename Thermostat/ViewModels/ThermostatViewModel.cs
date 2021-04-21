using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (value == (int)Mode.Heating)
            {
                DesiredTemperature = ActualTemperature + 1;
                ModeColor = Color.FromHex("#F6392F");
            }
            else
            {
                DesiredTemperature = ActualTemperature - 1;
                ModeColor = Color.FromHex("#392ff6");
            }
        }

        private int _actualTemperature = 17;
        public int ActualTemperature
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

        private int _desiredTemperature = 22;
        public int DesiredTemperature
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
                    if (SelectedMode == (int)Mode.Heating && DesiredTemperature >= 36)
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
                    if (SelectedMode == (int)Mode.Cooling && DesiredTemperature <= 0)
                        return;

                    --DesiredTemperature;
                });
            }
        }
        private void SegmentBindings() => SegmentedCollection = new ObservableCollection<SfSegmentItem>
        {
            new SfSegmentItem(){IconFont = "\xf700", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Heating"},
            new SfSegmentItem(){IconFont = "\xf700", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Cooling"}
        };
    }
}
