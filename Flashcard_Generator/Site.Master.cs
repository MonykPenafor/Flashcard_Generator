﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class SiteMaster : MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{	
			User user = (User)Session["LoggedInUser"];		

			if (user != null) 
			{ 
				lblLoggedInUser.Text = user.Username;
				FlashcardGeneratorPage.Visible = true;
				MyFlashcardsPage.Visible = true;
				
			}

		}

	}
}