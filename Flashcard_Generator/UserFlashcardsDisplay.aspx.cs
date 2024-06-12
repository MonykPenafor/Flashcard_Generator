using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class UserFlashcardsDisplay : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string source = Request.QueryString["source"];
				string target = Request.QueryString["target"];
				string category = Request.QueryString["category"];

				if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(target) && !string.IsNullOrEmpty(category))
				{

					User user = (User)Session["LoggedInUser"];
					string username = user.Username;

					LoadFlashcardsByLanguagesAndCategory(source, target, category, username, true);
				}
			}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string source, string target, string category, string username, bool isOwner)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			var flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, username, isOwner);

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}

	}
}