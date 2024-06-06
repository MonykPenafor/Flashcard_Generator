using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardDisplay : Page
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


		protected void btnDelete_Click(object sender, EventArgs e)
		{
			
		}

	}
}