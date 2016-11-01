using System;
namespace ClinicaFrba.Registrar_Agenda_Medico
{
    public class Horario
    {
        private int profesional_id;
        private int especialidad_id;
        private DateTime fechaHora;

        public Horario(int profesional_id, int especialidad_id, DateTime fechaHora) {
            this.profesional_id = profesional_id;
            this.especialidad_id = especialidad_id;
            this.fechaHora = fechaHora;
        }
    }
}
