using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using System.Xml;



namespace EnvioSMS
{
    public class Licenciamento
    {
        public bool Verifica_Licenca()
        {
            LicencaXml datalicence = Carrega_licenca();  
            string clicifra = Licenca.Cifrar(datalicence.Cliente);

            if (datalicence.Lic == "")
            {
                return false;
            }
            if (datalicence.Lic != clicifra)
            { return false; }
            else
            { return true; }
        }

       

        private LicencaXml Carrega_licenca()
        {
            LicencaXml dadoslicenca = new LicencaXml();
            XmlTextReader reader = new XmlTextReader("Lic.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Lic.xml");
            //Pegando elemento pelo nome da TAG
            XmlNodeList xnList = xmlDoc.GetElementsByTagName("Lic");
            //Usando foreach para imprimir na tela
            foreach (XmlNode xn in xnList)
            {
                dadoslicenca.Lic = xn["licenca"].InnerText;
                dadoslicenca.Cliente = xn["Cliente"].InnerText;
            }
            return dadoslicenca;
        }

    }
}
