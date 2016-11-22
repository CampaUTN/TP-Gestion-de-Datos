using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Utilidades
{
    class Parametro
    {
        string nombreColumna;
        string valorAComparar;
        bool exacto;

        public string pasateAWhere()
        {
            string ret = "";
            if (exacto)
            {
                if (Parser.esEntero(nombreColumna))
                {
                    ret = ret + nombreColumna + "=" + valorAComparar + " ";
                }
                else
                {
                    ret = ret + nombreColumna + "='" + valorAComparar + "' ";
                }
            }
            else
            {
                ret = ret + nombreColumna + " LIKE '%" + valorAComparar + "%'";
            }

            return ret;
        }

        public Parametro(TextBox textbox, bool esExacta)
        {
            if (textbox.Name == "espe_nombre")
            {
                this.nombreColumna = "e." + textbox.Name;
            }
            else{
                this.nombreColumna = textbox.Name;
            }
            this.valorAComparar = textbox.Text;
            this.exacto = esExacta;
            
        }

        public int getSize(){
            return valorAComparar.Length;
        }
    }
}
