using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TrueMarbleData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host;
                NetTcpBinding tcpBinding = new NetTcpBinding();

                tcpBinding.MaxReceivedMessageSize = System.Int32.MaxValue;
                tcpBinding.ReaderQuotas.MaxArrayLength = System.Int32.MaxValue;

                host = new ServiceHost(typeof(TMDataControllerImpl));
                host.AddServiceEndpoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:50001/TMData");

                //host.AddServiceEndPoint(typeof(ITMDataController), tcpBinding, "net.tcp://localhost:50001/TMData");

                host.Open();
                System.Console.WriteLine("Press Enter to Exit");
                System.Console.ReadLine();
                host.Close();


            }

            catch (FaultException e)
            {
                Console.WriteLine("Error Occured", e);
            }


        }
    }
}
