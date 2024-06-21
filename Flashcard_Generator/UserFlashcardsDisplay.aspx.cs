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
		public static string DeleteFlashcard(int flashcardId)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.DeleteFlashcard(flashcardId);


		}

		[WebMethod]
		public static string UpdateFlashcard(int id, string wtarget, string wsource, string etarget, string pron, string esource, string tips, string level)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.UpdateFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level);
		}


		protected void GeneratePDF(object sender, EventArgs e)
		{
			string source = Request.QueryString["source"];
			string target = Request.QueryString["target"];
			string category = Request.QueryString["category"];

			User user = (User)Session["LoggedInUser"];
			string username = user.Username;

			bool isOwner = true; 

			FlashcardServices flashcardServices = new FlashcardServices();
			List<Flashcard> flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, username, isOwner);


			string fontPath = Server.MapPath("~/Assets/NotoSansCJKsc-Regular.otf"); 
			BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			Font unicodeFont = new Font(bf, 10, Font.NORMAL);

			using (MemoryStream ms = new MemoryStream())
			{
				Document document = new Document(PageSize.A4, 25, 25, 30, 30);
				PdfWriter writer = PdfWriter.GetInstance(document, ms);
				document.Open();

				foreach (var flashcard in flashcards)
				{
					PdfPTable table = new PdfPTable(1);
					table.WidthPercentage = 100;

					// Adicionando os dados dos flashcards em formato de cartão
					table.AddCell(new PdfPCell(new Phrase($"Word: {flashcard.WordTarget} / {flashcard.WordSource}", unicodeFont)));
					table.AddCell(new PdfPCell(new Phrase($"Usage: {flashcard.ExampleSentenceTarget} / {flashcard.Pronunciation} / {flashcard.ExampleSentenceSource}", unicodeFont)));
					table.AddCell(new PdfPCell(new Phrase($"Tips: {flashcard.Tips}", unicodeFont)));
					table.AddCell(new PdfPCell(new Phrase($"Level: {flashcard.Proficiency}", unicodeFont)));

					document.Add(table);
					document.Add(new Phrase("\n", unicodeFont)); // Adiciona um espaço entre os cartões
					document.NewPage();
				}

				document.Close();

				Response.ContentType = "application/pdf";
				Response.AddHeader("content-disposition", "attachment;filename=Flashcards.pdf");
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
				Response.BinaryWrite(ms.ToArray());
				Response.End();
			}
		}
	}
}