using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardsDisplay : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string source = Request.QueryString["source"];
				string target = Request.QueryString["target"];
				string category = Request.QueryString["category"];

				if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(target) && !string.IsNullOrEmpty(category))
				{
					User user = (User)Session["LoggedInUser"];

					if (user != null)
					{
						LoadFlashcardsByLanguagesAndCategory(source, target, category, user.Username, false);
					}
					else
					{
						LoadFlashcardsByLanguagesAndCategory(source, target, category, null, false);
					}
				}
			}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string source, string target, string category, string user, bool isOwner)
		{
			FlashcardServices flashcardServices = new FlashcardServices();

			var flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, user, isOwner);

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}


		protected void GeneratePDF_Click(object sender, EventArgs e)
		{
			FlashcardServices flashcardServices = new FlashcardServices();

			string source = Request.QueryString["source"];
			string target = Request.QueryString["target"];
			string category = Request.QueryString["category"];
			User user = (User)Session["LoggedInUser"];
			bool isOwner = false;

			List<Flashcard> flashcards;

			if (user == null)
			{
				flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, null, isOwner);
			}
			else
			{
				flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, user.Username, isOwner);
			}

			string fontPath = Server.MapPath("~/Assets/NotoSansCJKsc-Regular.otf");

			MemoryStream ms = flashcardServices.GeneratePDF(flashcards, fontPath);

			Response.ContentType = "application/pdf";
			Response.AddHeader("content-disposition", "attachment;filename=Flashcards.pdf");
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.BinaryWrite(ms.ToArray());
			Response.End();
		}
	}
}