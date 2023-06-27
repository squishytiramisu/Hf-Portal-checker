using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Mail;
using System.Net;

namespace WebShit
{
    internal class EmailVacak
    {



        public static void SendNotify(string _username, string _password, string _from, string _to, string message="")
        {
            string from = _from;
            string to = _to;
            string subject = "EREDMENY: "+message;
            string body = "Vacak: ZRM2F SÁRGA KÖNTÖSE";

            string username = _username; 
            string password = _password;

            string host = "sylintstudio@gmail.com";
            int port = 587;

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            client.Send(from, to, subject, body);

            Console.WriteLine("Email sent");


        }
    }
}
