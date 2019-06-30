using ClientConsole.ServiceReferenceToChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class CallbackHandler : IContractCallback
    {
        public void ClientMethod(string msg)
        {
            Console.WriteLine("Server answer: " + msg); ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ContractClient client = new ContractClient(new InstanceContext(new CallbackHandler()));
            //Console.WriteLine("Connected");
            //Console.WriteLine(client.ServiceMethodAdd(22, 33));
            client.Connect("Grisha");
            client.Connect("Kolya");
            client.Connect("Olya");
            client.SendMess("Hello", 1);
            //client.Disconnect(2);
            client.SendMess("Hello", 2);
            client.SendMess("Hello", 3);
            //client.Disconnect(1);
            client.SendMess("Hello", 1);
            //client.Disconnect(3);

            Console.ReadLine();
        }
    }
}
