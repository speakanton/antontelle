﻿using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using antontelle.Models;

namespace antontelle.Controllers
{
	public class SearchViewModel
	{
		public IList<Section> Sections { get; set; }
	}

    public class SectionsController : Controller
    {
        //
        // GET: /Sections/
		public ActionResult Index()
		{
			var model = new[]
			            	{
			            		new Section
			            			{
			            				Criteria = new[]
			            				           	{
			            				           		new Criterion {Text = "some integer", Value = 2},
			            				           		new Criterion {Text = "some boolean", Value = true},
			            				           		new Criterion {Text = "some string", Value = "foo"},
			            				           	}
			            			},
			            		new Section
			            			{
			            				Criteria = new[]
			            				           	{
			            				           		new Criterion {Text = "some other integer", Value = 4},
			            				           		new Criterion {Text = "some other boolean", Value = true},
			            				           		new Criterion {Text = "some other string", Value = "foobar"},
			            				           	}
			            			}
			            	};
			dynamic wrapper = new ExpandoObject();
			wrapper.mdl = new SearchViewModel {Sections = model};
			return View(wrapper);
		}
    }
}
