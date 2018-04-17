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
    public class EMailController : ApiController
    {
        // GET: api/EMail
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EMail/5
        public string Get(string id)
        {
            return "value";
        }

        // POST: api/
        [EnableCors(origins: "http://jemmllc.com", headers: "*", methods: "*")]
        public void Post([FromBody]RequestObject value)
        {
            var to = value.to == null ? "info@jemmtechnologies.com" : value.to;
            var from = value.from == null ? "info@jemmtechnologies.com" : value.from;
            MailMessage mail = new MailMessage("info@jemmtechnologies.com", to);
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            mail.IsBodyHtml = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("info@jemmtechnologies.com", "Sendagain12.");
            client.Host = "smtp.office365.com";
            var subject = value.subject;
            if (value.to == null)
                subject = "JEMMLLC Email: " + subject;
            mail.Subject = subject;
            var message = value.message;
            if (value.to == null)
                message = "From: " + value.name + Environment.NewLine + "Email: " + value.email + Environment.NewLine + Environment.NewLine + message;
            mail.Body = message;
            client.Send(mail);
            //lyn@greenegablesinn.com
            //Coyowen1
            //replyto info
        }

        // PUT: api/EMail/5
        public void Put(int id, [FromBody]RequestObject value)
        {
        }

        // DELETE: api/EMail/5
        public void Delete(int id)
        {
        }

        
    }
}
