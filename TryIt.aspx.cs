using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class TryIt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string path = Path.Combine(Server.MapPath("~/App_Data/"), filename);
                    if (!Directory.Exists(Server.MapPath("~/App_Data/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/App_Data/"));
                    }
                    FileUpload1.SaveAs(path);
                    Label1.Text = "File uploaded successfully!";
                    Session["filepath"] = path;
                    Label1.Text = filename;
                }
                catch (Exception ex)
                {
                    Label1.Text = "The following error occurred: " + ex.Message;
                }
            }
            else
            {
                Label1.Text = "No File";
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["filepath"] != null)
                {
                    string name = Session["filepath"].ToString();
                    ServiceReference1.Service1Client prxy = new ServiceReference1.Service1Client();
                    string text = prxy.wordCount(name);
                    Label2.Text = text;
                }
                else
                {
                    Label2.Text = "null";
                }

            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }


        }
    }
  }