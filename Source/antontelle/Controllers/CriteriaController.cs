using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using antontelle.Models;

namespace antontelle.Controllers
{
    public class CriteriaController : Controller
    {
        //
        // GET: /Criteria/

		public ActionResult Index()
		{
			var model = new[]
			            	{
			            		new Criterion {Text = "some integer", Value = 2},
			            		new Criterion {Text = "some boolean", Value = true},
			            		new Criterion {Text = "some string", Value = "foo"},
			            	};
			return View(new { mdl = model });
		}

    }
}
