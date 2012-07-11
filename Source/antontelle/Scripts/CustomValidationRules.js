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

//jQuery.validator.unobtrusive.adapters.add("excludedwords", function (rule) {
//	var message = rule.ErrorMessage;
//	var words = rule.ValidationParameters.words;

//	return function (value) {
//		for (var i = 0; i < words.length; i++) {
//			if (value.indexOf(words[i]) >= 0)
//				return message.replace("{0}", words[i]);
//		}
//		return true;
//	}
//});

jQuery.validator.addMethod('excludedword', function (value, element, params) {
	var word = params['word'];
	if (value.indexOf(word) >= 0)
		return false;
	return true;
});
var setValidationValues = function (options, ruleName, value) {
	options.rules[ruleName] = value;
	if (options.message) {
		options.messages[ruleName] = options.message;
	}
};
var $Unob = $.validator.unobtrusive;
$Unob.adapters.add("excludedword", ["word"], function (options) {
	var value = {
		word: options.params.word
	};
	setValidationValues(options, "excludedword", value);
});

