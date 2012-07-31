using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using antontelle.Models;
using antontelle.Controllers;
using NUnit.Framework;

namespace Tests.BlogPostTests
{
	[TestFixture]
	public class TestClass
	{
		[Test]
		public void Test1()
		{
			var blogPosts = new List<BlogPost> {new BlogPost() {Category = Category.Futsal}};

			var summerizer = new Summerizer(blogPosts);
			var result = summerizer.GetNumberOfPosts(Category.Futsal);

			Assert.AreEqual(result, 1);
		}

		[Test]
		public void TestController()
		{
			var controller = new BlogPostsController(new BlogPostService());
			var result = controller.Index() as ViewResult;
			var model = result.Model as IEnumerable<BlogPost>;

			Assert.AreEqual(17, model.Count());
		}
	}
}
