using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace antontelle.Models
{
	public static class RoutingUtils
	{
		public static RouteValueDictionary DetailsRouteValues(this BlogPost blogPost)
		{
			return new RouteValueDictionary
			       	{
			       		{ "controller", "BlogPosts"},
			       		{ "action", "Details" },
			       		{ "id", blogPost.Id },
			       		{ "title", blogPost.Title },
			       		{ "category", blogPost.Category },
			       	};
		}
	}
}