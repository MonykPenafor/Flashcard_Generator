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


		protected void GeneratePDF(object sender, EventArgs e)
		{
			string source = Request.QueryString["source"];
			string target = Request.QueryString["target"];
			string category = Request.QueryString["category"];
			bool isOwner = false;

			FlashcardServices flashcardServices = new FlashcardServices();
			List<Flashcard> flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, null, isOwner);

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

				int cardsPerPage = 16;
				int tillThisFlashcard = cardsPerPage;
				int numberOfFlashcards = flashcards.Count; // 56 fc - 8 paginas - 4f e 4b

				int pages = numberOfFlashcards/cardsPerPage;    // 4 pages for each (f and b)
				if (numberOfFlashcards % cardsPerPage != 0)
				{
					pages++;
				}

				for (int i = 0; i < pages; i++)
				{

					PdfPTable frontTable = new PdfPTable(2);
					frontTable.WidthPercentage = 100;
					frontTable.SetWidths(new float[] { 1, 1 });

					PdfPTable backTable = new PdfPTable(2);
					backTable.WidthPercentage = 100;
					backTable.SetWidths(new float[] { 1, 1 });

					int fromThisFlashcard = i;
					if (i != 0)
					{
						fromThisFlashcard = i*cardsPerPage;
					}

					for (int j = fromThisFlashcard; j < tillThisFlashcard; j++)
					{
						try
						{
							// Print front of flashcard
							PdfPCell cell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont, flashcards[j].TargetLanguage, flashcards[j].WordTarget,
							flashcards[j].ExampleSentenceTarget, flashcards[j].Pronunciation, flashcards[j].Proficiency, flashcards[j].Id))
							{ Border = PdfPCell.NO_BORDER, FixedHeight = 102 };

							frontTable.AddCell(cell);
						}
						catch (ArgumentOutOfRangeException)
						{
							break;
						}
					}

					for (int j = fromThisFlashcard; j < tillThisFlashcard; j = j+2)
					{
						try
						{
							// Print back of flashcard
							PdfPCell cell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont, flashcards[j+1].SourceLanguage, flashcards[j+1].WordSource,
							flashcards[j+1].ExampleSentenceSource, flashcards[j+1].Tips, flashcards[j+1].Proficiency, flashcards[j+1].Id))
							{ Border = PdfPCell.NO_BORDER, FixedHeight = 102 };

							backTable.AddCell(cell);

							// Print back of flashcard
							PdfPCell cell2 = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont, flashcards[j].SourceLanguage, flashcards[j].WordSource,
							flashcards[j].ExampleSentenceSource, flashcards[j].Tips, flashcards[j].Proficiency, flashcards[j].Id))
							{ Border = PdfPCell.NO_BORDER, FixedHeight = 102 };

							backTable.AddCell(cell2);
						}
						catch (ArgumentOutOfRangeException)
						{
							break;
						}
					}

					// Add front pages to the document
					document.Add(frontTable);

					// Add back pages to the document
					document.NewPage();

					document.Add(backTable);

					tillThisFlashcard = tillThisFlashcard + cardsPerPage;
				}
				//2 pags

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