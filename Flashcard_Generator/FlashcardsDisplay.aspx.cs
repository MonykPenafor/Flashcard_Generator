using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardsDisplay : System.Web.UI.Page
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
					LoadFlashcardsByLanguagesAndCategory(source, target, category);
				}
			}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string source, string target, string category)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			var flashcards = flashcardServices.GetAllPublicFlashcardsByLanguagesAndCategory(source, target, category, false);

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}
	
	}
}