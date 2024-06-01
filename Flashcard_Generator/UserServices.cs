using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace Flashcard_Generator
{
	public class UserServices
	{

		private readonly string connectionString;

		public UserServices()
		{
			connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;
		}



		public string SignUp(User user)
		{
			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				string query = "INSERT INTO Users (Username, Email, Password_hash) VALUES (@Username, @Email, @Password);";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@Username", user.Username);
					cmd.Parameters.AddWithValue("@Email", user.Email);
					cmd.Parameters.AddWithValue("@Password", hashedPassword);

					try
					{
						var result = cmd.ExecuteNonQuery();
						return "true";
						
					}
					catch (SqlException ex)
					{
						if (ex.Number == 2627)
						{
							return "Username or Email already registered!";
						}
						else
						{
							return $"Failed to register: {ex.Message}";
						}
					}
					catch (Exception ex)
					{
						return $"Failed to register!: {ex}";
					}
				}
			}
		}



		public string Login(User user)
		{
			string usernameOrEmail;

			if (string.IsNullOrEmpty(user.Username))
			{
				usernameOrEmail = user.Email;
			}
			else
			{
				usernameOrEmail = user.Username;
			}

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				string query = "SELECT Password_hash FROM Users WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@UsernameOrEmail", usernameOrEmail);

					object result = cmd.ExecuteScalar();
					if (result != null)
					{
						string hashedPassword = result.ToString();
						bool isPasswordValid = BCrypt.Net.BCrypt.Verify(user.Password, hashedPassword);

						if (isPasswordValid)
						{
							// Get user information from database
							User fullUserInfo = GetUserByUsernameOrEmail(user.Username ?? user.Email); // if Username not null, use Username, otherwise use Email

							// Store user information in session
							HttpContext.Current.Session["LoggedInUser"] = fullUserInfo;

							return "true";
						}
						else
						{
							return "Invalid Username or Password!";
						}
					}
					else
					{
						return "Invalid Username or Password!";
					}
				}
			}
		}



		public User GetUserByUsernameOrEmail(string usernameOrEmail)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				string query = "SELECT Id_user, Username, Email, Created_At, Updated_At FROM Users WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";

				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@UsernameOrEmail", usernameOrEmail);

					using (SqlDataReader reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							return new User(
								Convert.ToInt32(reader["Id_user"]),
								reader["Username"].ToString(),
								reader["Email"].ToString(),
								Convert.ToDateTime(reader["Created_At"]),
								Convert.ToDateTime(reader["Updated_At"])
							);
						}
					}
				}
			}

			return null; // User not found
		}


	}
}