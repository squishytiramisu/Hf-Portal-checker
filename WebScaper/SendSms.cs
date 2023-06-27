using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScaper
{
    using System;
    using System.Collections.Generic;
    using Twilio;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    class SendSms
    {
        public static void sendSMS(string to, string body)
        {
            //Register to twilio vagy használj valami más értesítést
            //Szerintem regisztrálj, pár perc csak es amugy is hasznos

            var accountSid = "";
            var authToken = "";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(to));
            messageOptions.From = new PhoneNumber("+13614281435");//Csak verifyed number lehet
            messageOptions.Body = body;


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);

        }
    }
}
