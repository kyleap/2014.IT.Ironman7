using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using CMS.BLL.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace CMS.Web
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        private static ConcurrentDictionary<string, List<int>> _mapping = new ConcurrentDictionary<string, List<int>>();

        public override Task OnConnected()
        {
            _mapping.TryAdd(Context.ConnectionId, new List<int>());
            Clients.All.newConnection(Context.ConnectionId);
            return base.OnConnected();
        }

        public void send(string Name,string Message)
        {
            Clients.All.addMessageToPage(Name, Message,DateTime.Now.ToString("mm:dd:ss"));
        }

        public void cust()
        {
            CustomerService service = new CustomerService();
            var data = service.Get().Take(5);
            //var json = JsonConvert.SerializeObject(data);
            Clients.All.custData(data);
        }
    }
}