using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class Home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			User user = (User)Session["LoggedInUser"];

			if (user != null)
			{
				pnlProfile.Visible = true;
				pnlLoginSignUp.Visible = false;
			}
		}

		protected void btnRegister_Click(object sender, EventArgs e)
		{
			pnlLogin.Visible = false;
			pnlSignUp.Visible = true;
		}
		protected void btnLogin_Click(object sender, EventArgs e)
		{
			pnlSignUp.Visible = false;
			pnlLogin.Visible = true;
		}

		protected void btnLogOut_Click(object sender, EventArgs e)
		{
			Session["LoggedInUser"] = null;
			Response.Redirect("Home.aspx");
		}

	}
}