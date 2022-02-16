using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdoptToShop.Controllers
{
    public class AdopterController : Controller
    {
        // GET: Adopter
        public ActionResult Index()
        {
            return View();
        }
    }
}