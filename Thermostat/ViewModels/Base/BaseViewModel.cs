using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Thermostat.ViewModels.Base
{
    public class BaseViewModel : ExtendedBindableObject
    {

        public virtual async Task OnAppearing()
        {
            var output = string.Format("ViewModel: {0} is appearing");
            Debug.WriteLine(output);

            await Task.FromResult(true);
        }
        public virtual async Task OnDisappearing()
        {
            var output = string.Format("ViewModel: {0} is disappearing");
            Debug.WriteLine(output);

            await Task.FromResult(true);
        }

    }
}
