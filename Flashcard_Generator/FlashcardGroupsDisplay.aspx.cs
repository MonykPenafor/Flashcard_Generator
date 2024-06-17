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
			if (!IsPostBack)
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
		}

		protected void LoadFlashcardGroups(bool isLogged)
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();

			if (isLogged)
			{
				List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsForLoggedUser(user, false);

				for (int i = 0; i < languagesCombination.Count; i = i+2)
				{
					string sourceLanguage = languagesCombination[i];
					string targetLanguage = languagesCombination[i+1];


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

					List<string> categories = flashcardServices.GetPublicCategoryGroups(sourceLanguage, targetLanguage);

					var languagesAndItsCategories = new DivByLanguagesAndCategories(sourceLanguage, targetLanguage, categories);

					divByLanguagesAndCategories.Add(languagesAndItsCategories);
				}
			}

			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();
		}

		protected void rptrFlashcardsByCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
		{
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				RepeaterItem parentItem = (RepeaterItem)e.Item.Parent.Parent;
				DivByLanguagesAndCategories parentData = (DivByLanguagesAndCategories)parentItem.DataItem;

				LinkButton btnFlashcardGroup = (LinkButton)e.Item.FindControl("btnFlashcardGroup");
				string category = (string)e.Item.DataItem;
				btnFlashcardGroup.CommandArgument = $"{parentData.SourceLanguage},{parentData.TargetLanguage},{category}";
			}
		}

		protected void btnFlashcardsDisplay_Click(object sender, EventArgs e)
		{
			LinkButton btn = sender as LinkButton;
			string commandArgument = btn.CommandArgument;
			string[] arguments = commandArgument.Split(',');

			string source = arguments[0];
			string target = arguments[1];
			string category = arguments[2];

			Response.Redirect($"FlashcardsDisplay.aspx?source={Server.UrlEncode(source)}&target={Server.UrlEncode(target)}&category={Server.UrlEncode(category)}");
		}

    }
}