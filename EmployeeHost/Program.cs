using System;
using System.ServiceModel;

namespace EmployeeHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost svcHost = new ServiceHost(typeof(_22_WCF_Assignment_02.Service1)))
            {
                svcHost.Open();
                Console.WriteLine("Service up and running at:");
                foreach (var ea in svcHost.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                }

                Console.ReadLine();
                svcHost.Close();
            };
        }
    }
}
