using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class CreateWebForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

        protected void CreateBttn_Click(object sender, EventArgs e)
        {
            Response.Redirect("captcha.aspx");

        }
	public void WriteToXML(string username, string password)
 {
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
	
        



    }
}
