using Bicycle.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bicycle.ViewModels
{
    public class UserSettingsViewModel:BaseViewModel
    {
        public User User { get; set; }
        public IEnumerable<User> Users { get; set; }

        public UserSettingsViewModel()
        {
            Title = "Settings";
            this.User = Users.FirstOrDefault();
        }
        //public UserSettingsViewModel(User user = null)
        //{
        //    Title = "Settings";
        //    User = user;
        //}
    }
}

