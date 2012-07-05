//Sys.Mvc.ValidatorRegistry.validators["excludedwords"] = function (rule) {
//	var words = rule.ValidationParameters.words;
//	var message = rule.ErrorMessage;

//	return function (value) {
//		for (var i = 0; i < words.length; i++) {
//			if (value.indexOf(words[i]) >= 0)
//				return message.replace("{0}", words[i]);
//		}
//		return true;
//	}
//}

jQuery.validator.unobtrusive.adapters.add("excludedwords", function (rule) {
	var message = rule.ErrorMessage;
	var words = rule.ValidationParameters.words;

	return function (value) {
		for (var i = 0; i < words.length; i++) {
			if (value.indexOf(words[i]) >= 0)
				return message.replace("{0}", words[i]);
		}
		return true;
	}
});