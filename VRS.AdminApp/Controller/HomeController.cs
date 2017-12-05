using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRS.AdminApp.Model;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Controller
{
    class HomeController : BaseController
    {
        async internal Task<IEnumerable<Rent>> GetRents()
        {
            var result = await service.GetRentsAsync();
            return result.Select(x => new Rent(x));
        }

        async internal Task<IEnumerable<Client>> GetClients()
        {
            var result = await service.GetClientsAsync();
            return result.Select(x => new Client(x));
        }

        async internal Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var result = await service.GetVehiclesAsync();
            return result.Select(x => new Vehicle(x));
        }

        async internal Task<IEnumerable<User>> GetUsers()
        {
            var result = await service.GetUsersAsync();
            return result.Select(x => new User(x));
        }
        async internal Task<bool> FinishRent(Rent rent)
        {
            rent.Finished = true;
            var result = await service.FinishRentAsync(rent.Id);
            return result.Successful;
        }
    }
}
