using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Flashcard_Generator
{
	public partial class SignUp : Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{

		}



		//SIGN UP 
		protected void btnSignUp_Click(object sender, EventArgs e)
		{


			string username = txtUsername.Text;
			string email = txtEmail.Text;
			string password = txtPassword.Text;


			// checking fields are not null/empty
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				lblMessage.Text = "All fields are required!";
				return;
			}


			// Hashing the password
			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);


			string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				con.Open();
				string query = "INSERT INTO Users (Username, Email, Password_hash) VALUES (@Username, @Email, @Password)";
				using (SqlCommand cmd = new SqlCommand(query, con))
				{
					cmd.Parameters.AddWithValue("@Username", username);
					cmd.Parameters.AddWithValue("@Email", email);
					//cmd.Parameters.AddWithValue("@Password", password);
					cmd.Parameters.AddWithValue("@Password", hashedPassword); // Note the use of the hashed password


					try
					{
						cmd.ExecuteNonQuery();
						lblMessage.Text = "User registered successfully!";
						Response.Redirect("FlashcardGenerator.aspx");
					}
					catch (SqlException ex)
					{
						// Check if the error is a violation of unique constraint
						if (ex.Number == 2627) // Unique constraint error number
						{
							lblMessage.Text = "Username or Email Already registered!";
						}
						else
						{

							lblMessage.Text = $"Failed to register!: {ex}";
						}
					}
					catch (Exception ex)
					{

						lblMessage.Text = $"Failed to register!: {ex}";
					}
				}
			}

		}

	}
}