using System;

namespace Flashcard_Generator
{
	public class Flashcard
	{
		private int Id { get;}
		private User User { get; set; }
		private string source_language { get; set; }
		private string target_language { get; set; }
		private string category { get; set; }
		private string word_source { get; set; }
		private string word_target { get; set;}
		private string example_sentence_source { get; set; }
		private string example_sentence_target { get;set; }
		private string pronunciation { get; set; }
		private string tips { get; set; }
		private string proficiency { get; set; }
		private bool is_public { get; set; }
		private DateTime created_at { get;}
		private DateTime updated_at { get;}















	}
}