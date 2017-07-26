using Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bicycle.Services.MockUserData))]
namespace Bicycle.Services
{
    class MockUserData : IUserData<User>
    {
        bool isInitialized;
        List<User> users;

        public async Task<bool> AddUserAsync(User user)
        {
            await InitializeAsync();

            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            await InitializeAsync();

            var _user = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(_user);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            await InitializeAsync();

            var _user = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(_user);

            return await Task.FromResult(true);
        }

        public async Task<User> GetUserAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(users);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            users = new List<User>();
            var _users = new List<User>
            {
                new User { Id = Guid.NewGuid().ToString(),
                Name="Lou Lee",
                Bio="Mysterious creature of the night.",
                Experience="Beginner",
                Specialties="Big Wheel",
                Photo="@drawable/loulee.jpg",
                Email="LouLee@LoveLife.com",
                Phone="813.759.4681",
                Location="Tampa, FL",
                Price=15.00M,
                Products="I am the product of my enviornment",
                Services="we can be biking buddies!",
                Website="www.loulee.net",
                School="geography major at Tarpon Springs middle school" }             
            };

            foreach (User user in _users)
            {
                users.Add(user);
            }

            isInitialized = true;
        }
    }
}

