using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antontelle.Models
{
	public class BlogPostsValidationProvider : AssociatedValidatorProvider
	{
		protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
		{
			var excludeWordsAttributes = attributes.OfType<ExcludeWordsAttribute>();
			foreach (var excludeWordsAttribute in excludeWordsAttributes)
			{
				yield return new ExcludeWordsValidator(metadata, context, excludeWordsAttribute.Words);
			}
		}

		private class ExcludeWordsValidator : ModelValidator
		{
			private readonly string[] excludeWords;
			private const string ErrorMessage = "Don't use the word '{0}'.";

			public ExcludeWordsValidator(ModelMetadata metadata, ControllerContext controllerContext, string[] wordsToExclude) : base(metadata, controllerContext)
			{
				excludeWords = wordsToExclude;
			}

			public override IEnumerable<ModelValidationResult> Validate(object container)
			{
				if (Metadata.Model == null)
					yield break;

				var model = Metadata.Model.ToString();
				foreach (var word in excludeWords.Where(model.Contains))
				{
					yield return new ModelValidationResult
					             	{
					             		Message = string.Format(ErrorMessage, word)
					             	};
				}
			}

			public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
			{
				var rule = new ModelClientValidationRule
				           	{
				           		ErrorMessage = ErrorMessage,
								ValidationType = "excludedwords"
				           	};
				rule.ValidationParameters["words"] = excludeWords;
				yield return rule;
			}
		}
	}
}