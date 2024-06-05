using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class UserFlashcardGroups : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GenerateFlashcardGroups();
		}

        protected void btnFlashcardGroup_Click(object sender, EventArgs e)
        {
			Response.Redirect("FlashcardDisplay.aspx");
        }



		protected void GenerateFlashcardGroups()
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			User user = (User)Session["LoggedInUser"];
			
			List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsByUser(user);

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				Label languageTitle = new Label();
				languageTitle.CssClass = "lbl-category-groups";
				languageTitle.Text = "<br/><br/>" + sourceLanguage +" / "+ targetLanguage + ":<br/>";
				categoryGroups.Controls.Add(languageTitle);

				List<string> categoryGroupsByLanguages = flashcardServices.GetCategoryGroupsByLanguagesAndUser(user, sourceLanguage, targetLanguage);

				for (int n = 0; n < categoryGroupsByLanguages.Count; n++)
				{
					Button btnCategory = new Button();
					btnCategory.CssClass = "btn-flashcard-group";
					btnCategory.Text = categoryGroupsByLanguages[n];
					categoryGroups.Controls.Add(btnCategory);
				}
			}
		}
	}
}