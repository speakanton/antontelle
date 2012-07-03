using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace antontelle.Models
{
	public class ExcludeWordsAttribute : Attribute
	{
		public string[] Words { get; private set; }

		public ExcludeWordsAttribute(params string[] words)
		{
			Words = words;
		}
	}
}