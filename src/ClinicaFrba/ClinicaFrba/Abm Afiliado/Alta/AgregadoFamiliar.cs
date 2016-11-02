using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Abm_Afiliado
{
    class AgregadoFamiliar :Alta
    {
        private int afiliadoRaiz;

        public AgregadoFamiliar(int afiliadoRaiz): base()
        {
            this.afiliadoRaiz = afiliadoRaiz;
            this.Text = "Alta - Afiliacion de Familiar";
        }


        public override void realizarOperacion()
        {
            this.cargarUsuario();
            this.afiliado.setCodigo(afiliadoRaiz);
            this.afiliado.setAfiliadoRaiz(false);
            //calcular el nuevo id
            new AltaUsuario(this.afiliado).Show();
            
        }
    }
}
