using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Abm_Afiliado
{
    public class Afiliado
    {
        private string nombre;
        private string apellido;
        private DateTime fechaNac;
        private string tipoDoc;
        private int numeroDoc;
        private string direccion;
        private int telefono;
        private string sexo;
        private string estadoCivil;
        private string plan;

        public Afiliado( string nombre,string apellido,DateTime fechaNac, string tipoDoc,string numeroDoc,string direccion,string telefono,string sexo,string estadoCivil,string plan) {

            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac;
            this.tipoDoc = tipoDoc;
            this.numeroDoc = int.Parse(numeroDoc);
            this.direccion = direccion;
            this.telefono = int.Parse(telefono);
            this.sexo = sexo;
            this.estadoCivil = estadoCivil;
            this.plan = plan;

        }

        public Afiliado() { }

        public string getNombre() {
            return this.nombre;
        }

        public string getApellido(){
            return this.apellido;
        }

        public string getTipoDoc(){
            return this.tipoDoc;
        }

        public int getNroDoc()
        {
            return this.numeroDoc;
        }

        public string getDireccion(){
            return this.direccion;
        }
        public int getTelefono(){
            return this.telefono;
        }
        public string getSexo(){
            return this.sexo;
        }

        public string getEstadoCivil(){
            return estadoCivil;
        }

        public string getPlan() {
            return plan;
        }


    }
}
