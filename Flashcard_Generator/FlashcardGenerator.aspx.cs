using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Flashcard_Generator
{
	public partial class FlashcardGenerator : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			txtVocabularyTarget.Attributes.Add("required", "required");
			txtVocabularySource.Attributes.Add("required", "required");
			txtWordOrPhrase.Attributes.Add("required", "required");
			txtSimplified.Attributes.Add("required", "required");
			txtTranslation.Attributes.Add("required", "required");
			txtTip.Attributes.Add("required", "required");

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
				Flashcard flashcard = new Flashcard(user,sourceLanguage,targetLanguage,category,
					wordSource[i],
					wordTarget[i],
					exampleSentenceSource[i],
					exampleSentenceTarget[i],
					pronunciation[i],
					tips[i],
					proficiency,isPublic
				);

				string result = flashcardServices.CreateFlashcard(flashcard);

				if (result != "ok")
				{
					lblMessage.Text = result;
					return;
				}

			}

			lblMessage.Text = $"The Set was created";
			Response.Redirect("FlashcardGroupsDisplayByUser.aspx");
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