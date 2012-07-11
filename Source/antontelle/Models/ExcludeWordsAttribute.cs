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
		public string Word { get; private set; }
		public new string ErrorMessage;

		public ExcludeWordsAttribute(string words)
		{
			ErrorMessage = "Don't use the word " + Word;
			Word = words;
		}

		public override string FormatErrorMessage(string name)
		{
			return ErrorMessage + " in the " + name;
		}

		public override bool IsValid(object value)
		{
			try
			{
				return String.Equals(value.ToString(), Word);
				//return !Words.Where(value.ToString().Contains).Any();
			}
			catch (Exception)
			{
				return false;
			}
		}

		public class ModelClientValidationExcludeWordsRule : ModelClientValidationRule
		{
			public ModelClientValidationExcludeWordsRule(string errorMessage, string word)
				: base()
			{
				this.ErrorMessage = errorMessage;
				this.ValidationType = "excludedword";
				this.ValidationParameters.Add("word", word);
			}
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			yield return new ModelClientValidationExcludeWordsRule(ErrorMessage, Word);
		}
	}
}