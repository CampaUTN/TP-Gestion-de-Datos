using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Utilidades
{
    class Parser
    {
        public static bool esEntero(TextBox textbox) {
            return esEntero(textbox.Text);        
        }

        public static bool esEntero(string texto){
            int a;
            return int.TryParse(texto, out a);
        }

        public static bool esEntero(char car)
        {
            int a;
            string caracter = "" + car;
            return int.TryParse(caracter, out a);
        }


        public static bool tieneNumeros(TextBox textbox)
        {
            return tieneNumeros(textbox.Text);
        }

        public static bool tieneNumeros(string texto)
        {
            int a;
            return texto.Any(caracter => esEntero(caracter));
        }

    }


    public class Logger { 
    
        private string log;

        public Logger()
        {
            this.log = "";
            
        }        

        public void agregarAlLog(string detalle)
        {
            this.log += "- " + detalle + "\n";
        }

        public bool huboErrores()
        {
            return log.Length > 0;
        }

        public void resetear()
        {
            this.log = "";
        }

        public string mostrarLog()
        {
            return log;
        }
    
    }
}
