using System;
using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public class BlogPostService : IBlogPostService
	{
		private static readonly IList<BlogPost> _blogPosts = new List<BlogPost>();

		static BlogPostService()
		{
			var rand = new Random();
			for (var i = 1; i <= 17; ++i)
				_blogPosts.Add(new BlogPost { Id = i, Title = "post" + i, Content = "content" + i, PublishedOnDate = DateTime.Now, Category = (Category) rand.Next(0,4)});
		}

		public IQueryable<BlogPost> BlogPosts()
		{
			return _blogPosts.AsQueryable();
		}

		public IQueryable<BlogPost> Search(string query)
		{
			if (String.IsNullOrEmpty(query))
				return BlogPosts();
			return BlogPosts().Where(b => (b.Title.Contains(query) || b.Content.Contains(query)));
		}

		public void Add(BlogPost blogPost)
		{
			blogPost.Id = _blogPosts.Last().Id + 1;
			_blogPosts.Add(blogPost);
		}
	}
}