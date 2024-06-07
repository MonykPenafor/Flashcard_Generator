using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashcard_Generator
{
	public class DivByLanguagesAndCategories
	{

		public string Languages { get; set; }
		public List<string> Categories { get; set; }

		public DivByLanguagesAndCategories(string languages, List<string> categories)
		{
			Languages = languages;
			Categories = categories;
		}

	}
}