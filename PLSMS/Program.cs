/*
* Desenvolvimento de Software de envio de SMS utiliando serviço Plivo
 * by Rui Alves 
 * Console Aplication
 * Rest API fom Plivo
 * RestShap v. 105.1
 * Data de Criação : 14/10/2015
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Plivo.API;
using RestSharp;

namespace ENVIOSMS
{
    class Program
    {
        /// <summary>
        /// Envio de SMS via Serviço Plivo
        /// </summary>
        /// <param name="args">To,From,Message</param>
        static void Main(string[] args)
        {

            //EnvioSMS.Licenciamento vlicenca = new EnvioSMS.Licenciamento();
            //bool estadoLicenca = vlicenca.Verifica_Licenca();
            //if (!estadoLicenca)
            //{
            //    Console.WriteLine("Verifique Licenciamento");
            //    Console.ReadLine();
            //}
            //else
            //{
                if (args.Length > 0)
                {
                    RestAPI plivo_SMS = new RestAPI("MANZM1MMEZY2U4MMU5NT", "YTdmYzYwM2Y3NWY0OWJkZjE0ODA5NWZhNjIwYzZj");
                    //RestAPI plivo_SMS = new RestAPI("MAOTNIYZY0MTA0YWM3NJ", "NmY0MzRhY2I2NDkyYjMzNTUyMjEyYTFhZDJhNDFh");


                    /*
                    * Envio de SMS
                    */
                    IRestResponse<MessageResponse> resp = plivo_SMS.send_message(new Dictionary<string, string>() 
                    {
                        { "src", args[0] }, // Sender's phone number with country code
                        { "dst", args[1] }, // Receiver's phone number wiht country code
                        { "text", args[2] }, // Your SMS text message
                        { "url", "http://dotnettest.apphb.com/delivery_report"}, // The URL to which with the status of the message is sent
                        { "method", "POST"} // Method to invoke the url
                    });
                    string messageuuid = resp.Data.message_uuid[0];
                    /*
                     * Pedido de informações de mensagem enviada
                     */
                    IRestResponse<Message> relatorio = plivo_SMS.get_message(new Dictionary<string, string>() 
                        {
                        { "record_id", messageuuid } // Message UUID
                    });

                    /*
                    * Pedido de informações de dados de conta, para saber saldo 
                    */
                    IRestResponse<Account> relatorio_account = plivo_SMS.get_account();
                    /*
                    * Impressão de relatório
                    */
                    Console.WriteLine();
                    Console.WriteLine("message_uuid : {0}", messageuuid);
                    Console.WriteLine("Status : {0} ", relatorio.Data.message_state);
                    Console.WriteLine("Total amount : {0} ", relatorio.Data.total_amount);
                    Console.WriteLine("Total rate : {0} ", relatorio.Data.total_rate);
                    Console.WriteLine("Saldo Disponivel : {0}",relatorio_account.Data.cash_credits);
                    Console.ReadLine();

                    
                //}
                //else
                //{
                //    Console.WriteLine("Falta de Argumentos, destinatario e Mensagem");
                //    Console.WriteLine("Prima Enter Para Sair");
                //    Console.ReadLine();
                //}
                
                }
        }
    }
}
