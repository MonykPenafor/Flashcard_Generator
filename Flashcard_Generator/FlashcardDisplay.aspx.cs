using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class FlashcardDisplay : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LoadFlashcards();
		}


		protected void LoadFlashcards()
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			List<Flashcard> flashcards = flashcardServices.GetPublicFlashcards();

			foreach (Flashcard flashcard in flashcards)
			{
				TableRow row = new TableRow();

				// CheckBox cell
				TableCell checkBoxCell = new TableCell();
				CheckBox checkBox = new CheckBox();
				checkBoxCell.Controls.Add(checkBox);
				row.Cells.Add(checkBoxCell);

				// User cell
				TableCell userCell = new TableCell();
				userCell.Text = flashcard.User.Username;
				row.Cells.Add(userCell);

				// Languages cell
				TableCell languagesCell = new TableCell();
				languagesCell.Text = $"{flashcard.SourceLanguage}<br/>{flashcard.TargetLanguage}";
				row.Cells.Add(languagesCell);

				// Category cell
				TableCell categoryCell = new TableCell();
				categoryCell.Text = flashcard.Category;
				row.Cells.Add(categoryCell);

				// Vocabulary / Translation cell
				TableCell vocabularyCell = new TableCell();
				vocabularyCell.Text = $"{flashcard.WordSource}<br/>{flashcard.WordTarget}";
				row.Cells.Add(vocabularyCell);

				// Usage / Pronunciation / Translation cell
				TableCell usageCell = new TableCell();
				usageCell.Text = $"{flashcard.ExampleSentenceSource}<br/>{flashcard.Pronunciation}<br/>{flashcard.ExampleSentenceTarget}";
				row.Cells.Add(usageCell);

				// Tips cell
				TableCell tipsCell = new TableCell();
				tipsCell.Text = flashcard.Tips;
				row.Cells.Add(tipsCell);

				// Level cell
				TableCell levelCell = new TableCell();
				levelCell.Text = flashcard.Proficiency;
				row.Cells.Add(levelCell);

				//// Created at cell
				//TableCell createdAtCell = new TableCell();
				//createdAtCell.Text = flashcard.CreatedAt.ToString("yyyy-MM-dd");
				//row.Cells.Add(createdAtCell);

				//// Updated at cell
				//TableCell updatedAtCell = new TableCell();
				//updatedAtCell.Text = flashcard.UpdatedAt.ToString("yyyy-MM-dd");
				//row.Cells.Add(updatedAtCell);

				// Edit button cell
				TableCell editButtonCell = new TableCell();
				ImageButton editButton = new ImageButton();
				editButton.ImageUrl = "~/Assets/Icons/edit.png";
				editButton.CssClass = "edit edit-button";
				//editButton.Click += (s, e) => EditFlashcard(flashcard.Id); // Implement EditFlashcard method
				editButtonCell.Controls.Add(editButton);
				row.Cells.Add(editButtonCell);

				FlashcardTable.Rows.Add(row);
			}
		}







		protected void btnDelete_Click(object sender, EventArgs e)
		{
			
		}
	}
}