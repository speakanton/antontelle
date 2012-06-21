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

		[HttpGet]
		public ActionResult Create()
		{
			var blogPost = new BlogPost();
			blogPost.Title = "GenericTitle";
			return View(blogPost);
		}

		[HttpPost]
		public ActionResult Create(BlogPost blogPost)
		{
			BlogPostService.Add(blogPost);
			return RedirectToAction("Index");
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

		public ActionResult Search(string query, int page = 1)
		{
			var pageIndex = page - 1;
			const int pageSize = 5;
			if(query == "round")
				return RedirectToAction("Search",new {query = "post"});

			var results = new PagedList<BlogPost>(BlogPostService.Search(query), pageIndex, pageSize);

			return View(new SearchResultsViewModel
			            	{
			            		Query = query,
								Results = results
			            	});
		}

    }
}
