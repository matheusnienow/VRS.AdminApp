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
        internal List<Rent> GetRents()
        {
            var result = service.GetRentsAsync().Result;
            return result.Select(x => new Rent(x)).ToList();
        }
    }
}
