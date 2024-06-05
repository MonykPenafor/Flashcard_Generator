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
			GenerateFlashcardGroups();
		}

        protected void btnFlashcardGroup_Click(object sender, EventArgs e)
        {
			Response.Redirect("FlashcardDisplay.aspx");
        }

		protected void GenerateFlashcardGroups()
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			User user = (User)Session["LoggedInUser"];
			
			List<string> languagesCombination = flashcardServices.GetLanguagesCombinationsByUser(user);


			foreach (string languages in languagesCombination) 
			{
				Label languagesH3 = new Label();
				languagesH3.CssClass = "lbl-category-groups";
				languagesH3.Text = "<br/> <br/><br/> <br/>" + languages + "<br/> <br/>";
				categoryGroups.Controls.Add(languagesH3);

				Button btu = new Button();
				btu.CssClass = "btn-flashcard-group";
				btu.Text = languages;
				categoryGroups.Controls.Add(btu);
			}

		}




    }
}