using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
			User user = (User)Session["LoggedInUser"];

			string sourceLanguage = txtSourceLanguage.Text;
			string targetLanguage = txtTargetLanguage.Text;
			string category = txtCategory.Text;
			string[] wordSource = CreateArrayOfStrings(txtVocabularySource.Text);
			string[] wordTarget = CreateArrayOfStrings(txtVocabularyTarget.Text);
			string[] exampleSentenceTarget = CreateArrayOfStrings(txtWordOrPhrase.Text);
			string[] exampleSentenceSource = CreateArrayOfStrings(txtTranslation.Text);
			string[] tips = CreateArrayOfStrings(txtTip.Text);
			string[] pronunciation = CreateArrayOfStrings(txtSimplified.Text);
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






		protected string[] CreateArrayOfStrings(string userInput) 
		{
			string[] separatedStrings = userInput.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

			List<string> stringList = new List<string>();

			foreach (string item in separatedStrings)
			{
				string itemCleaned = item.Trim().Trim('"');
				stringList.Add(itemCleaned);
			}


			return stringList.ToArray();
		}













	}
}