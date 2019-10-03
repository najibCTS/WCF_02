using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;

namespace WeatherWindowService
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost m_Host;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (m_Host != null)
            {
                m_Host.Close();
            }
            Uri httpUrl = new Uri("http://localhost:8733/WeatherService");
            m_Host = new ServiceHost(typeof(WeatherService.Service1), httpUrl);
            m_Host.AddServiceEndpoint(typeof(WeatherService.IService1), new BasicHttpBinding(), "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };
            m_Host.Description.Behaviors.Add(smb);
            m_Host.Open();
        }

        protected override void OnStop()
        {
            if (m_Host != null)
            {
                m_Host.Close();
                m_Host = null;
            }
        }
    }
}
