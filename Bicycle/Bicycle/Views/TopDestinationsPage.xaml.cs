using Bicycle.Models;
using Bicycle.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bicycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TopDestinationsPage : ContentPage
    {
        DestinationsViewModel viewModel;

        public TopDestinationsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DestinationsViewModel();
        }

        async void OnDestinationSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var destination = args.SelectedItem as Destination;
            if (destination == null)
                return;

            await Navigation.PushAsync(new DestinationDetailPage(new DestinationDetailViewModel(destination)));

            // Manually deselect item
            DestinationsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Destinations.Count == 0)
                viewModel.LoadDestinationsCommand.Execute(null);
        }
    }
}