using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioSMS
{
    class LicencaXml
    {
        private string cliente;
        private string lic;

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public string Lic
        {
            get { return lic; }
            set { lic = value; }
        }
    }
}
