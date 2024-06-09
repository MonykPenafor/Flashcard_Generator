using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class TableRow : System.Web.UI.UserControl
	{
		public Flashcard FlashcardTableRow { get; set; }

		FlashcardServices flashcardServices = new FlashcardServices();


		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnEditItem_Click(object sender, EventArgs e)
		{
			//LinkButton btn = sender as LinkButton;
			//int flashcardId = Convert.ToInt16(btn.CommandArgument);
			//flashcardServices.UpdateFlashcard(flashcardId);
		}

		protected void btnDeleteItem_Click(object sender, EventArgs e)
		{
			LinkButton btn = sender as LinkButton;
			int flashcardId = Convert.ToInt32(btn.CommandArgument);
			string deleted = flashcardServices.DeleteFlashcard(flashcardId);

			if (deleted != "ok!")
			{
				Console.WriteLine(deleted);
			}
			else
			{
				Response.Redirect("UserFlashcardsDisplay.aspx");

				//string script = "showToastAndRedirect('Item deleted successfully!', 'UserFlashcardsDisplay.aspx');";
				//ScriptManager.RegisterStartupScript(this, GetType(), "showToastAndRedirect", script, true);
			}
		}
	}
}