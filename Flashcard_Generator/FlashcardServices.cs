using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flashcard_Generator
{
	public class FlashcardServices
	{


		public string CreateFlashcard(Flashcard flashcard)
		{
			string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

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



	}
}