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
            return View(BlogPostService.BlogPosts());
        }

    }
}
