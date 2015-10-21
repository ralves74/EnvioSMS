using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Plivo.API;
using RestSharp;

namespace EnvioSMS
{
    class Oper
    {
        RestAPI plivo_SMS = new RestAPI("MANZM1MMEZY2U4MMU5NT", "YTdmYzYwM2Y3NWY0OWJkZjE0ODA5NWZhNjIwYzZj");
        string envio (string arg0,string arg1,string arg2)
        {
            IRestResponse<MessageResponse> resp = plivo_SMS.send_message(new Dictionary<string, string>() 
                    {
                        { "src", arg0 }, // Sender's phone number with country code
                        { "dst", arg1 }, // Receiver's phone number wiht country code
                        { "text", arg2 }, // Your SMS text message
                        { "url", "http://dotnettest.apphb.com/delivery_report"}, // The URL to which with the status of the message is sent
                        { "method", "POST"} // Method to invoke the url
                    });
            string messageuuid = resp.Data.message_uuid[0];
            return messageuuid;

        }

        void messagereport(string messageuuid)
        { 
        IRestResponse<Message> relatorio = plivo_SMS.get_message(new Dictionary<string, string>() 
                        {
                        { "record_id", messageuuid } // Message UUID
                    });
        }


        void get_account_report()
        { 
            IRestResponse<Account> relatorio_account = plivo_SMS.get_account();
        }

    }
}
