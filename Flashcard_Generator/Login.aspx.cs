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
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			string usernameOrEmail = txtUser.Text;
			string password = txtPassword.Text;

			if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
			{
				lblMessage.Text = "Username/Email and Password are required!";
				return;
			}

			string connectionString = ConfigurationManager.ConnectionStrings["FlashCardsDB"].ConnectionString;

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
						string storedHash = result.ToString();
						bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, storedHash);

						if (isPasswordValid)
						{
							lblMessage.Text = "Login successful!";
							Response.Redirect("FlashcardGenerator.aspx");
						}
						else
						{
							lblMessage.Text = "Invalid Username or Password!";
						}
					}
					else
					{
						lblMessage.Text = "Invalid Username or Password!";
					}
				}
			}
		}
	}
}