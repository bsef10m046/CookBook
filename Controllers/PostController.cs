using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/
        public InterfaceDaily dly;
        public PostController(InterfaceDaily d)
        {
            dly = d;
        }
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                DateTime D = DateTime.Now;
                String s = D.ToString();
                String[] i = s.Split(' ');
                Daily d = dly.get(i[0]);
                return View(d);
            }
            else
                return View("../Home/Index");
            
        }

    }
}
