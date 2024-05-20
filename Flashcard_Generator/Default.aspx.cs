using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//REDIRECT TO THE GENERATOR PAGE
		protected void goToGenerator(object sender, EventArgs e)
		{
			Response.Redirect("FlashcardGenerator.aspx");
		}



	}
}