using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace Flashcard_Generator
{
	public class FlashcardServices
	{

		private string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;


		public string CreateFlashcard(Flashcard flashcard)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = "INSERT INTO Flashcards (id_user, source_language, target_language, category, word_source, word_target, example_sentence_source, example_sentence_target, pronunciation, tips, proficiency, is_public) " +
							"VALUES (@UserId, UPPER(@SourceLanguage), UPPER(@TargetLanguage), UPPER(@Category), @WordSource, @WordTarget, @ExampleSentenceSource, @ExampleSentenceTarget, @Pronunciation, @Tips, @Proficiency, @IsPublic)";
				
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@UserId", flashcard.User.Id);
					cmd.Parameters.AddWithValue("@SourceLanguage", flashcard.SourceLanguage);
					cmd.Parameters.AddWithValue("@TargetLanguage", flashcard.TargetLanguage);
					cmd.Parameters.AddWithValue("@Category", flashcard.Category);
					cmd.Parameters.AddWithValue("@WordSource", flashcard.WordSource);
					cmd.Parameters.AddWithValue("@WordTarget", flashcard.WordTarget);
					cmd.Parameters.AddWithValue("@ExampleSentenceSource", flashcard.ExampleSentenceSource);
					cmd.Parameters.AddWithValue("@ExampleSentenceTarget", flashcard.ExampleSentenceTarget);
					cmd.Parameters.AddWithValue("@Pronunciation", flashcard.Pronunciation);
					cmd.Parameters.AddWithValue("@Tips", flashcard.Tips);
					cmd.Parameters.AddWithValue("@Proficiency", flashcard.Proficiency);
					cmd.Parameters.AddWithValue("@IsPublic", flashcard.IsPublic);

					try
					{
						cmd.ExecuteNonQuery();
						return "ok";
					}
					catch (SqlException ex)
					{
						if (ex.Number == 2628) // 2628 is the error number.
						{
							return "Data truncation error. One of the fields is too long. " + ex.Message;
						}
						else
						{
						return $"Failed creating flashcard!: {ex.Message}";
						}
					}
					catch (Exception ex)
					{
						return $"Failed creating flashcard!: {ex.Message}";
					}
				}
			}
		}

		public string DeleteFlashcard(int flashcardId)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				{
					string query = "DELETE FROM Flashcards WHERE id_flashcard = @idFlashcard";

					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@idFlashcard", flashcardId);

						try
						{
							cmd.ExecuteNonQuery();
							return "ok";
						}
						catch (SqlException ex)
						{
							return ex.Message;
						}
						catch (Exception ex)
						{
							return ex.Message;
						}
					}
				}
			}
		}

		public string UpdateFlashcard(int id, string wtarget, string wsource, string etarget, string pron, string esource, string tips, string level, bool isPublic)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				{
					string query = "UPDATE Flashcards SET word_source = @wsource, word_target = @wtarget, example_sentence_source = @esource, example_sentence_target = @etarget, pronunciation = @pron, tips = @tips, proficiency = @level, is_public = @isPublic WHERE id_flashcard = @id";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@id", id);
						cmd.Parameters.AddWithValue("@wsource", wsource);
						cmd.Parameters.AddWithValue("@wtarget", wtarget);
						cmd.Parameters.AddWithValue("@esource", esource);
						cmd.Parameters.AddWithValue("@etarget", etarget);
						cmd.Parameters.AddWithValue("@pron", pron);
						cmd.Parameters.AddWithValue("@tips", tips);
						cmd.Parameters.AddWithValue("@level", level);
						cmd.Parameters.AddWithValue("@isPublic", isPublic);

						try
						{
							cmd.ExecuteNonQuery();
							return "ok";
						}
						catch (SqlException ex)
						{
							if (ex.Number == 2628) //  2628 is the error number.
							{
								return "Data truncation error. One of the fields is too long." + ex.Message;
							}
							else
							{
							return $"Failed!: {ex.Message}";
							}
						}
						catch (Exception ex)
						{

							return $"Failed!: {ex.Message}";
						}
					}
				}

			}

		}

		public Flashcard GetFlashcard(int flashcardID)
		{
			UserServices userServices = new UserServices();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = @"SELECT u.username, f.source_language, f.target_language, f.category, f.word_source, f.word_target, f.example_sentence_source, f.example_sentence_target, f.pronunciation,f.tips,f.proficiency, f.is_public	FROM FLASHCARDS f, users u WHERE f.id_user = u.id_user AND f.id_flashcard = @flashcardId";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@flashcardId", flashcardID);

					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								string username = reader.GetString(0);
								User user = userServices.GetUserByUsernameOrEmail(username);

								var flashcard = new Flashcard(
									user,
									reader.GetString(1),  // SourceLanguage
									reader.GetString(2),  // TargetLanguage
									reader.GetString(3),  // Category
									reader.GetString(4),  // WordSource
									reader.GetString(5),  // WordTarget
									reader.GetString(6),  // ExampleSentenceSource
									reader.GetString(7),  // ExampleSentenceTarget
									reader.IsDBNull(8) ? null : reader.GetString(8),  // Pronunciation
									reader.IsDBNull(9) ? null : reader.GetString(9),  // Tips
									reader.IsDBNull(10) ? null : reader.GetString(10),  // Proficiency
									reader.GetBoolean(11)  // IsPublic
								);
								return flashcard;
							}
							else
							{
								Console.WriteLine("Query couldn't read anything");
								return null; 
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
						return null;
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
						return null;
					}
				}
			}
		}



		public List<Flashcard> GetFlashcardsByLanguagesCategoriesAndVisibility(string source, string target, string category, string loggedUser, bool isOwner)
		{
			var flashcards = new List<Flashcard>();

			UserServices userServices = new UserServices();

			using (SqlConnection con = new SqlConnection(connectionString))
			{

				string query;

				if (loggedUser == null)
				{
					query = @"SELECT f.id_flashcard, u.username, f.source_language, f.target_language, f.category, f.word_source, f.word_target, f.example_sentence_source, f.example_sentence_target, f.pronunciation,f.tips,f.proficiency, f.is_public	FROM FLASHCARDS f JOIN USERS u ON f.id_user = u.id_user WHERE f.source_language = @source AND f.target_language = @target AND f.category = @category AND f.is_public = 1";
				}
				else
				{
					if (!isOwner)
					{
						query = @"SELECT f.id_flashcard, u.username, f.source_language, f.target_language, f.category, f.word_source, f.word_target, f.example_sentence_source, f.example_sentence_target, f.pronunciation,f.tips,f.proficiency,f.is_public	FROM FLASHCARDS f JOIN USERS u ON f.id_user = u.id_user WHERE f.source_language = @source AND f.target_language = @target AND f.category = @category AND f.is_public = 1 AND u.username != @user";

					}
					else
					{
						query = @"SELECT f.id_flashcard, u.username, f.source_language, f.target_language, f.category, f.word_source, f.word_target, f.example_sentence_source, f.example_sentence_target, f.pronunciation,f.tips,f.proficiency,f.is_public	FROM FLASHCARDS f JOIN USERS u ON f.id_user = u.id_user WHERE f.source_language = @source AND f.target_language = @target AND f.category = @category AND u.username = @user";

					}
				}

				con.Open();

				using (SqlCommand cmd = new SqlCommand(query, con))
				{

					cmd.Parameters.AddWithValue("@source", source);
					cmd.Parameters.AddWithValue("@target", target);
					cmd.Parameters.AddWithValue("@category", category);

					if (loggedUser != null)
					{
						cmd.Parameters.AddWithValue("@user", loggedUser);
					}

					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								string username = reader.GetString(1);
								User user = userServices.GetUserByUsernameOrEmail(username);

								var flashcard = new Flashcard(
									reader.GetInt32(0),  // Id
									user,
									reader.GetString(2),  // SourceLanguage
									reader.GetString(3),  // TargetLanguage
									reader.GetString(4),  // Category
									reader.GetString(5),  // WordSource
									reader.GetString(6),  // WordTarget
									reader.GetString(7),  // ExampleSentenceSource
									reader.GetString(8),  // ExampleSentenceTarget
									reader.IsDBNull(9) ? null : reader.GetString(9),  // Pronunciation
									reader.IsDBNull(10) ? null : reader.GetString(10),  // Tips
									reader.IsDBNull(11) ? null : reader.GetString(11),  // Proficiency
									reader.GetBoolean(12)  // IsPublic
								);

								flashcards.Add(flashcard);
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
					}
				}
			}
			return flashcards;
		}

		public List<string> GetPublicLanguagesCombinations()
		{
			List<string> languages = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = "SELECT source_language, target_language FROM Flashcards WHERE is_public = 1 GROUP BY source_language, target_language";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								var sourceLanguage = reader.GetString(0);
								var targetLanguage = reader.GetString(1);

								languages.Add(sourceLanguage);
								languages.Add(targetLanguage);
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
					}
				}
			}
			return languages;
		}

		public List<string> GetPublicCategoryGroups(string sourceLanguage, string targetLanguage)
		{
			List<string> categoryGroups = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = "SELECT category FROM Flashcards WHERE source_language = @sourceLanguage AND target_language = @targetLanguage AND is_public = 1 GROUP BY category";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@sourceLanguage", sourceLanguage);
					cmd.Parameters.AddWithValue("@targetLanguage", targetLanguage);

					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								var category = reader.GetString(0);
								categoryGroups.Add(category);
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
					}
				}
			}
			return categoryGroups;
		}

		public List<string> GetLanguagesCombinationsForLoggedUser(User user, bool isUserFlashcards)
		{
			List<string> languages = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query;

				if (isUserFlashcards)
				{
					query = "SELECT source_language, target_language FROM Flashcards WHERE id_user = @id_user GROUP BY source_language, target_language";
				}
				else
				{
					query = "SELECT source_language, target_language FROM Flashcards WHERE id_user != @id_user AND is_public = 1 GROUP BY source_language, target_language";
				}

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id_user", user.Id);

					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								var sourceLanguage = reader.GetString(0);
								var targetLanguage = reader.GetString(1);

								languages.Add(sourceLanguage);
								languages.Add(targetLanguage);
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
					}
				}
			}
			return languages;
		}

		public List<string> GetCategoryGroupsForLoggedUser(User user, string sourceLanguage, string targetLanguage, bool isUserFlashcards)
		{
			List<string> categoryGroups = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query;

				if (isUserFlashcards)
				{
					query = "SELECT category FROM Flashcards WHERE source_language = @sourceLanguage AND target_language = @targetLanguage AND id_user = @id_user GROUP BY category";
				}
				else
				{
					query = "SELECT category FROM Flashcards WHERE source_language = @sourceLanguage AND target_language = @targetLanguage AND id_user != @id_user AND is_public = 1 GROUP BY category";
				}


				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@id_user", user.Id);
					cmd.Parameters.AddWithValue("@sourceLanguage", sourceLanguage);
					cmd.Parameters.AddWithValue("@targetLanguage", targetLanguage);

					try
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								var category = reader.GetString(0);
								categoryGroups.Add(category);
							}
						}
					}
					catch (SqlException ex)
					{
						Console.WriteLine($"SQL Error: {ex.Message}");
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Error: {ex.Message}");
					}
				}
			}
			return categoryGroups;
		}


		public MemoryStream GeneratePDF(List<Flashcard> flashcards, string fontPath)
		{
			BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			Font unicodeFont = new Font(bf, 7, Font.NORMAL, BaseColor.BLACK);
			Font headerFont = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);
			Font titleFont = new Font(bf, 14, Font.NORMAL, BaseColor.BLACK);
			Font textFont = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);
			Font smallFont = new Font(bf, 9, Font.NORMAL, BaseColor.BLACK);

			using (MemoryStream ms = new MemoryStream())
			{
				Document document = new Document(PageSize.A4, 5, 5, 10, 10);
				PdfWriter writer = PdfWriter.GetInstance(document, ms);
				document.Open();

				int cardsPerPage = 16;
				int numberOfFlashcards = flashcards.Count;

				// Calcula o número total de páginas baseado no número de flashcards
				int pages = (int)Math.Ceiling((double)numberOfFlashcards / cardsPerPage);

				for (int i = 0; i < pages; i++)
				{
					PdfPTable frontTable = new PdfPTable(2);
					frontTable.WidthPercentage = 100;
					frontTable.SetWidths(new float[] { 1, 1 });

					PdfPTable backTable = new PdfPTable(2);
					backTable.WidthPercentage = 100;
					backTable.SetWidths(new float[] { 1, 1 });

					int fromThisFlashcard = i * cardsPerPage;
					int tillThisFlashcard = Math.Min(fromThisFlashcard + cardsPerPage, numberOfFlashcards);

					// Preenche a tabela da frente dos flashcards
					for (int j = fromThisFlashcard; j < tillThisFlashcard; j++)
					{
						PdfPCell cell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont,
							flashcards[j].TargetLanguage, flashcards[j].WordTarget, flashcards[j].ExampleSentenceTarget,
							flashcards[j].Pronunciation, flashcards[j].Proficiency, flashcards[j].Id))
						{
							Border = PdfPCell.NO_BORDER,
							FixedHeight = 102
						};
						frontTable.AddCell(cell);
					}

					// Se o número de flashcards na página da frente for ímpar, adiciona uma célula vazia para manter o layout
					if ((tillThisFlashcard - fromThisFlashcard) % 2 != 0)
					{
						PdfPCell emptyCell = new PdfPCell() { Border = PdfPCell.NO_BORDER, FixedHeight = 102 };
						frontTable.AddCell(emptyCell);
					}

					// Preenche a tabela da parte de trás dos flashcards
					for (int j = fromThisFlashcard; j < tillThisFlashcard; j += 2)
					{
						// Preenche a primeira coluna da parte de trás
						if (j + 1 < numberOfFlashcards)
						{
							PdfPCell cell = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont,
								flashcards[j + 1].SourceLanguage, flashcards[j + 1].WordSource,
								flashcards[j + 1].ExampleSentenceSource, flashcards[j + 1].Tips,
								flashcards[j + 1].Proficiency, flashcards[j + 1].Id))
							{
								Border = PdfPCell.NO_BORDER,
								FixedHeight = 102
							};
							backTable.AddCell(cell);
						}
						else
						{
							PdfPCell emptyCell = new PdfPCell() { Border = PdfPCell.NO_BORDER, FixedHeight = 102 };
							backTable.AddCell(emptyCell);
						}

						// Preenche a segunda coluna da parte de trás
						if (j < numberOfFlashcards)
						{
							PdfPCell cell2 = new PdfPCell(CreateFlashcardTable(headerFont, titleFont, textFont, smallFont,
								flashcards[j].SourceLanguage, flashcards[j].WordSource,
								flashcards[j].ExampleSentenceSource, flashcards[j].Tips,
								flashcards[j].Proficiency, flashcards[j].Id))
							{
								Border = PdfPCell.NO_BORDER,
								FixedHeight = 102
							};
							backTable.AddCell(cell2);
						}
						else
						{
							PdfPCell emptyCell2 = new PdfPCell() { Border = PdfPCell.NO_BORDER, FixedHeight = 102 };
							backTable.AddCell(emptyCell2);
						}
					}

					// Adiciona páginas ao documento
					document.Add(frontTable);
					document.NewPage();
					document.Add(backTable);
				}

				document.Close();
				return ms;
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