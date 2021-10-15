using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WindowsLiderEntrega.Models;

namespace WindowsLiderEntrega.Interfaces
{
    public interface ITestService
    {
        Task<Models.Saldo[]> CalcularSaldosAsync(Action<int> progressCallBack);
        Task SaveDataAsync(string user, string password, Models.Saldo[] saldos);
        Task<string> GetKeyAsync(long cuenta);
    }
}
