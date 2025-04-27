using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Net.Http;

namespace WebApplication1
{
	public partial class MemeberPage : System.Web.UI.Page
	{
        public string url = "https://localhost:44339";

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
        protected void rcvButton_Click(object sender, EventArgs e)
        {
            string message = "";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = client.GetAsync("api/Message").Result;
                responseMessage.EnsureSuccessStatusCode();
                message = responseMessage.Content.ReadAsStringAsync().Result;
                rcvBox.Text = Regex.Unescape(message);
            }

            //return message;
        }

        protected void replaceButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(targetWord.Text) || !string.IsNullOrEmpty(replacementWord.Text))
            {
                string target = targetWord.Text;
                string replacement = replacementWord.Text;
                string message = "";
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    string request = $"/api/Message?target={Uri.EscapeDataString(target)}&replacementWord={Uri.EscapeDataString(replacement)}";
                    HttpResponseMessage responseMessage = client.PutAsync(request, null).Result;
                    responseMessage.EnsureSuccessStatusCode();
                    message = responseMessage.Content.ReadAsStringAsync().Result;
                    rcvBox.Text = "Success!";
                }
            }
        }

        protected void sendButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sendBox.Text))
            {
                var data = new
                {
                    Message = sendBox.Text,
                };
                string serializedData = JsonConvert.SerializeObject(data);
                StringContent json = new StringContent(serializedData, Encoding.UTF8, "application/json");



                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    HttpResponseMessage responseMessage = client.PostAsync("api/Message", json).Result;
                    responseMessage.EnsureSuccessStatusCode();
                    string message = responseMessage.Content.ReadAsStringAsync().Result;
                    rcvBox.Text = "Success!";
                }
            }
        }

        protected void clearButton_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = client.DeleteAsync("/api/Message").Result;
                responseMessage.EnsureSuccessStatusCode();
                rcvBox.Text = "Success!";
            }
        }
       
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInput.Text))
            {
                divResult.Visible = true;
                lblResult.Text = "Please enter some text to process.";
                return;
            }

            try
            {
                // Create web service reference
                TextReversal service = new TextReversal();
                string result = string.Empty;

                // Call the selected operation
                switch (ddlOperation.SelectedValue)
                {
                    case "ReverseText":
                        result = service.ReverseText(txtInput.Text);
                        break;
                    case "ReverseWords":
                        result = service.ReverseWords(txtInput.Text);
                        break;
                    case "ReverseWordOrder":
                        result = service.ReverseWordOrder(txtInput.Text);
                        break;
                    case "ReverseParagraphs":
                        result = service.ReverseParagraphs(txtInput.Text);
                        break;
                    case "CreatePalindrome":
                        result = service.CreatePalindrome(txtInput.Text);
                        break;
                    default:
                        result = "Invalid operation selected.";
                        break;
                }

                // Display the result
                divResult.Visible = true;
                lblResult.Text = Server.HtmlEncode(result);
            }
            catch (Exception ex)
            {
                divResult.Visible = true;
                lblResult.Text = "Error: " + ex.Message;
            }
        }
    }
}