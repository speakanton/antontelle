using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public class Summerizer
	{
		private readonly List<BlogPost> BlogPosts;

		public Summerizer(List<BlogPost> blogPosts)
		{
			BlogPosts = blogPosts;
		}

		public int GetNumberOfPosts(Category category)
		{
			return BlogPosts.Where(post => post.Category == category).Count();
		}
	}
}