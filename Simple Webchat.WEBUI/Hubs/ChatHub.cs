using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Webchat.WEBUI.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(SerializedHubMessage message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
