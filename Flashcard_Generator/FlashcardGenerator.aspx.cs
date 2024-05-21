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

			//connect to database and do the work
			//
			//show message that flashcards generated correctly
			//
			//redirects to visualize	

			Response.Redirect("FlashcardsDisplay.aspx");
		}
	}
}