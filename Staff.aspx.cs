using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myLib;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace WebApplication1
{
	public partial class Staff : System.Web.UI.Page
	{
        private string location = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\doc.xml");
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
		{
            string directory = Path.GetDirectoryName(location);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
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

                Response.Redirect("StaffPage.aspx"); //default page redirection needed
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBx.Text;
            string password = PasswordTxtBx.Text;

           

            WriteToXML(username, password);
            UsernameTxtBx.Text = "";
            PasswordTxtBx.Text = "";

        }
        public void WriteToXML(string username, string password)
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
                        // Handle potential deserialization errors (e.g., empty file)
                        Console.WriteLine($"Error deserializing XML: {ex.Message}");
                        allUsers = new List<User>(); // Start with an empty list if there's an error
                    }
                }

            }
                user.UserName = username;


                using (SymmetricAlgorithm des = DES.Create())
                {
                    des.GenerateKey();
                    des.GenerateIV();
                    user.IV = des.IV;
                    user.Key = des.Key; 

                    password = Class1.EncryptString(password, des.Key, des.IV);
                    user.PassWord = password;
                    allUsers.Add(user);

                }
                
                XmlSerializer seralizer = new XmlSerializer(typeof(List<User>));
                using (FileStream fileStream = new FileStream(location, FileMode.Create))
                {
                    seralizer.Serialize(fileStream, allUsers);
                }


            }
        }


    public class User
    {
        string userName;
        string passWord;
        byte[] iv;
        byte[] key;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public byte[] IV
        {
            get { return iv; }
            set { iv = value; }
        }

        public byte[] Key
        {
            get { return key; }
            set { key = value; }
        }
    }
}
