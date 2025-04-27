using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class captcha : System.Web.UI.Page
	{


		protected void Page_Load(object sender, EventArgs e)
		{

            if (!Page.IsPostBack){
                Label1.Text = RandomString();
            }
        }



        string RandomString()
        {
            string random = "";
            int r;
            char letter;
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                r = rand.Next(0, 26);
                letter = Convert.ToChar(r + 65);
                random = random + letter;
            }

            return random;
        }

        protected void EntrBttn_Click(object sender, EventArgs e)
        {
            string userTxt = TextBox1.Text;
            string myString = Label1.Text;

            if(userTxt.Equals(myString))
            {
                Response.Redirect("LoginWebForm.aspx");
            }
            else
            {
                Label1.Text = RandomString();
            }
        }
    }
}