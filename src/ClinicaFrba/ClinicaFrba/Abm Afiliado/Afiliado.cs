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
            this.fechaNac = fechaNac.Date;
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
            return nombre;
        }

        public string getApellido(){
            return apellido;
        }

        public string getTipoDoc(){
            return tipoDoc;
        }

        public int getNroDoc(){
            return numeroDoc;
        }

        public string getDireccion(){
            return direccion;
        }
        public int getTelefono(){
            return telefono;
        }
        public string getSexo(){
            return sexo;
        }

        public string getEstadoCivil(){
            return estadoCivil;
        }

        public string getPlan() {
            return plan;
        }

        public DateTime getFechaNac(){
            return fechaNac;
        }
    }
}
