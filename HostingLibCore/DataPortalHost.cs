using Csla.Configuration;
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
                _netService.UnknownMessageReceived -= MessageReceived;
            }

            _url = "http://localhost:8001/";//ConfigurationManager.AppSettings["NetDataPortalUri"];

            _netService = new ServiceHost(typeof(Csla.Server.Hosts.RemotingPortal), new Uri(_url));

            _netService.UnknownMessageReceived += MessageReceived;

            
            // Enable metadata publishing.
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            _netService.Description.Behaviors.Add(smb);


            _netService.Open();

        }

        private void MessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            var msg = e.Message;
        }

        public void Stop()
        {
            if (_netService !=null)
            {
                _netService.Close();

                _netService.UnknownMessageReceived -= MessageReceived;

                _netService = null;
            }

        }

    }
}
