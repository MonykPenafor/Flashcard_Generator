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
				LoadFlashcardGroups(true);
			}
			else
			{
				LoadFlashcardGroups(false);
			}
		}

		protected void LoadFlashcardGroups(bool isLogged)
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();
			//string formatedLanguagesCombination;

			if (isLogged)
			{
				List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsForLoggedUser(user, false);

				for (int i = 0; i < languagesCombination.Count; i = i+2)
				{
					string sourceLanguage = languagesCombination[i];
					string targetLanguage = languagesCombination[i+1];

					//formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

					List<string> categories = flashcardServices.GetCategoryGroupsForLoggedUser(user, sourceLanguage, targetLanguage, false);

					var languagesAndItsCategories = new DivByLanguagesAndCategories(sourceLanguage, targetLanguage, categories);

					divByLanguagesAndCategories.Add(languagesAndItsCategories);
				}
			}
			else
			{
				List<string> languagesCombination = flashcardServices.GetPublicLanguagesCombinations();

				for (int i = 0; i < languagesCombination.Count; i = i+2)
				{
					string sourceLanguage = languagesCombination[i];
					string targetLanguage = languagesCombination[i+1];

					//formatedLanguagesCombination = sourceLanguage + " / " + targetLanguage + ":";

					List<string> categories = flashcardServices.GetPublicCategoryGroups(sourceLanguage, targetLanguage);

					var languagesAndItsCategories = new DivByLanguagesAndCategories(sourceLanguage, targetLanguage, categories);

					divByLanguagesAndCategories.Add(languagesAndItsCategories);
				}
			}

			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();
		}

        protected void btnFlashcardsDisplay_Click(object sender, EventArgs e)
        {
			LinkButton btn = sender as LinkButton;


			string commandArgument = btn.CommandArgument;
			string[] arguments = commandArgument.Split(',');


			string languages = arguments[0];
			string category = arguments[1];

			Response.Redirect($"FlashcardsDisplay.aspx?languages={Server.UrlEncode(languages)}&category={Server.UrlEncode(category)}");



		}
    }
}