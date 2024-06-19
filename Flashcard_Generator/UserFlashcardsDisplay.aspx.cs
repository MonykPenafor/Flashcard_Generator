using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class UserFlashcardsDisplay : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
				string source = Request.QueryString["source"];
				string target = Request.QueryString["target"];
				string category = Request.QueryString["category"];

				if (!string.IsNullOrEmpty(source) && !string.IsNullOrEmpty(target) && !string.IsNullOrEmpty(category))
				{

					User user = (User)Session["LoggedInUser"];
					string username = user.Username;

					LoadFlashcardsByLanguagesAndCategory(source, target, category, username, true);
				}
		}

		private void LoadFlashcardsByLanguagesAndCategory(string source, string target, string category, string username, bool isOwner)
		{
			FlashcardServices flashcardServices = new FlashcardServices();
			var flashcards = flashcardServices.GetFlashcardsByLanguagesCategoriesAndVisibility(source, target, category, username, isOwner);

			rptrFlashcardList.DataSource = flashcards;
			rptrFlashcardList.DataBind();
		}



		[WebMethod]
		public static string DeleteFlashcard(int flashcardId)
		{
			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.DeleteFlashcard(flashcardId);


		}



		[WebMethod]
		public static string UpdateFlashcard(string jsonData)
		{
			var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);

			int id = Convert.ToInt32(data["id"]);
			string wtarget = data["wtarget"];
			string wsource = data["wsource"];
			string etarget = data["etarget"];
			string pron = data["pron"];
			string esource = data["esource"];
			string tips = data["tips"];
			string level = data["level"];

			FlashcardServices flashcardService = new FlashcardServices();
			return flashcardService.UpdateFlashcard(id, wtarget, wsource, etarget, pron, esource, tips, level);

		}




	}
}