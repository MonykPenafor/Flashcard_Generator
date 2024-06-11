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
			//LoadFlashcards();

			if (!IsPostBack)
			{
				string languages = Request.QueryString["languages"];
				string category = Request.QueryString["category"];

				if (!string.IsNullOrEmpty(languages) && !string.IsNullOrEmpty(category))
				{
					LoadFlashcardsByLanguagesAndCategory(languages, category);
				}
			}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string languages, string category)
		{
			// Implemente o carregamento dos flashcards com base nas linguagens e na categoria aqui.
		}


		protected void LoadFlashcards()
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			var flashcards = flashcardServices.GetAllPublicFlashcards();

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}
	}
}