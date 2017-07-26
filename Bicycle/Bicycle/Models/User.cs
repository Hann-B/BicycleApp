using Java.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;

namespace Bicycle.Models
{
    public class User : BaseDataObject
    {
        public enum Role
        {
            Guides,
            Rentals,
            Hosts,
            Clients
        }

        public IList<Role> Roles = new List<Role>();
        public bool IsUserInRole(Role r)
        {
            return this.Roles.Any(a => a == r);
        }
        public User AddUserToRole(Role r)
        {
            this.Roles.Add(r);
            return this;
        }

        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        string name = string.Empty;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        string bio = string.Empty;
        public string Bio
        {
            get { return bio; }
            set { SetProperty(ref bio, value); }
        }

        string experience = string.Empty;
        public string Experience
        {
            get { return experience; }
            set { SetProperty(ref experience, value); }
        }

        string specialties = string.Empty;
        public string Specialties
        {
            get { return specialties; }
            set { SetProperty(ref specialties, value); }
        }

        string photo = string.Empty;
        public string Photo
        {
            get { return photo; }
            set { SetProperty(ref photo, value); }
        }

        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        string phone = string.Empty;
        public string Phone
        {
            get { return phone; }
            set { SetProperty(ref phone, value); }
        }

        string location = string.Empty;
        public string Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        //[NumberFormatInfo.CurrentInfo()]
        decimal price = 0;
        public decimal Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        string products = string.Empty;
        public string Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

        string services = string.Empty;
        public string Services
        {
            get { return services; }
            set { SetProperty(ref services, value); }
        }

        string website = string.Empty;
        public string Website
        {
            get { return website; }
            set { SetProperty(ref website, value); }
        }

        string school = string.Empty;
        public string School
        {
            get { return school; }
            set { SetProperty(ref school, value); }
        }

        IEnumerable<Trip> pastTrips = null;
        public IEnumerable<Trip> PastTrips
        {
            get { return pastTrips; }
            set { SetProperty(ref pastTrips, value); }
        }

        IEnumerable<Trip> futureTrips = null;
        public IEnumerable<Trip> FutureTrips
        {
            get { return futureTrips; }
            set { SetProperty(ref futureTrips, value); }
        }
    }
}