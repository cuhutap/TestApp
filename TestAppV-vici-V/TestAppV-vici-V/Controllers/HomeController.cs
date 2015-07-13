using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAppV_vici_V.Models;

namespace TestAppV_vici_V.Controllers
{
    public class HomeController : Controller
    {
        
        
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserMessMod mess)
        {
            var CurUsers = MvcApplication.users.SingleOrDefault( u=> u.Nick == mess.Nick);

            if (CurUsers == null)
            {
                CurUsers = new UserMod() { ID = MvcApplication.users.Count, Nick = mess.Nick };
                MvcApplication.users.Add(CurUsers);
            }

            var ThisUserMessages = MvcApplication.messages.Where(m => m.User == CurUsers).OrderBy(m => m.Time).ToList();

            if (ThisUserMessages.Count == 10)
                MvcApplication.messages.Remove(MvcApplication.messages.First(m => m.User == CurUsers));

            if (MvcApplication.messages.Count == 20 && ThisUserMessages.Count > 2)
                MvcApplication.messages.Remove(MvcApplication.messages.First(m => m.User == CurUsers));

            if (MvcApplication.messages.Count == 20 && ThisUserMessages.Count <= 2)
                MvcApplication.messages.Remove(MvcApplication.messages[0]);

            MvcApplication.messages.Add(new MessgeMod() { User = CurUsers, Time = DateTime.Now, Mess = mess.Message });

            if (MvcApplication.messages.Count != 0)
                ViewBag.Messages = MvcApplication.messages.OrderBy(m=>m.Time).ToList(); 

            return View();
        }

        [HttpGet]
        public ActionResult Messagers()
        {
            ViewBag.Messages = MvcApplication.messages; 
            return PartialView();
        }


        [HttpPost]
        public ActionResult Messagers(string messParam, string Nick)
        {
            switch (messParam)
            {
                case "MyMess": ViewBag.Messages = MvcApplication.messages.Where( n=> string.Equals(n.User.Nick, Nick)).ToList();
                    break;
                case "ID": ViewBag.Messages = MvcApplication.messages.OrderBy(m => m.User.ID).ToList();
                    break;
                case "Date": ViewBag.Messages = MvcApplication.messages.OrderBy(m => m.Time).ToList();
                    break;
            }
            
            return PartialView();
        }
    }
}

