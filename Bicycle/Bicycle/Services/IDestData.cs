using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bicycle.Services
{
    public interface IDestData<T>
    {
        Task<bool> AddDestinationAsync(T destination);
        Task<bool> UpdateDestinationAsync(T destination);
        Task<bool> DeleteDestinationAsync(T destination);
        Task<T> GetDestinationAsync(string id);
        Task<IEnumerable<T>> GetDestinationsAsync(bool forceRefresh = false);

        Task InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();
    }
}
