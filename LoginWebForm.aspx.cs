using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myLib;
namespace WebApplication1
{
	public partial class LoginWebForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void CreateAccount_Click(object sender, EventArgs e)
        {
			//implement captcha here 
			Response.Redirect("CreateWebForm.aspx");
        }

        protected void LoginBttn_Click(object sender, EventArgs e)
        {
            string psswrd = PasswordTxtBx.Text;
            string encrypt;
            string decrypt;



            using (SymmetricAlgorithm des = DES.Create())
            {
                des.GenerateKey();
                des.GenerateIV();

                encrypt = Class1.EncryptString(psswrd, des.Key, des.IV);
                decrypt = Class1.DecryptString(encrypt, des.Key, des.IV);
            }
            Label1.Text = encrypt;
            Label2.Text = decrypt;
        }
    }
}