﻿using iTextSharp.text.pdf;
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



		protected void GeneratePDF(object sender, EventArgs e)
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
			BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			Font unicodeFont = new Font(bf, 7, Font.NORMAL, BaseColor.BLACK);
			Font headerFont = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);
			Font titleFont = new Font(bf, 11, Font.NORMAL, BaseColor.BLACK);
			Font textFont = new Font(bf, 14, Font.NORMAL, BaseColor.BLACK);
			Font smallFont = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);

			using (MemoryStream ms = new MemoryStream())
			{
				Document document = new Document(PageSize.A4, 5, 5, 10, 10);
				PdfWriter writer = PdfWriter.GetInstance(document, ms);
				document.Open();

				PdfPTable table = new PdfPTable(2);
				table.WidthPercentage = 100;
				table.SetWidths(new float[] { 1, 1 });

				// Add front and back of flashcards side by side
				for (int i = 0; i < flashcards.Count; i++)
				{
					// Front of flashcard
					PdfPCell frontCell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont, flashcards[i].TargetLanguage, flashcards[i].WordTarget,
						flashcards[i].ExampleSentenceTarget, flashcards[i].Pronunciation, flashcards[i].Proficiency, flashcards[i].Id))
					{ Border = PdfPCell.NO_BORDER };

					table.AddCell(frontCell);

					// Back of flashcard
					PdfPCell backCell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont, flashcards[i].SourceLanguage, flashcards[i].WordSource,
						flashcards[i].ExampleSentenceSource, flashcards[i].Tips, flashcards[i].Proficiency, flashcards[i].Id))
					{ Border = PdfPCell.NO_BORDER };

					table.AddCell(backCell);

					if ((i + 1) % 2 == 0)
					{
						document.Add(table);
						table = new PdfPTable(2);
						table.WidthPercentage = 100;
						table.SetWidths(new float[] { 1, 1 });
					}
				}

				if (table.Size > 0)
				{
					document.Add(table);
				}

				document.Close();

				Response.ContentType = "application/pdf";
				Response.AddHeader("content-disposition", "attachment;filename=Flashcards.pdf");
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
				Response.BinaryWrite(ms.ToArray());
				Response.End();
			}
		}

		private PdfPTable CreateFlashcardTable(Font headerFont, Font titleFont, Font textFont, Font smallFont, string language,
			string word, string sentence, string additionalInfo, string level, int id)
		{
			PdfPTable table = new PdfPTable(1);
			table.WidthPercentage = 100;
			table.DefaultCell.Border = PdfPCell.NO_BORDER;

			// Create card container
			PdfPCell cardContainer = new PdfPCell();
			cardContainer.BackgroundColor = BaseColor.WHITE;
			cardContainer.Padding = 10;
			cardContainer.PaddingLeft = 30;
			cardContainer.Border = PdfPCell.BOX;
			cardContainer.BorderColor = BaseColor.BLACK;

			// Card header
			PdfPTable headerTable = new PdfPTable(3);
			headerTable.WidthPercentage = 100;
			headerTable.SetWidths(new float[] { 1, 4, 1 });

			headerTable.AddCell(new PdfPCell(new Phrase(id.ToString(), headerFont)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_LEFT });
			headerTable.AddCell(new PdfPCell(new Phrase(language, headerFont)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_CENTER });
			headerTable.AddCell(new PdfPCell(new Phrase(level, headerFont)) { Border = PdfPCell.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT });

			cardContainer.AddElement(headerTable);

			// Card body
			Paragraph wordParagraph = new Paragraph(word, titleFont) { Alignment = Element.ALIGN_CENTER };
			Paragraph sentenceParagraph = new Paragraph(sentence, textFont) { Alignment = Element.ALIGN_CENTER };
			Paragraph additionalInfoParagraph = new Paragraph(additionalInfo, smallFont) { Alignment = Element.ALIGN_CENTER };

			cardContainer.AddElement(wordParagraph);
			cardContainer.AddElement(sentenceParagraph);
			cardContainer.AddElement(additionalInfoParagraph);

			table.AddCell(cardContainer);

			return table;
		}
	
	
	}
}