using System;

namespace Flashcard_Generator
{
	public class Flashcard
	{
		public int Id { get; set; }
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
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }


		//to insert the flashcards into the database
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



		//to get the flashcards from the database
		public Flashcard(
			int id,
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
			bool isPublic
			//DateTime createdAt,
			//DateTime updatedAt
		)
		{
			Id = id;
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
			//CreatedAt = createdAt;
			//UpdatedAt = updatedAt;
		}

	}
}
