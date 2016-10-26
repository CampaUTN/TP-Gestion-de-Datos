using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Abm_Afiliado
{
    class Afiliado
    {
        private string nombre;
        private string apellido;
        private string tipoDoc;
        private int numeroDoc;
        private string direccion;
        private string telefono;
        private string sexo;
        private string estadoCivil;
        private string plan;

        public Afiliado( string nombre,string apellido,string tipoDoc,int numeroDoc,string direccion,string telefono,string sexo,string estadoCivil,string plan) {

            this.nombre = nombre;
            this.apellido = apellido;
            this.tipoDoc = tipoDoc;
            this.numeroDoc = numeroDoc;
            this.direccion = direccion;
            this.telefono = telefono;
            this.sexo = sexo;
            this.estadoCivil = estadoCivil;
            this.plan = plan;

        }
    }
}
