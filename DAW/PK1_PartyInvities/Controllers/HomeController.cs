
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PK1_PartyInvities.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Buenos Dias!!" : "Buenas Tardes!!";
            return View();
        }
        public ViewResult GetTimeImage()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.hora = hour;
            return View();
        }
       
    }
}
