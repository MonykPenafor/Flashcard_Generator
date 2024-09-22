using System;

namespace Flashcard_Generator
{
	public partial class SignUp1 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}


		protected void btnSignUp_Click(object sender, EventArgs e)
		{
			string username = txtUsername.Text;
			string email = txtEmail.Text;
			string password = txtPassword.Text;

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				lblMessage.Text = "All fields are required!";
				return;
			}

			if (username.Contains("@")) 
			{
				lblMessage.Text = "Username can not contain '@'!";
				return;
			}

			if (!email.Contains("@"))
			{
				lblMessage.Text = "Write a valid E-mail!";
				return;
			}

			UserServices userServices = new UserServices();
			User user = new User(username, email, password);

			string result = userServices.SignUp(user);

			if (result != "true")
			{
				lblMessage.Text = result;
			}
			else
			{
				Response.Redirect("/WebForms/Home.aspx");
			}
		}
	}
}