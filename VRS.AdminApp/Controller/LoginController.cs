using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Controller
{
    class LoginController : BaseController
    {
        async internal Task<bool> VerifyUser(string username, string password)
        {
            var user = await service.VerifyUserAsync(username, password);
            if (user != null && user.RoleId == 1)//verify admin role
            {
                return true;
            }

            return false;
        }
    }
}
