using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using myLib;
namespace WebApplication1
{
	public partial class LoginWebForm : System.Web.UI.Page
	{
        private string location = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Users.xml");

        protected void Page_Load(object sender, EventArgs e)
		{
            string directory = Path.GetDirectoryName(location);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
			//implement captcha here 
			Response.Redirect("CreateWebForm.aspx");
        }

        protected void LoginBttn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBx.Text;
            string password = PasswordTxtBx.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Label1.Text = "Enter both username and password";
                Label1.Visible = true;
                return;
            }
            if (VerifyUser(username, password))
            {
                Session["LoggedIn"] = true;
                Session["Username"] = username;

                Response.Redirect("MemeberPage.aspx"); //default page redirection needed
            }
            else
            {
                Label1.Text = "Username and/or password are incorrect";
                Label1.Visible = true;
            }
        }
        private bool VerifyUser(string username, string password)
        {
            List<User> allUsers = new List<User>();

            if (File.Exists(location))
            {
                XmlSerializer des = new XmlSerializer(typeof(List<User>));
                using (FileStream fileStream = new FileStream(location, FileMode.Open))
                {
                    try
                    {
                        allUsers = (List<User>)des.Deserialize(fileStream);
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "Error reading user data";
                        Label1.Visible = true;
                        return false;
                    }
                }
                User foundUser = allUsers.FirstOrDefault(u => u.UserName == username);

                if (foundUser != null)
                {

                    try
                    {
                        string decryptedPassword = Class1.DecryptString(foundUser.PassWord, foundUser.Key, foundUser.IV);
                        return decryptedPassword == password;
                    }
                    catch (Exception ex)
                    {
                        Label1.Text = "Error verifying password";
                        Label1.Visible = true;
                        return false;
                    }
                }
            }

            return false;
        }
    }
   
}