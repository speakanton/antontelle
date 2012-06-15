using System;
using System.Collections.Generic;

namespace antontelle.Models
{
	public class BlogPostService : IBlogPostService
	{
		public IEnumerable<BlogPost> BlogPosts()
		{
			return new List<BlogPost>
			       	{new BlogPost {Title = "post1", Content = "conten1"}, new BlogPost {Title = "post2", Content = "content2"}};
		}
	}
}