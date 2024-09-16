using iTextSharp.text.pdf;
using iTextSharp.text;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class UserFlashcardsDisplay : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			string source = Request.QueryString["source"];
			string target = Request.QueryString["target"];
			string category = Request.QueryString["category"];

			if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(target) && !string.IsNullOrEmpty(category))
			{

				User user = (User)Session["LoggedInUser"];
				string username = user.Username;

				LoadFlashcardsByLanguagesAndCategory(source, target, category, username, true);
			}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string source, string target, string category, string username, bool isOwner)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			var flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, username, isOwner);

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}

		[WebMethod]
		public static string UpdateFlashcard(int id, string wtarget, string wsource, string etarget, string pron, string esource, string tips, string level, string isPublic)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.UpdateFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level, bool.Parse(isPublic));
		}

		[WebMethod]
		public static string DeleteFlashcard(int flashcardId)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.DeleteFlashcard(flashcardId);
		}

		[WebMethod]
		public static string DeleteAllFlashcards(string lsource, string ltarget, string category, string username)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			List<Flashcard> flashcards = flashcardService.GetFlashcardsByLanguagesCategoriesAndVisibility(lsource, ltarget, category, username, true);

			try
			{
				foreach (Flashcard flashcard in flashcards)
				{
					flashcardService.DeleteFlashcard(flashcard.Id);
				}
				return "ok";
			}
			catch (Exception ex)
			{
				return "Error: " + ex.Message;
			}
		}

		protected void GeneratePDF_Click(object sender, EventArgs e)
		{
			User user = (User)Session["LoggedInUser"];
			string username = user.Username;
			string source = Request.QueryString["source"];
			string target = Request.QueryString["target"];
			string category = Request.QueryString["category"];
			bool isOwner = true;

			FlashcardServices flashcardServices = new FlashcardServices();
			List<Flashcard> flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, username, isOwner);

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