using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
namespace MvcApplication2.Controllers
{
    public class RecipeController : Controller
    {
        //
        // GET: /Recipe/
        public InterfaceRecipe reci;
        public RecipeController(InterfaceRecipe re)
        {
            reci = re;
        }
        public ActionResult recipes()
        {
            if (Session["Username"] != null)
                return View();
            else
                return View("../Home/Index");
        }
        public ActionResult post()
        {

            if (Session["Username"] != null)
                return View();
            else
                return View("../Home/Index");
        }
        public ActionResult Search()
        {
            if (Session["Username"] != null)
                return View();
            else
                return View("../Home/Index");
        }
        public JsonResult getcat()
        {
            RecClass r = new RecClass();
            List<String> l = reci.get();
            return this.Json(l, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void postRecipe(Recipe r)
        {
            String s = Request["categories"];
            r.Category = Convert.ToInt32(s);
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(Server.MapPath(@"~\Images\" + file.FileName));
            r.Image = "../Images/" + file.FileName;
            r.UserId = Convert.ToInt32(Session["ID"]);
            reci.post(r);
        }
        [HttpPost]
        public ViewResult save()
        {
            String s = Request["subject"];
            int id = Convert.ToInt32(s);
            Recipe rp = reci.view(id);
            return View(rp);
        }
        public JsonResult getrec()
        {
             
            String v = Request["id"];
            int e = Convert.ToInt32(v);
            List<Object> l = new List<object>();
            l=reci.recipeget(e);
            return this.Json(l, JsonRequestBehavior.AllowGet);
        }

        public JsonResult searchrec()
        {

            String v = Request["id"];
            List<Object> l = new List<object>();
            l = reci.recipesearch(v);
            return this.Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}