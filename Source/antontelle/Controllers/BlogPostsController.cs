using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using antontelle.Models;

namespace antontelle.Controllers
{
    public class BlogPostsController : Controller
    {
    	private readonly IBlogPostService BlogPostService;

    	public BlogPostsController(IBlogPostService blogPostService)
    	{
    		BlogPostService = blogPostService;
    	}

    	//
        // GET: /BlogPosts/

        public ActionResult Index()
        {
        	var model = BlogPostService.BlogPosts();
            return View(model);
        }

		public ActionResult Edit(int id)
		{
			var blogPost = BlogPostService.BlogPosts().First(b => b.Id == id);
			return View(blogPost);
		}

		[HttpPost]
		public ActionResult Edit(int id, FormCollection collection)
		{
			var blogPost = BlogPostService.BlogPosts().First(b => b.Id == id);
			if (TryUpdateModel(blogPost))
				return RedirectToAction("Index");
			return View(blogPost);
		}

    }
}
