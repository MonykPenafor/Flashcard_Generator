using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardGroupsDisplayByUser : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadFlashcardGroups();
		}

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

		protected void LoadFlashcardGroups()
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsByUser(user);
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();
			string formatedLanguagesCombination;

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				//formatedLanguagesCombination.Add(sourceLanguage + " / " + targetLanguage + ":");

				formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

				List<string> categories = LoadCategoriesByLanguages(user,sourceLanguage, targetLanguage);

				var languagesAndItsCategories = new DivByLanguagesAndCategories(formatedLanguagesCombination, categories);

				divByLanguagesAndCategories.Add(languagesAndItsCategories);
			}

			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();

		}

		protected List<string> LoadCategoriesByLanguages(User user, string sourceLanguage, string targetLanguage)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			return flashcardServices.GetCategoryGroupsByLanguagesAndUser(user, sourceLanguage, targetLanguage);
		}
	}
}