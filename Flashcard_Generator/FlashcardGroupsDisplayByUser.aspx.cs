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

			if (!IsPostBack)
			{
				LoadFlashcardGroups();
			}

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

			Response.Redirect($"UserFlashcardsDisplay.aspx?source={Server.UrlEncode(source)}&target={Server.UrlEncode(target)}&category={Server.UrlEncode(category)}");
		}


		protected void LoadFlashcardGroups()
		{
			User user = (User)Session["LoggedInUser"];
			FlashcardServices flashcardServices = new FlashcardServices();
			List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsForLoggedUser(user, true);
			List<DivByLanguagesAndCategories> divByLanguagesAndCategories = new List<DivByLanguagesAndCategories>();

			for (int i = 0; i < languagesCombination.Count; i = i+2)
			{
				string sourceLanguage = languagesCombination[i];
				string targetLanguage = languagesCombination[i+1];

				List<string> categories = flashcardServices.GetCategoryGroupsForLoggedUser(user, sourceLanguage, targetLanguage, true);

				var languagesAndItsCategories = new DivByLanguagesAndCategories(sourceLanguage, targetLanguage, categories);

				divByLanguagesAndCategories.Add(languagesAndItsCategories);
			}
			rptrFlashcardsByLanguageCombination.DataSource = divByLanguagesAndCategories;
			rptrFlashcardsByLanguageCombination.DataBind();
		}



		protected void btnNewFlashcardGroup_Click(Object sender, EventArgs e)
		{
			Response.Redirect($"FlashcardGenerator.aspx");
		}

	}
}