using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardGroupsDisplay : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["LoggedInUser"] != null)
			{
				LoadFlashcardGroups();
			}
			else
			{
				LoadPublicFlashcardGroups();
			}
		}





		protected void LoadFlashcardGroups()
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<string> languagesCombination = flashcardServices.GetPublicLanguagesCombinationsFromOthers(user);
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();
			string formatedLanguagesCombination;

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

				List<string> categories = LoadCategoriesByLanguages(user, sourceLanguage, targetLanguage);

				var languagesAndItsCategories = new DivByLanguagesAndCategories(formatedLanguagesCombination, categories);

				divByLanguagesAndCategories.Add(languagesAndItsCategories);
			}

			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();

		}

		protected List<string> LoadCategoriesByLanguages(User user, string sourceLanguage, string targetLanguage)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			return flashcardServices.GetCategoryGroupsByLanguages(user, sourceLanguage, targetLanguage);
		}








		protected void LoadPublicFlashcardGroups()
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			List<string> languagesCombination = flashcardServices.GetAllLanguagesCombinations();
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();
			string formatedLanguagesCombination;

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

				List<string> categories = LoadPublicCategoriesByLanguages(sourceLanguage, targetLanguage);

				var languagesAndItsCategories = new DivByLanguagesAndCategories(formatedLanguagesCombination, categories);

				divByLanguagesAndCategories.Add(languagesAndItsCategories);
			}

			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();

		}

		protected List<string> LoadPublicCategoriesByLanguages(string sourceLanguage, string targetLanguage)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			return flashcardServices.GetAllCategoryGroups(sourceLanguage, targetLanguage);
		}



	}
}