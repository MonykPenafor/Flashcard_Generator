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
			//string username = txtUser.Text;
			string sourceLanguage = txtSourceLanguage.Text;
			string targetLanguage = txtTargetLanguage.Text;
			string category = txtCategory.Text;
			string sourceVocabulary = txtVocabularySource.Text;
			string targetVocabulary = txtVocabularyTarget.Text;
			string exampleSentence = txtWordOrPhrase.Text;
			string translation = txtTranslation.Text;
			string tips = txtTip.Text;
			string pronunciation = txtSimplified.Text;
			string proficiency = ddlLanguageProficiency.SelectedValue;
			bool isPublic = bool.Parse(ddlPrivacySetting.SelectedValue);


			string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				string query = "INSERT INTO Flashcards (id_user, source_language, target_language, category, word_source, word_target, example_sentence_source, example_sentence_target, pronunciation, tips, difficulty_level, is_public) " +
										"VALUES (@UserId, @sourceLanguage, @targetLanguage, @category, @sourceVocabulary, @targetVocabulary, @translation, @exampleSentence, @pronunciation, @tips, @proficiency, @isPublic)";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@UserId", 1);
					cmd.Parameters.AddWithValue("@sourceLanguage", sourceLanguage);
					cmd.Parameters.AddWithValue("@targetLanguage", targetLanguage);
					cmd.Parameters.AddWithValue("@category", category);
					cmd.Parameters.AddWithValue("@sourceVocabulary", sourceVocabulary);
					cmd.Parameters.AddWithValue("@targetVocabulary", targetVocabulary);
					cmd.Parameters.AddWithValue("@exampleSentence", exampleSentence);
					cmd.Parameters.AddWithValue("@translation", translation);
					cmd.Parameters.AddWithValue("@tips", tips);
					cmd.Parameters.AddWithValue("@pronunciation", pronunciation);
					cmd.Parameters.AddWithValue("@proficiency", proficiency);
					cmd.Parameters.AddWithValue("@isPublic", isPublic);



					try
					{
						cmd.ExecuteNonQuery();
						Response.Redirect("FlashcardDisplay.aspx");
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

		}
	}
}