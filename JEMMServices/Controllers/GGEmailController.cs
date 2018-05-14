using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net.Mail;

namespace JEMMServices.Controllers
{
    public class GGEmailController : ApiController
    {
        // GET: api/GGEmail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GGEmail/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GGEmail
        [EnableCors(origins: "http://jemmllc.com", headers: "*", methods: "*")]
        public void Post([FromBody]RequestObject value)
        {
            var to = value.to == null ? "info@jemmtechnologies.com" : value.to;
            var from = value.from == null ? "info@jemmtechnologies.com" : value.from;
            MailMessage mail = new MailMessage("info@greenegablesinn.com", to);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            mail.IsBodyHtml = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("lyn@greenegablesinn.com", "@Joemattcoy1");
            client.Host = "smtp.office365.com";
            var subject = value.subject;
            if (value.to == null)
                subject = "JEMMLLC Email: " + subject;
            mail.Subject = subject;
            mail.ReplyToList.Add("info@greenegablesinn.com");
            var message = value.message;
            if (value.to == null)
                message = "From: " + value.name + Environment.NewLine + "Email: " + value.email + Environment.NewLine + Environment.NewLine + message;
            mail.Body = message;
            client.Send(mail);
            //lyn@greenegablesinn.com
            //Coyowen1
            //replyto info
        }

        // PUT: api/GGEmail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GGEmail/5
        public void Delete(int id)
        {
        }
    }
}
