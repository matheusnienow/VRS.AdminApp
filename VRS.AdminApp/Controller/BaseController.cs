using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Controller
{
    abstract class BaseController
    {
        protected ServiceClient service;

        public BaseController()
        {
            service = new ServiceClient();
        }
    }
}