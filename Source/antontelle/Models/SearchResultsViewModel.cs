using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace antontelle.Models
{
	public class SearchResultsViewModel
	{
		public string Query { get; set; }
		public PagedList<BlogPost> Results { get; set; }
	}
}