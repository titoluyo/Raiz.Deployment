using System.ServiceModel;
using System.ServiceProcess;
using Raiz.Deployment.Svc.Lib;


namespace Raiz.Deployment.Svc.Cliente
{
    partial class WinServiceCliente : ServiceBase
    {
        public ServiceHost serviceHost = null;
        public ServiceHost mnuServiceHost = null;
        
        public WinServiceCliente()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            serviceHost = new ServiceHost(typeof(DeployService));
            serviceHost.Open();

            if (mnuServiceHost != null)
            {
                mnuServiceHost.Close();
            }

            mnuServiceHost = new ServiceHost(typeof(MenuService));
            mnuServiceHost.Open();

        }

        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            if (mnuServiceHost != null)
            {
                mnuServiceHost.Close();
            }

        }
    }
}
