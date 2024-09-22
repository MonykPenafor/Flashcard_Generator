using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcard_Generator
{
	public class DivByLanguagesAndCategories
	{

		public string SourceLanguage { get; set; }

		public string TargetLanguage { get; set; }	
		public List<string> Categories { get; set; }

		public DivByLanguagesAndCategories(string sourceLanguages, string targetLanguage, List<string> categories)
		{
			SourceLanguage = sourceLanguages;
			TargetLanguage = targetLanguage;
			Categories = categories;
		}

	}
}