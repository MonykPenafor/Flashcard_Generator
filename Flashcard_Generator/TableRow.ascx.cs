﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Flashcard_Generator
{
	public partial class TableRow : System.Web.UI.UserControl
	{
		public Flashcard FlashcardTableRow { get; set; }

		FlashcardServices flashcardServices = new FlashcardServices();


		protected void Page_Load(object sender, EventArgs e)
		{
		}


	}
}