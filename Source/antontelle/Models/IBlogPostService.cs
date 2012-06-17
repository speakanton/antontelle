using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public interface IBlogPostService
	{
		IEnumerable<BlogPost> BlogPosts();
		IEnumerable<BlogPost> Search(string query);
	}
}