using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteCoreTestApplication.Controllers
{
    public class CustomerController : Controller
    {
        [Authorize(Roles = "CUSTOMER")]
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}