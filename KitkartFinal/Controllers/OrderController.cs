using KitkartFinal.Models;
using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace KitkartFinal.Controllers
{
   
        [Route("OrderNow")]
        public class OrderController : Controller
        {
        const string ServiceBusConnectionString =
            "Endpoint=sb://ewfswefs.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ohZkqZnBuDMAM6CibTIMu0fSOjAPYWl0OX1nGMCBYag=";
            const string QueueName = "queue";
            static IQueueClient queueClient;

        DbContextfile context = new DbContextfile();
            [HttpGet]
            public IActionResult Index(int id)
            {
                Product products = context.Product.FirstOrDefault(d => d.ID == id);
                return View(products);
            }
            [Route("/buy")]
            [HttpPost]
            public async Task<IActionResult> buy(int id)
            {
                Product products = context.Product.FirstOrDefault(d => d.ID == id);
                if (products != null)
                {
                    string loggedInUserName = HttpContext.User.Identity.Name;
                    Order r = new Order();
                    r.PId = products;
                    r.CustomerName = "Divyesh Vashisht";
                    r.OrderDate = DateTime.Now;

                    context.Order.Add(r);
                    context.SaveChanges();
                    products.AvailableQty -= 1;
                    context.Product.Update(products);

                    int numberOfMessages = products.AvailableQty;
                    int prod = products.ID;
                    queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

                    // Create a new message to send to the queue.
                    string messageBody = $"Product.id:Current Stock {prod}:{numberOfMessages}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));


                    // Send the message to the queue.
                    await queueClient.SendAsync(message);


                    context.SaveChanges();




                }
                return RedirectToAction("Index");
            }

        
    }
}
