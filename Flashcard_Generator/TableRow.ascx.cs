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

			LinkButton btn = sender as LinkButton;
			int flashcardId = Convert.ToInt32(btn.CommandArgument);

			string script = $"<script>showModal({flashcardId});</script>";
			ScriptManager.RegisterStartupScript(this, GetType(), "showEditModal", script, false);
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
				string source = Request.QueryString["source"];
				string target = Request.QueryString["target"];
				string category = Request.QueryString["category"];

				Response.Redirect($"UserFlashcardsDisplay.aspx?source={source}&target={target}&category={category}");

				//// Exemplo de uso:
				//string script = "showToast('Flashcard deleted successfully.');";
				//ScriptManager.RegisterStartupScript(this, GetType(), "showToast", script, true);
			}
		}
	}
}