using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Abm_Afiliado.Baja
{
    class BajaAfiliado
    {

        public BajaAfiliado()
        {
        }

        public void eliminarAfiliado(Afiliado afiliado){

            long idUsuario = afiliado.getUsuaId();

            Utilidades.Utils.darDeBajaAfiliado(idUsuario);


        }
    }
}
