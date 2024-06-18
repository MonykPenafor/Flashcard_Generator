using System;
using System.Collections.Generic;
using System.ComponentModel;
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




		protected void btnEditFlashcard_Click(object sender, EventArgs e)
		{

			int flashcardId = Convert.ToInt32(fcid.Value);

			//string script = $"<script>showModal({flashcardId});</script>";
			//ScriptManager.RegisterStartupScript(this, GetType(), "showEditModal", script, false);
		}



		protected void btnDeleteFlashcard_Click(object sender, EventArgs e)
		{

			int flashcardId = Convert.ToInt32(fcid.Value);
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
			}
		}

	}
}