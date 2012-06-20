using System.Collections.Generic;
using System.Linq;

namespace antontelle.Models
{
	public interface IBlogPostService
	{
		IQueryable<BlogPost> BlogPosts();
		IQueryable<BlogPost> Search(string query);
	}
}