using Bicycle.Helpers;
using Bicycle.Models;
using Bicycle.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bicycle.ViewModels
{
    class DestinationsViewModel:BaseViewModel
    {
        public ObservableRangeCollection<Destination> Destinations { get; set; }
        public Command LoadDestinationsCommand { get; set; }

        public DestinationsViewModel()
        {
            Title = "Top Destinations";
            Destinations = new ObservableRangeCollection<Destination>();
            LoadDestinationsCommand = new Command(async () => await ExecuteLoadDestinationsCommand());
        }

        async Task ExecuteLoadDestinationsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Destinations.Clear();
                var destinations = await DestData.GetDestinationsAsync(true);
                Destinations.ReplaceRange(destinations);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

