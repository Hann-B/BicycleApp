using Bicycle.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bicycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserSettingsPage : ContentPage
    {
        UserSettingsViewModel viewModel;

        public UserSettingsPage()
        {
            InitializeComponent();
        }

        public UserSettingsPage(UserSettingsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}