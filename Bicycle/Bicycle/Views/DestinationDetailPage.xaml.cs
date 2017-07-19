using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bicycle.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bicycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DestinationDetailPage : ContentPage
    {
        DestinationDetailViewModel viewModel;

        public DestinationDetailPage()
        {
            InitializeComponent();
        }

        public DestinationDetailPage(DestinationDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
        
    }
}