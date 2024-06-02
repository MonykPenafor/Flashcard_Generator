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
			string[] separators = new string[] { "\",\"", "\", \"", "\"" };

			User user = (User)Session["LoggedInUser"];


			string sourceLanguage = txtSourceLanguage.Text;
			string targetLanguage = txtTargetLanguage.Text;
			string category = txtCategory.Text;
			string[] wordSource = txtVocabularySource.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] wordTarget = txtVocabularyTarget.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] exampleSentenceTarget = txtWordOrPhrase.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] exampleSentenceSource = txtTranslation.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] tips = txtTip.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string[] pronunciation = txtSimplified.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string proficiency = ddlLanguageProficiency.SelectedValue;
			bool isPublic = bool.Parse(ddlPrivacySetting.SelectedValue);

			var numberOfFlashcards = wordSource.Length;

			FlashcardServices flashcardServices = new FlashcardServices();

			for (int i = 0; i < numberOfFlashcards; i++)
			{
				Flashcard flashcard = new Flashcard(
					user,
					sourceLanguage,
					targetLanguage,
					category,
					wordSource[i],
					wordTarget[i],
					exampleSentenceSource[i],
					exampleSentenceTarget[i],
					pronunciation[i],
					tips[i],
					proficiency,
					isPublic
				);

				string created = flashcardServices.CreateFlashcard(flashcard);

				if (created != "ok")
				{
					lblMessage.Text = created;
					return;
				}

			}

			lblMessage.Text = $"The Set was created";
			Response.Redirect("FlashcardDisplay.aspx");
		}
	}
}