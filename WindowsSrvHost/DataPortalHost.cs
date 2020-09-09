using Csla.Configuration;
using Csla.Server.Hosts;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WindowsSrvHost
{
    public class DataPortalHost
    {

        private ServiceHost _netService;

        private string _url = "";

        public string GetUrl() => _url;

        public void Start()
        {
            if (_netService !=null)
            {
                _netService.Close();
            }

            _url = ConfigurationManager.AppSettings["NetDataPortalUri"];

            _netService = new ServiceHost(typeof(Csla.Server.Hosts.WcfPortal), new Uri(_url));

            ServiceEndpoint ep = _netService.AddServiceEndpoint(typeof(IWcfPortal), new WebHttpBinding(), "");


            _netService.Open();

        }

        public void Stop()
        {
            if (_netService !=null)
            {
                _netService.Close();
                _netService = null;
            }

        }

    }
}
