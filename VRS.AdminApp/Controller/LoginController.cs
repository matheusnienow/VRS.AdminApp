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
        internal bool VerifyUser(string username, string password)
        {
            var user = service.VerifyUserAsync(username, password).Result;
            if (user != null && user.RoleId == 1)//verify admin role
            {
                return true;
            }

            return false;
        }
    }
}
