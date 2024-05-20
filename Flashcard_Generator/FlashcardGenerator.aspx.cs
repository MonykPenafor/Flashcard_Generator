using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardGenerator : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//CREATE THE FLASHCARDS
		protected void CreateFlashcards(object sender, EventArgs e)
		{
			Response.Redirect("Default.aspx");
		}
	}
}