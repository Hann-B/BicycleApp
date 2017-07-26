using Bicycle.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bicycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : TabbedPage
    {
        public StartPage()
        {
            this.Children.Add(new TopDestinationsPage());
            this.Children.Add(new PlanATripPage());
            this.Children.Add(new ItemsPage());

            InitializeComponent();

            this.BindingContext = new StartViewModel(this);
            //HandleLogInButton();
            //HandleSettingsButton();
        }


        private async void LogInItem_Clicked(object sender, EventArgs e)
        {           
                await Navigation.PushAsync(new OAuthNativeFlowPage());           
        }

        private async void UserSettingsItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new UserSettingsPage()));
        }

        //private ToolbarItem TBILogIn;
        //private ToolbarItem TBISettings;

        //#region Log In Button
        //private void HandleLogInButton()
        //{
        //    if (((ViewModels)this.BindingContext).LogInVisible)
        //    {
        //        LogInButtonAdd();
        //    }
        //    else
        //    {
        //        LogInButtonRemove();
        //    }
        //}

        //private void LogInButtonAdd()
        //{
        //    if (this.ToolbarItems.Count == 0)
        //    {
        //        TBILogIn = new ToolbarItem();
        //        TBILogIn.Name = "LogInItem";
        //        TBILogIn.Activated += (s, e) =>
        //        {
        //            ((ViewModels)this.BindingContext).CommandLogInExecute();
        //        };
        //        this.ToolbarItems.Add(TBILogIn);
        //    }
        //}

        //private void LogInButtonRemove()
        //{
        //    if (this.ToolbarItems.Count > 0)
        //    {
        //        this.ToolbarItems.Remove(TBILogIn);
        //    }
        //}
        //#endregion Log In Button

        //#region Settings Button
        //private void HandleSettingsButton()
        //{
        //    if (((ViewModels)this.BindingContext).SettingsVisible)
        //    {
        //        SettingsButtonAdd();
        //    }
        //    else
        //    {
        //        SettingsButtonRemove();
        //    }
        //}

        //private void SettingsButtonAdd()
        //{
        //    if (this.ToolbarItems.Count == 0)
        //    {
        //        TBISettings = new ToolbarItem();
        //        TBISettings.Name = "UserSettingsItem";
        //        TBISettings.Activated += (s, e) =>
        //        {
        //            ((ViewModels)this.BindingContext).CommandSettingsExecute();
        //        };
        //        this.ToolbarItems.Add(TBISettings);
        //    }
        //}

        //private void SettingsButtonRemove()
        //{
        //    if (this.ToolbarItems.Count > 0)
        //    {
        //        this.ToolbarItems.Remove(TBISettings);
        //    }
        //}
        //#endregion Settings Button

    }
}