﻿using System;

namespace Flashcard_Generator
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime CreatedAt { get; }
		public DateTime UpdatedAt { get; }


		//for signup method
		public User(string username, string email, string password)
		{
			Username = username;
			Email = email;
			Password = password;
		}

		//for login method
		public User(string usernameOrEmail, string password)
		{
			if (usernameOrEmail.Contains("@"))
			{
				Email = usernameOrEmail;
			}
			else
			{
				Username = usernameOrEmail;
			}
			Password = password;
		}

		//to create the session.user
		public User(int id, string username, string email, DateTime createdAt, DateTime updatedAt)
		{
			Id = id;
			Username = username;
			Email = email;
			CreatedAt = createdAt;
			UpdatedAt = updatedAt;
		}
	}
}