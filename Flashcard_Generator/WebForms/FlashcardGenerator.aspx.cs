using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using System.Linq;

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

			bool equalNumberOfData = ValidateNumberOfFlashcards(wordSource.Length, wordTarget.Length, exampleSentenceSource.Length, exampleSentenceTarget.Length, tips.Length, pronunciation.Length);

			if (!equalNumberOfData)
			{
				lblMessage.Text = $"The number of flashcards in the fields must be the same (only the tips can be empty):<br /> Right now you have {wordTarget.Length} flashcards in Voc.,<br /> {wordSource.Length} in Voc. Transl.,<br /> {exampleSentenceTarget.Length} in Ex.,<br /> {pronunciation.Length} in Ex. Simpl/Pron.,<br /> {exampleSentenceSource.Length} in Ex. Transl.,<br /> and {tips.Length} in Tips.";
				return;
			}

			var numberOfFlashcards = wordTarget.Length;

			FlashcardServices flashcardServices = new FlashcardServices();

			try
			{
				for (int i = 0; i < numberOfFlashcards; i++)
				{
					Flashcard flashcard = new Flashcard(user, sourceLanguage, targetLanguage, category,
						wordSource[i],
						wordTarget[i],
						exampleSentenceSource[i],
						exampleSentenceTarget[i],
						pronunciation[i],
						tips.Length > i ? tips[i] : "",
						proficiency, isPublic
					);

					string result = flashcardServices.CreateFlashcard(flashcard);

					if (result != "ok")
					{
						lblMessage.Text = result;
						return;
					}

				}
			}
			catch (Exception ex)
			{
				lblMessage.Text = ex.Message;
				return;
			}

			lblMessage.Text = $"The Set was created";
			Response.Redirect("/WebForms/FlashcardGroupsDisplayByUser.aspx");
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


		protected bool ValidateNumberOfFlashcards(int a, int b, int c, int d, int tips, int f)
		{
			int[] counts = {a, b, c, d, f};

			if (tips != 0)
			{
				counts = counts.Append(tips).ToArray();
			}

			bool allEqual = counts.All(x => x == counts[0]);
			return allEqual;

			// returns true if all fields has the same amount of flashcards, or all of them except for the tips (tips can be null)
			//return (a == b && b == c && c == d && d == tips && tips == f) || (a == b && b == c && c == d && d == f && tips == 0);
		}
	}
}