using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardGenerator : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		//CREATE THE FLASHCARDS
		protected void btnCreateFlashcards_Click(object sender, EventArgs e)
		{
			string[] separators = new string[] { "\",\"", "\", \"", "\""};


			//string username = txtUser.Text;
			string sourceLanguage = txtSourceLanguage.Text;
			string targetLanguage = txtTargetLanguage.Text;
			string category = txtCategory.Text;
			string[] sourceVocabulary = txtVocabularySource.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] targetVocabulary = txtVocabularyTarget.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] exampleSentence = txtWordOrPhrase.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] translation = txtTranslation.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] tips = txtTip.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] pronunciation = txtSimplified.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string proficiency = ddlLanguageProficiency.SelectedValue;
			bool isPublic = bool.Parse(ddlPrivacySetting.SelectedValue);

			var numberOfFlashcards = sourceVocabulary.Length;

			string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();

				for (int i = 0; i < numberOfFlashcards; i++)
				{

					string query = "INSERT INTO Flashcards (id_user, source_language, target_language, category, word_source, word_target, example_sentence_source, example_sentence_target, pronunciation, tips, proficiency, is_public) " +
											"VALUES (@UserId, @sourceLanguage, @targetLanguage, @category, @sourceVocabulary, @targetVocabulary, @translation, @exampleSentence, @pronunciation, @tips, @proficiency, @isPublic)";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						cmd.Parameters.AddWithValue("@UserId", 1);
						cmd.Parameters.AddWithValue("@sourceLanguage", sourceLanguage);
						cmd.Parameters.AddWithValue("@targetLanguage", targetLanguage);
						cmd.Parameters.AddWithValue("@category", category);
						cmd.Parameters.AddWithValue("@sourceVocabulary", sourceVocabulary[i]);
						cmd.Parameters.AddWithValue("@targetVocabulary", targetVocabulary[i]);
						cmd.Parameters.AddWithValue("@exampleSentence", exampleSentence[i]);
						cmd.Parameters.AddWithValue("@translation", translation[i]);
						cmd.Parameters.AddWithValue("@tips", tips[i]);
						cmd.Parameters.AddWithValue("@pronunciation", pronunciation[i]);
						cmd.Parameters.AddWithValue("@proficiency", proficiency);
						cmd.Parameters.AddWithValue("@isPublic", isPublic);

						try
						{
							cmd.ExecuteNonQuery();
						}
						catch (SqlException ex)
						{
							lblMessage.Text = $"Failed!: {ex}";
						}
						catch (Exception ex)
						{

							lblMessage.Text = $"Failed!: {ex}";
						}
					}
				}
				lblMessage.Text = $"Set criado com sucesso";
				Response.Redirect("FlashcardDisplay.aspx");


			}

		}
	}
}