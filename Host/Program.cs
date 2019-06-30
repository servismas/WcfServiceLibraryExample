using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibraryExample.Services;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();
                Console.WriteLine("Host started");
                Console.ReadLine();
            }

        }
    }
}
