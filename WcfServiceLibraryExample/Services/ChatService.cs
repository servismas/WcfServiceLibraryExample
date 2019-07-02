using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibraryExample.Contracts;

namespace WcfServiceLibraryExample.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ChatService : IContract
    {
        List<ConnectedUser> listUsers;
        int nextId;
        public ChatService()
        {
            listUsers = new List<ConnectedUser>();
            nextId = 1;
        }

        public int Connect(string name)
        {
            ConnectedUser user = new ConnectedUser()
            {
                Id = nextId++,
                Name = name,
                operationContext = OperationContext.Current
            };
            listUsers.Add(user);
            SendMess(user.Name + " connected", 0);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            var user = listUsers.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                listUsers.Remove(user);
                SendMess(user.Name + " disconected", 0);
            }
        }

        public void SendMess(string mes, int id)
        {
            string answer = DateTime.Now.ToShortTimeString() + " ";
            var user = listUsers.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                answer += " : " + user.Name + " ";
            }
            answer += mes;
            Task.Run(() =>
            {
                foreach (var u in listUsers)
                {
                    var cb = u.operationContext.GetCallbackChannel<IDuplexContract>();
                    cb.ClientMethod(answer);
                }
            });
        }

        public int ServiceMethodAdd(int a, int b)
        {
            var chanel = OperationContext.Current.GetCallbackChannel<IDuplexContract>();
            chanel.ClientMethod("IDuplex" + a + "+" + b);
            return a + b;
        }
    }
    public class ConnectedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; }
    }
}
