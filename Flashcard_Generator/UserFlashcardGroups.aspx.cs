using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class UserFlashcardGroups : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnFlashcardGroup_Click(object sender, EventArgs e)
        {
			Response.Redirect("FlashcardDisplay.aspx");
        }
    }
}