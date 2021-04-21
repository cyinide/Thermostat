using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Thermostat.ViewModels.Base;
using Xamarin.Forms;

namespace Thermostat.ViewModels
{
    public class ThermostatViewModel : BaseViewModel
    {
        public ThermostatViewModel()
        {
            SegmentedCollection = new ObservableCollection<SfSegmentItem>
        {
            new SfSegmentItem(){IconFont = "6", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Day"},
            new SfSegmentItem(){IconFont = "6", FontIconFontColor=Color.FromHex("#FFFFFF"), FontColor=Color.FromHex("#FFFFFF"), Text = "Week"}
        };
        }

        private ObservableCollection<SfSegmentItem> _segmentedCollection;
        public ObservableCollection<SfSegmentItem> SegmentedCollection
        {
            get { return _segmentedCollection; }
            set { _segmentedCollection = value; }
        }
    }
}
