using System;

namespace Club67.Logica
{
    // También hereda de Cliente
    public class NoSocio : Cliente
    {
        // Atributo propio para identificarlo como no socio
        private int idNoSocio;
        private bool vigente;
        public NoSocio(int idCliente, string nombre, string apellido, string dni, string telefono, string direccion, bool aptoFisico, int idNoSocio, bool vigente)
                    : base(idCliente, nombre, apellido, dni, telefono, direccion, aptoFisico)
        { 
            this.idNoSocio = idNoSocio;
            this.vigente = vigente;
        }

        // Propiedades públicas
        public int IdNoSocio
        {
            get { return idNoSocio; }
            set { idNoSocio = value; }
        }

        public bool Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }
        public bool RegistrarPagoActividad()
        {
            return true;
        }
    }
}