using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Services
{
    public interface IUserData<T>
    {
        Task<bool> AddUserAsync(T user);
        Task<bool> UpdateUserAsync(T user);
        Task<bool> DeleteUserAsync(T user);
        Task<T> GetUserAsync(string id);
        Task<IEnumerable<T>> GetUsersAsync(bool forceRefresh = false);

        Task InitializeAsync();
        Task<bool> PullLatestAsync();
        Task<bool> SyncAsync();
    }
}
