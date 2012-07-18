using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
			       		{ "title", MakeSimpleUrlSegments(blogPost.Title) },
			       		{ "category", blogPost.Category },
			       	};
		}

		private static string MakeSimpleUrlSegments(string value)
		{
			value = (value ?? string.Empty).Trim();
			value = value.Replace(" ", "-");
			return Regex.Replace(value, "[^0-9a-z\\-]", string.Empty, RegexOptions.IgnoreCase);
		}
	}
}