using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace antontelle.Models
{
	[Bind(Exclude = "Id")]
	public partial class BlogPost
	{
		public int Id { get; set; }
		
		public string Title { get; set; }

		public string Content { get; set; }
		
		public DateTime PublishedOnDate { get; set; }
		
		public Category Category { get; set; }
	}

	public enum Category
	{
		General,
		Friedrich,
		Futsal,
		Beachvolleyball
	}

	[MetadataType(typeof(BlogPostMetadata))]
	public partial class BlogPost
	{
		// not used, except for metadata
		class BlogPostMetadata
		{
			[HiddenInput(DisplayValue = false)]
			public int Id { get; set; }

			public string Title { get; set; }

			[DataType(DataType.MultilineText)]
			[DisplayName("Text of Blogpost")]
			public string Content { get; set; }

			public DateTime PublishedOnDate { get; set; }

			public Category Category { get; set; }
		}
	}
}