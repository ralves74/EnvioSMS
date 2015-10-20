using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioSMS
{
    public class Licenca
    {
        static char[] barra ={' ','A','B','9','C','D','E','F','5','G','H','0','I','K','0','J','L','M','2','N','O','6','P','Q','R','1','S','T','8','U','V','7','W','X','Y','4','Z','3'};
        public static string Cifrar(string textoNaoCifrado)
        {
            string cifra = "";
            foreach(char c in textoNaoCifrado)
            { 
                 cifra += barra[ (Array.IndexOf( barra, c) + 15) % 27 ];
             }
            return cifra ;
        }
        public static string Decifrar(string textoCifrado)
        {
        string textoOriginal = "";
        foreach(char c in textoCifrado)
        {
        textoOriginal += barra[(Array.IndexOf(barra, c) - 15 + 27) % 27];
        }
        return textoOriginal;
        }
        }
    }
