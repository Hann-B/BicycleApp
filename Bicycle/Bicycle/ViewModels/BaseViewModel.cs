

using Bicycle.Helpers;
using Bicycle.Models;
using Bicycle.Services;
using Xamarin.Forms;

namespace Bicycle.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Get the azure service instance
        /// </summary>
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public IDestData<Destination> DestData => DependencyService.Get<IDestData<Destination>>();
        public IUserData<User> UserData => DependencyService.Get<IUserData<User>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}

