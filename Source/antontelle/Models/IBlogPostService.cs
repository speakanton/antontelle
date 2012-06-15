using System.Collections.Generic;

namespace antontelle.Models
{
	public interface IBlogPostService
	{
		IEnumerable<BlogPost> BlogPosts();
	}
}