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
            return esEntero(textbox.Text) && textbox.Text != "" ;        
        }

        public static bool esEntero(string texto){
            int a;
            return int.TryParse(texto, out a);
        }

        public static bool esEntero(char car){
            int a;
            string caracter = "" + car;
            return int.TryParse(caracter, out a);
        }


        public static bool tieneNumeros(TextBox textbox){
            return tieneNumeros(textbox.Text);
        }

        public static bool tieneNumeros(string texto){
            return texto.Any(caracter => esEntero(caracter));
        }

        public static bool estaVacio(TextBox textbox){
            return textbox.Text.Length.Equals(0);
        }

        /// <summary>
        /// Arma la consulta en SQL segun los parametros que recibe
        /// Dentro de Parametro deben incluirse TextBox como nombre de variable
        /// la columna que quiero consultar
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string armarConsulta(string tabla, params Parametro [] values)
        {
            int longitud = values.Length;

            //nombres de las columnas que quiero mostrar
            string parametros = "*";

            //condiciones de filtro
            string criterio = "";

            string tablaUsuarios= ",GEDDES.Usuarios" ;

            //string resultado sobre la cual se hace el SELECT
            string consulta;

            if (tabla == "Afiliados")
            {
                parametros = "afil_id AS ID, usua_apellido AS Apellido, usua_nombre AS Nombre, usua_nroDoc AS Documento ";
                criterio = "\n WHERE usua_id = afil_usuario AND ";
 
            }

            if (tabla == "Profesionales")
            {
                tabla = tabla + " p";
                parametros = "p.prof_id AS Id, usua_apellido AS Apellido, usua_nombre AS Nombre, e.espe_nombre as Especialidad ";
               tablaUsuarios = tablaUsuarios + ",GEDDES.EspecialidadXProfesional espe, GEDDES.Especialidades e";
               criterio = "\n WHERE usua_id = p.prof_usuario AND p.prof_id = espe.prof_id AND espe.espe_id = e.espe_id AND ";
            }

            foreach (Parametro parametro in values){
                    //si el campo esta vacio, lo omito
                //if (Parser.estaVacio(parametro)) ;
                    if (parametro != null && parametro.getSize() != 0){

                        criterio = criterio + parametro.pasateAWhere() + " AND ";
                    }
            }
            criterio = sacarAND(criterio);

            consulta = "SELECT " + parametros + " \nFROM GEDDES." + tabla + tablaUsuarios + criterio;

            return consulta;
        }


        public static string sacarAND(string cadena)
        {
           string aux= cadena.Substring(cadena.Length - 4, 4);

           if (aux.Contains("AND"))
           {
               return cadena.Substring(0, cadena.Length - 4);
           }else{
               return cadena;}
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
           log = "";
        }

        public string mostrarLog()
        {
            return log;
        }
    
    }
}
