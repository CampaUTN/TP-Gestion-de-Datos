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
        bool distinto;

        public string pasateAWhere(){
            string ret = "";
            if (exacto){
                if (Parser.esEntero(nombreColumna)){
                    ret = ret + nombreColumna + "=" + valorAComparar + " ";
                }
                else{
                    ret = ret + nombreColumna + "='" + valorAComparar + "' ";
                }
            }
            else{
                if (distinto){
                    ret = ret + nombreColumna + " <> " + valorAComparar + " ";

                }
                else{
                    ret = ret + nombreColumna + " LIKE '" + valorAComparar + "%'";
                }
            }
            return ret;
        }

       /* public Parametro(TextBox textbox, bool esExacta)
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
            
        }*/

        public static Parametro fromTextBox(TextBox textbox, bool esExacta)
        {
            Parametro parametro = new Parametro();

            if (textbox.Name == "espe_nombre")
            {
                parametro.nombreColumna = "e." + textbox.Name;
            }
            else
            {
                parametro.nombreColumna = textbox.Name;
            }
            parametro.valorAComparar = textbox.Text;
            parametro.exacto = esExacta;
            parametro.distinto = false;

            return parametro;
        }
        
        public static Parametro fromCheckBox(CheckBox checkBox)
        {
            Parametro parametro = new Parametro();

            parametro.nombreColumna = checkBox.Name;
            parametro.valorAComparar = " 0 ";
            parametro.exacto = false;
            parametro.distinto = true;
            
            return parametro;
        }


        public int getSize(){
            return valorAComparar.Length;
        }
    }
}
