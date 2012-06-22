using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace antontelle.Models
{
	public class BlogPost
	{
		public int Id;
		
		public string Title { get; set; }

		[DataType(DataType.MultilineText)]
		[DisplayName("Text of Blogpost")]
		public string Content { get; set; }
		
		public DateTime PublishedOn { get; set; }
		
		public Category Category { get; set; }
	}

	public enum Category
	{
		General,
		Friedrich,
		Futsal,
		Beachvolleyball
	}
}