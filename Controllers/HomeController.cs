using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public InterfaceUser repo;
        public InterfaceAd ad;
        public HomeController(InterfaceUser u)
        {
            repo = u;
        }
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult LoginAd()
        {
            return View();

        }
        public ActionResult main2()
        {
            if (Session["Username"] != null)
                return View();
            else
                return View("Index");
        }
        public ActionResult login()
        {
            return View();
        }
        public ActionResult account()
        {
            if (Session["Username"] != null)
                return View();
            else
                return View("Index");
        }
        public JsonResult CheckUserName()
        {
            bool flag=false;
            string userName = Request["UserName"];
            Database1Entities4 db = new Database1Entities4();
            var q = from u in db.Users select u.Name;
            foreach (String s in q)
            {
                if (s.Equals(userName))
                {
                    flag = true;
                }
            }
            
            //check from database

            // List<Student> list = new List<Student>();


            return this.Json(flag, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult SIGNUP(User s)
        {
            if (ModelState.IsValid)
            {
                String pas = Request["passwordsignup_confirm"];
                if (pas.Equals(s.Password))
                {

                    repo.save(s);
                    return View("login");
                }
                else
                {
                    ViewBag.y = "Both Password do not match";
                    return View("login");
                }
            }
            else
                return View("login");
        }
        [HttpPost]
        public ActionResult login1(User u1)
        {
            if (ModelState.IsValid)
            {
                //String name = Request["username"];
                //String pass = Request["password"];
                Userc c = new Userc();
                Session["UserName"] = u1.Name;
                
                bool f = repo.verify(u1.Name, u1.Password);
                
                if (f)
                {
                    Session["UserName"] = u1.Name;
                    int id=repo.getid(u1.Name);
                    Session["ID"] = "user";
                    Session["id"] = repo.getid(u1.Name);
                    return View("main2");
                }
                else
                {
                    ViewBag.x = "Password do not match";
                    return View("login");

                }
           }
            else
                return View("login");
        }
        [HttpPost]
        public ActionResult login2(Admin ad)
        {
            Adm d = new Adm();
            ViewBag.x = "";
            bool f = d.verify(ad.Name,ad.Password);
            if (f)
            {
                Session["UserName"] = ad.Name;
                Session["ID"] = "user";
                 
                return View("../Admin/Index");
            }
            else
            {
                ViewBag.x = "Password do not match";
                return View("LoginAd");

            }
        }
        public JsonResult myrec()
        {

            
            int s = Convert.ToInt32(Session["id"]);
            List<Object> l = new List<object>();
            l = repo.recipesearch(s);
            return this.Json(l, JsonRequestBehavior.AllowGet);
        }
        public ActionResult logout()
        {
            Session.RemoveAll();
            return View("Index");
        }
    }
}
