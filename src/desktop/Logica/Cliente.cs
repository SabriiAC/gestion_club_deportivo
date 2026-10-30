using System;

namespace Club67.Logica
{
    public class Cliente
    {
        // ATRIBUTOS PRIVADOS (Lo que sabe el Cliente)
        private int idCliente;
        private string nombre;
        private string apellido;
        private string dni;
        private string telefono;
        private string direccion;
        private bool aptoFisico;

        public Cliente(int idCliente, string nombre, string apellido, string dni, string telefono, string direccion, bool aptoFisico)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.AptoFisico = aptoFisico;
        }

        //  PROPIEDADES PÚBLICAS
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public bool AptoFisico
        {
            get { return aptoFisico; }
            set { aptoFisico = value; }
        }
    }
}