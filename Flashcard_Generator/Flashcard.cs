using System;

namespace Flashcard_Generator
{
	public class Flashcard
	{
		private int Id { get; }
		public User User { get; set; }
		public string SourceLanguage { get; set; }
		public string TargetLanguage { get; set; }
		public string Category { get; set; }
		public string WordSource { get; set; }
		public string WordTarget { get; set; }
		public string ExampleSentenceSource { get; set; }
		public string ExampleSentenceTarget { get; set; }
		public string Pronunciation { get; set; }
		public string Tips { get; set; }
		public string Proficiency { get; set; }
		public bool IsPublic { get; set; }
		private DateTime CreatedAt { get; }
		private DateTime UpdatedAt { get; }


		//to create the flashcards
		public Flashcard(
			User user,
			string sourceLanguage,
			string targetLanguage,
			string category,
			string wordSource,
			string wordTarget,
			string exampleSentenceSource,
			string exampleSentenceTarget,
			string pronunciation,
			string tips,
			string proficiency,
			bool isPublic)
		{
			User = user;
			SourceLanguage = sourceLanguage;
			TargetLanguage = targetLanguage;
			Category = category;
			WordSource = wordSource;
			WordTarget = wordTarget;
			ExampleSentenceSource = exampleSentenceSource;
			ExampleSentenceTarget = exampleSentenceTarget;
			Pronunciation = pronunciation;
			Tips = tips;
			Proficiency = proficiency;
			IsPublic = isPublic;
		}
	}
}
