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

		protected void btnFlashcardsDisplay_Click(object sender, EventArgs e)
		{
			Response.Redirect("FlashcardsDisplay.aspx");
		}

		protected void LoadFlashcardGroups()
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsForLoggedUser(user, true);
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();
			string formatedLanguagesCombination;

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

				List<string> categories = flashcardServices.GetCategoryGroupsForLoggedUser(user, sourceLanguage, targetLanguage, true);

				var languagesAndItsCategories = new DivByLanguagesAndCategories(formatedLanguagesCombination, categories);

				divByLanguagesAndCategories.Add(languagesAndItsCategories);
			}
			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();
		}
	}
}