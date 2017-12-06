using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VRS.AdminApp.Controller;
using VRS.AdminApp.Model;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.View
{
    public class CreateRentPageController : BaseController
    {
        public async Task<IEnumerable<Client>> GetUsersForName(string clientName)
        {
            var clients = await service.GetClientsForNameAsync(clientName);
            return clients.Select(x => new Client(x));
        }

        public async Task<bool> CreateRent(Rent rent)
        {
            Result result = await service.CreateRentAsync(rent.ToDto());
            return result.Successful;
        }
    }
}