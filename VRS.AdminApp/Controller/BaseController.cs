using VRS.AdminApp.VRSServiceReference;

namespace VRS.AdminApp.Controller
{
    public abstract class BaseController
    {
        protected ServiceClient service;

        public BaseController()
        {
            service = new ServiceClient();
        }
    }
}