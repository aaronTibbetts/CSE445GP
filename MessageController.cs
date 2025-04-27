using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;


namespace WebApplication1.Controllers
{
    [RoutePrefix("api/message")]
    public class MessageController : ApiController
    {
        private static string initialMessage = "This is the initial message";
        static string fileName = "input.txt";
        string dir = @"\\webstrar.fulton.asu.edu\website141";
        bool newFile = true;

        // GET: Message
        [HttpGet]
        public string GetMessage()
        {
            string message = "";
            using (StreamReader sw = new StreamReader(Path.Combine(dir, fileName), true)) //append message to file
            {
                message = @sw.ReadToEnd();
            }
            return message;
        }

        [HttpPut]
        public IHttpActionResult ReplaceMessage(string target, string replacementWord)
        {
            string modified = GetMessage().Replace(target, replacementWord);
            using (StreamWriter sw = new StreamWriter(Path.Combine(dir, fileName), false))
            {
                sw.WriteLine(modified);
            }
                return Ok(modified);
        }

        [HttpPost]
        public  async Task<IHttpActionResult> WriteMessage([FromBody]UserMessage msg)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(dir, fileName), true))
            {
                await sw.WriteLineAsync(msg.Message);
            }

            return Ok("Message written");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> ClearFile()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(dir, fileName), false))
            {
                await sw.WriteAsync("");
            }

            return Ok("File cleared!");
        }
    }

    public class UserMessage
    {
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
