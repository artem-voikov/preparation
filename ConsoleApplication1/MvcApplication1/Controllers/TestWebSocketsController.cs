using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class TestWebSocketsController : Controller
    {
        //
        // GET: /TestWebSockets/

        public ActionResult Index()
        {
            return View();
        }

	    [HttpPost]
	    public void ActivateChat()
	    {
			HttpContext.AcceptWebSocketRequest(ChatHandler);
	    }

		private async Task ChatHandler(System.Web.WebSockets.AspNetWebSocketContext context)
		{
			while (true)
			{
				var income = new ArraySegment<byte>(new byte[1024]);
				var result = await context.WebSocket.ReceiveAsync(income, CancellationToken.None);
				
				if (context.WebSocket.State != WebSocketState.Open)
					break;

				var msg = Encoding.UTF8.GetString(income.Array, 0, result.Count);
				var outcome = new ArraySegment<byte>(Encoding.UTF8.GetBytes(msg));
				await context.WebSocket.SendAsync(outcome, WebSocketMessageType.Text, true, CancellationToken.None);
			}
		}
    }
}
