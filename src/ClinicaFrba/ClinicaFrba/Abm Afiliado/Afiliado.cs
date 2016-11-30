using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace ClinicaFrba.Abm_Afiliado
{
    public class Afiliado
    {
        private int idAfiliadoRaiz = 0;
        private bool afiliadoRaiz = true;
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

        //datos del afiliado como usuario
        private long usua_id;
        private string username;
        private string password;
        private string mail;
        private int hijosACargo = 0;


        public Afiliado( string nombre,string apellido,DateTime fechaNac, string tipoDoc,string numeroDoc,string direccion,string telefono,string sexo,string estadoCivil,string plan) {

            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNac = fechaNac.Date;
            this.tipoDoc = tipoDoc;
            this.direccion = direccion;
            try {
                this.numeroDoc = int.Parse(numeroDoc);
            } catch (FormatException) {
                this.numeroDoc = -1;
            }
            try {
                this.telefono = int.Parse(telefono);
            } catch (FormatException) {
                this.telefono = -1;
            }

            this.sexo = sexo;
            this.estadoCivil = estadoCivil;
            this.plan = plan;

        }

        #region GETTERS
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

        public string getUsername(){
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public string getMail() {
            return mail;
        }

        public int getHijosACargo()
        {
            return hijosACargo;
        }

        public void setAfiliadoRaiz(bool valor)
        {
            this.afiliadoRaiz = valor;
        }

        public int getCodigoAfiliado()
        {
            return idAfiliadoRaiz;
        }


        public long getUsuaId()
        {
            return usua_id;
        }

        #endregion

        #region SETTERS
        public void setUsername(string username){
            this.username = username;
        }

        public void setPassword(string password){
            this.password = password;
        }

        public void setDireccion(string direccion)
        {
            this.direccion = direccion;
        }

        public void setTelefono(int telefono)
        {
            this.telefono = telefono;
        }

        public void setMail(string mail){
            this.mail = mail;
        }

        public void setHijosACargo(int cant) {
            this.hijosACargo = cant;
        }

        public void setEstadoCivil(string estado)
        {
            this.estadoCivil = estado;
        }

        public void setCodigo(int cod)
        {
            this.idAfiliadoRaiz = cod;
        }

        public bool esAfiliadoRaiz() {
            return this.afiliadoRaiz;
        }

        public void setUsuaId(long usua_id)
        {
            this.usua_id = usua_id;
        }

        public void setPlan(string plan) {
            this.plan = plan;
        }

        #endregion

        #region METODOS AUXILIARES

        public bool puedeAfiliarAOtros()
        {
            return (estadoCivil.Equals("Concubinato") || estadoCivil.Equals("Casado/a")) || (hijosACargo > 0) && esAfiliadoRaiz();
        }
        #endregion

    }
}
