using System;
using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public class BlogPostService : IBlogPostService
	{
		private IList<BlogPost> _blogPosts;

		public IQueryable<BlogPost> BlogPosts()
		{
			_blogPosts = new List<BlogPost>();
			for (var i = 1; i <= 17; ++i)
				_blogPosts.Add(new BlogPost {Id = i, Title = "post" + i, Content = "content" + i});
			return _blogPosts.AsQueryable();
		}

		public IQueryable<BlogPost> Search(string query)
		{
			if (String.IsNullOrEmpty(query))
				return BlogPosts();
			return BlogPosts().Where(b => (b.Title.Contains(query) || b.Content.Contains(query)));
		}
	}
}