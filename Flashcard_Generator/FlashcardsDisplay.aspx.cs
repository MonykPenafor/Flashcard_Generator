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
			LoadFlashcards();
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