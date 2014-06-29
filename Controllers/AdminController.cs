using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public InterfaceAd ad;
        public AdminController(InterfaceAd u)
        {
            ad = u;
        }
        public ActionResult Index()
        {
            if (Session["Username"] != null && Session["ID"].ToString()!= "user")
                return View();
            else
                return View("../Home/Index");
        }
        public ActionResult daily()
        {
            //if (Session["Username"] != null && Session["ID"] != "user")
                return View();
            //else
                //return View("../Home/Index");
        }
        public ActionResult Add()
        {
            if (Session["Username"] != null)
                return View();
            else
                return View("../Home/Index");
        }
        public ActionResult post()
        {
            String n = Request["cat"];
            ad.add(n);
            return View("Add");
        }
    }
}
