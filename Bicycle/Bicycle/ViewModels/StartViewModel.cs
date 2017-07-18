using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bicycle.Views;
using Xamarin.Forms;
using System.Windows.Input;

namespace Bicycle.ViewModels
{
    class StartViewModel
    {
        private StartPage startPage;
        //public ICommand LogInCommand { get; set; }

        public StartViewModel(StartPage startPage)
        {
            this.startPage = startPage;
            //LogInCommand = new Command(async () => await LoginAsync());
        }

        //private bool _logInIsAvailable;
        //public bool LogInIsAvailable
        //{
        //    get
        //    {
        //        return _logInIsAvailable;
        //    }
        //    set
        //    {
        //        _logInIsAvailable = value;
        //        OnPropertyChanged(nameof(LogInIsAvailable));
        //    }
        //}

        //LogInButton.SetBinding(IsVisibleProperty, nameof(StartViewModel.LogInIsAvailable));
    }
}
