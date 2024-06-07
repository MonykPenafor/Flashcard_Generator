using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Flashcard_Generator
{
	public class FlashcardServices
	{


		string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

		public string CreateFlashcard(Flashcard flashcard)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				{
					string query = "INSERT INTO Flashcards (id_user, source_language, target_language, category, word_source, word_target, example_sentence_source, example_sentence_target, pronunciation, tips, proficiency, is_public) " +
											"VALUES (@UserId, @SourceLanguage, @TargetLanguage, @Category, @WordSource, @WordTarget, @ExampleSentenceSource, @ExampleSentenceTarget, @Pronunciation, @Tips, @Proficiency, @IsPublic)";
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
							return $"Failed!: {ex}";
						}
						catch (Exception ex)
						{

							return $"Failed!: {ex}";
						}
					}
				}

			}

		}


		public List<Flashcard> GetAllPublicFlashcards()
		{
			var flashcards = new List<Flashcard>();

			UserServices userServices = new UserServices();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = @"SELECT 
									f.id_flashcard,
									u.username,
									f.source_language,
									f.target_language,
									f.category,
									f.word_source,
									f.word_target,
									f.example_sentence_source,
									f.example_sentence_target,
									f.pronunciation,
									f.tips,
									f.proficiency,
									f.is_public,
									f.created_at,
									f.updated_at
								FROM FLASHCARDS f
								JOIN USERS u ON f.id_user = u.id_user
								WHERE f.is_public = 1";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
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
									reader.IsDBNull(4) ? null : reader.GetString(4),  // Category
									reader.GetString(5),  // WordSource
									reader.GetString(6),  // WordTarget
									reader.GetString(7),  // ExampleSentenceSource
									reader.GetString(8),  // ExampleSentenceTarget
									reader.IsDBNull(9) ? null : reader.GetString(9),  // Pronunciation
									reader.IsDBNull(10) ? null : reader.GetString(10),  // Tips
									reader.IsDBNull(11) ? null : reader.GetString(11),  // Proficiency
									reader.GetBoolean(12)  // IsPublic
														   //reader.GetDateTime(13),  // CreatedAt
														   //reader.GetDateTime(14)   // UpdatedAt
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


		public List<string> GetLanguagesCombinationsByUser(User user)
		{
			List<string> languages = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = "SELECT source_language, target_language FROM Flashcards WHERE id_user = @id_user GROUP BY source_language, target_language";

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


		public List<string> GetCategoryGroupsByLanguagesAndUser(User user, string sourceLanguage, string targetLanguage)
		{
			List<string> categoryGroups = new List<string>();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				string query = "SELECT category FROM Flashcards WHERE source_language = @sourceLanguage AND target_language = @targetLanguage AND id_user = @id_user GROUP BY category";

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


		public string DeleteFlashcard(Flashcard flashcard)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				{
					string query = "DELETE FROM Flashcards WHERE id_flashcard = @idFlashcardarget)";

					using (SqlCommand cmd = new SqlCommand(query, con))
					{

						cmd.Parameters.AddWithValue("@idFlashcard", flashcard.Id);

						try
						{
							cmd.ExecuteNonQuery();
							return "ok!";

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

	}
}