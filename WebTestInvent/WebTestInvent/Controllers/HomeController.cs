using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace WebTestInvent.Controllers
{
    public class HomeController : Controller
    {

        List<Client> clientList;
        List<Good> goodsList;
        List<Order> ordersList;
        List<Order_string> orderStringList;
        MyModelDB context;

        public ActionResult Index()
        {
            SetData();
            var query = (from cl in context.Clients
                         join ord in context.Orders on cl.ID equals ord.ID
                         join ordstr in context.Order_strings on ord.ID equals ordstr.ID
                         select new
                         {
                             Id = cl.ID,
                             Name = cl.Name,
                             Adress = cl.Adress,
                             Sum = ordstr.Sum,
                         }).ToList();

            return View(query);
        }


        public ActionResult ClientsInfoAll()
        {
            SetData();
            return View(orderStringList);
        }

        public ActionResult ClientsInfo(int id)
        {
            List<Order_string> listOS = new List<Order_string>();
            SetData();
            foreach(Order_string os in orderStringList)
            {
                if(id == os.Order.Client.ID)
                {
                    listOS.Add(os);
                }
            }
            return View(listOS);
        }

        private void SetData()
        {

            int initPrise = 5;
            int initCount = 2;
            int[] prises;
            int[] count;

            context = new MyModelDB();

            context.Clients.RemoveRange(context.Clients);
            context.Goods.RemoveRange(context.Goods);
            context.Orders.RemoveRange(context.Orders);
            context.Order_strings.RemoveRange(context.Order_strings);

            context.SaveChanges();

            clientList = context.Clients.ToList();
            goodsList = context.Goods.ToList();
            ordersList = context.Orders.ToList();
            orderStringList = context.Order_strings.ToList();

            #region Init clients data table
            clientList.Add(new Client
            {
                ID = 1,
                Name = "Vlad",
                Adress = "Dnepropetrovsk"
            }
            );

            clientList.Add(new Client
            {
                ID = 2,
                Name = "Alina",
                Adress = "Dnepropetrovsk"
            }
            );

            clientList.Add(new Client
            {
                ID = 3,
                Name = "Bogdan",
                Adress = "Dnepropetrovsk"
            }
            );
            foreach (Client client in clientList)
            {
                context.Clients.Add(client);
            }
            #endregion

            #region Init goods data table
            goodsList.Add(new Good
            {
                ID = 1,
                Name = "Diamond"
            });
            goodsList.Add(new Good
            {
                ID = 2,
                Name = "Gold"
            });
            goodsList.Add(new Good
            {
                ID = 3,
                Name = "Oil"
            });
            foreach (Good good in goodsList)
            {
                context.Goods.Add(good);
            }
            #endregion

            #region Init orders data table
            ordersList.Add(new Order
            {
                ID = 1,
                Client = clientList[1],
                Date = DateTime.Now,
            });
            ordersList.Add(new Order
            {
                ID = 2,
                Client = clientList[0],
                Date = DateTime.Now,
            });
            ordersList.Add(new Order
            {
                ID = 3,
                Client = clientList[2],
                Date = DateTime.Now,
            });
            foreach (Order order in ordersList)
            {
                context.Orders.Add(order);
            }
            #endregion

            #region Init order strings data table
            prises = new int[ordersList.Count];
            count = new int[ordersList.Count];
            for (int i = 0; i < ordersList.Count; i++)
            {
                prises[i] = initPrise++;
                count[i] = initCount++;
            }
            orderStringList.Add(new Order_string
            {
                ID = 1,
                Order = ordersList[1],
                Good = goodsList[1],
                Prise = prises[0],
                Count = count[0],
                Sum = prises[0] * count[0]
            });
            orderStringList.Add(new Order_string
            {
                ID = 2,
                Order = ordersList[0],
                Good = goodsList[0],
                Prise = prises[1],
                Count = count[1],
                Sum = prises[1] * count[1]
            });
            orderStringList.Add(new Order_string
            {
                ID = 3,
                Order = ordersList[2],
                Good = goodsList[2],
                Prise = prises[2],
                Count = count[2],
                Sum = prises[2] * count[2]
            });

            foreach (Order_string orderString in orderStringList)
            {
                context.Order_strings.Add(orderString);
            }
            #endregion

            context.SaveChanges();

        }
    }
}