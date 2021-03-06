﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
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
			var initialBlogPost = new BlogPost {PublishedOnDate = DateTime.Now.Date};
			return View(initialBlogPost);
		}

		[HttpPost]
		[ActionName("Create")]
		public ActionResult Create_Post()
		{
			var blogPost = new BlogPost();
			// analogous to receiving the blogPost as a paramater
			if (!TryUpdateModel(blogPost))
			{
				//...
			}

			if (ModelState.IsValid)
			{
				BlogPostService.Add(blogPost);
				return RedirectToAction("Index");
			}
			else // data is invalid
			{
				return View(blogPost);
			}
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

		public ViewResult Details(int id)
		{
			var blogPost = BlogPostService.BlogPosts().First(b => b.Id == id);

			// can lead to another request
			EnforceCanonicalUrlWithPossibleRedirect(blogPost.DetailsRouteValues());
			return View(blogPost);
		}

		private void EnforceCanonicalUrlWithPossibleRedirect(RouteValueDictionary routeValues)
		{
			string canonicalPathAndQuery = Url.RouteUrl(routeValues);
			if(Request.Url.PathAndQuery != canonicalPathAndQuery)
				Response.RedirectPermanent(canonicalPathAndQuery);
		}
    }
}
