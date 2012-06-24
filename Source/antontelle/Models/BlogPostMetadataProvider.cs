using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antontelle.Models
{
	public class BlogPostMetadataProvider : DataAnnotationsModelMetadataProvider
	{
		protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
		{
			var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

			if(modelType == typeof(DateTime)
				&& propertyName != null
				&& propertyName.EndsWith("Date"))
			{
				metadata.EditFormatString = "{0:d/M/yyyy}";
			}

			return metadata;
		}
	}
}