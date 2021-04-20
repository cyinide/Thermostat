using System;
using System.Collections.Generic;
using System.Text;
using Thermostat.ViewModels.Base;

namespace Thermostat.ViewModels
{
    public class ThermostatViewModel : BaseViewModel
    {
        public ThermostatViewModel()
        {

        }
        public string _stringtest = "teststring";
        public string StringTest
        {
            get
            {
                return _stringtest;
            }
            set
            {
                _stringtest = value;
                RaisePropertyChanged(() => StringTest);
            }
        }
    }
}
