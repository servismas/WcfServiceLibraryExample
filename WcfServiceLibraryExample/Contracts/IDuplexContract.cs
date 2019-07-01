using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibraryExample.Contracts
{
    public interface IDuplexContract
    {
        [OperationContract(IsOneWay = true)]
        void ClientMethod(string msg);
    }
}
