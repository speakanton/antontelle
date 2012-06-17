using System;
using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public class BlogPostService : IBlogPostService
	{
		private IEnumerable<BlogPost> _blogPosts= new List<BlogPost>
					       	{
					       		new BlogPost {Id = 0, Title = "post1", Content = "content1"},
					       		new BlogPost {Id = 1, Title = "post2", Content = "content2"}
					       	};
		public IEnumerable<BlogPost> BlogPosts()
		{
				return _blogPosts;
		}

		public IEnumerable<BlogPost> Search(string query)
		{
			if (String.IsNullOrEmpty(query))
				return _blogPosts;
			return _blogPosts.Where(b => (b.Title.Contains(query) || b.Content.Contains(query)));
		}
	}
}