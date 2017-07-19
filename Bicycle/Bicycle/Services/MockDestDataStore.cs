using Bicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bicycle.Services.MockDestDataStore))]
namespace Bicycle.Services
{
    class MockDestDataStore: IDestData<Destination>
    {
        bool isInitialized;
        List<Destination> destinations;

        public async Task<bool> AddDestinationAsync(Destination destination)
        {
            await InitializeAsync();

            destinations.Add(destination);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateDestinationAsync(Destination destination)
        {
            await InitializeAsync();

            var _destination = destinations.Where((Destination arg) => arg.Id == destination.Id).FirstOrDefault();
            destinations.Remove(_destination);
            destinations.Add(destination);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDestinationAsync(Destination destination)
        {
            await InitializeAsync();

            var _destination = destinations.Where((Destination arg) => arg.Id == destination.Id).FirstOrDefault();
            destinations.Remove(_destination);

            return await Task.FromResult(true);
        }

        public async Task<Destination> GetDestinationAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(destinations.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Destination>> GetDestinationsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(destinations);
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

            destinations = new List<Destination>();
            var _destinations = new List<Destination>
            {
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#1", Location="Breckenridge, CO", NumOfTrails="93 trails"},
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#2", Location="Winter Park, CO", NumOfTrails="64 trails"},
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#3", Location="Salida, CO", NumOfTrails="119 trails"},
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#4", Location="Crested Butte, CO", NumOfTrails="91 trails"},
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#5", Location="Victor, ID", NumOfTrails="55 trails"},
                new Destination { Id = Guid.NewGuid().ToString(), PlaceNumber="#6", Location="Park City, UT", NumOfTrails="39 trails"}
            };

            foreach (Destination destination in _destinations)
            {
                destinations.Add(destination);
            }

            isInitialized = true;
        }
    }
}

