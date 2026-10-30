using System;
using System.Collections.Generic;
using System.Text;

namespace Club67.Logica
{
    public class Socio : Cliente
    {
        // ATRIBUTOS PRIVADOS
        private int idSocio;
        private DateTime fechaVencimiento;
        private bool vigente;

        // CONSTRUCTOR DE SOCIO
        public Socio(int idCliente, string nombre, string apellido, string dni, string telefono, string direccion, bool aptoFisico, int idSocio, bool vigente, DateTime fechaInscripcion)
            : base(idCliente, nombre, apellido, dni, telefono, direccion, aptoFisico)
        {
            this.fechaVencimiento = fechaInscripcion.AddMonths(1);
            this.idSocio = idSocio;
            this.vigente = vigente;
        }

        // PROPIEDADES PÚBLICAS (GET Y SET)
        public int IdSocio
        {
            get { return idSocio; }
            set { idSocio = value; }
        }

        public bool Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }
        public bool VenceHoy()
        {
            if (this.fechaVencimiento == DateTime.Today)
            {
                return true;  
            }
            else
            {
                return false; 
            }
        }
        public bool RegistrarPagoMensual()
        {
            this.Vigente = true;
            this.ActualizarVencimiento(30);

            return true;
        }


        public void ActualizarVencimiento(int dias)
        {
            this.FechaVencimiento = DateTime.Now.AddDays(dias);
        }
        public void ActualizarEstado()
        {
            if (this.VenceHoy())
            {
                this.Vigente = false; 
            }
            else
            {
                this.Vigente = true; 
            }
        }
    }
}