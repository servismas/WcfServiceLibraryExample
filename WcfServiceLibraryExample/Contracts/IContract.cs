using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryExample.Contracts
{
    [ServiceContract(CallbackContract = typeof(IDuplexContract))]
    public interface IContract
    {
        [OperationContract]
        int ServiceMethodAdd(int a, int b);

        [OperationContract(IsOneWay = true)]
        void SendMess(string s, int id);

        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);
    }
}
