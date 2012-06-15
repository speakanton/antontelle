using System;
using System.Collections.Generic;

namespace antontelle.Models
{
	public class BlogPostService : IBlogPostService
	{
		public IEnumerable<BlogPost> BlogPosts()
		{
			return new List<BlogPost> { new BlogPost { Id = 0, Title = "post1", Content = "content1" }, new BlogPost { Id = 1, Title = "post2", Content = "content2" } };
		}
	}
}