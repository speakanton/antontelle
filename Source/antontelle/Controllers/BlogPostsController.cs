using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antontelle.Controllers
{
    public class BlogPostsController : Controller
    {
        //
        // GET: /BlogPosts/

        public ActionResult Index()
        {
            return View();
        }

    }
}
