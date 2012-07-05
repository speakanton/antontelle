using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace antontelle.Models
{
	[AttributeUsage(AttributeTargets.Property)]
	public class ExcludeWordsAttribute : ValidationAttribute, IClientValidatable
	{
		public string[] Words { get; private set; }
		public new const string ErrorMessage = "Don't use the word '{0}'.";

		public ExcludeWordsAttribute(params string[] words)
		{
			Words = words;
		}

		public override string FormatErrorMessage(string name)
		{
			return "Don't use the word '{0}' in the " + name;
		}

		public override bool IsValid(object value)
		{
			try
			{
				return !Words.Where(value.ToString().Contains).Any();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var rule = new ModelClientValidationRule
			{
				ErrorMessage = ErrorMessage,
				ValidationType = "excludedwords"
			};
			rule.ValidationParameters["words"] = Words;
			yield return rule;
		}
	}
}