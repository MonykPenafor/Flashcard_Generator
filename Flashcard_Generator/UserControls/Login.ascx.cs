using System;
using System.Web.Security;

namespace Flashcard_Generator
{
	public partial class Login1 : System.Web.UI.UserControl
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
				lblMessage.Text = "All fields are required!";
				return;
			}

			UserServices userServices = new UserServices();
			User user = new User(usernameOrEmail, password);
			
			string result = userServices.Login(user);

			if (result != "true")
			{
				lblMessage.Text = result;
			}
			else
			{
				FormsAuthentication.SetAuthCookie(usernameOrEmail, false);
				Response.Redirect("/WebForms/Home.aspx");
			}
		}



	}
}