using System;
using Club67.Datos;

namespace Club67.Logica
{
    public class Inscripcion
    {
        // Atributos privados
        private int idInscripcion;
        private DateTime fechaInscripcion;
        private bool estadoInscripcion;

        public Inscripcion(int idInsc, DateTime fecha, bool estado)
        {
            this.IdInscripcion = idInsc;
            this.FechaInscripcion = fecha;
            this.EstadoInscripcion = estado;
        }

        // Propiedades públicas
        public int IdInscripcion
        {
            get { return idInscripcion; }
            set { idInscripcion = value; }
        }

        public DateTime FechaInscripcion
        {
            get { return fechaInscripcion; }
            set { fechaInscripcion = value; }
        }

        public bool EstadoInscripcion
        {
            get { return estadoInscripcion; }
            set { estadoInscripcion = value; }
        }

        public static int ProcesarAltaCliente(string dni, string nombre, string apellido, string telefono, string direccion, bool aptoFisico, string tipoCliente)
        {
            int nuevoId = Club.Instancia.ListaClientes.Count + 1;

            if (tipoCliente == "Socio")
            {
                Socio nuevoSocio = new Socio(nuevoId, nombre, apellido, dni, telefono, direccion, aptoFisico, nuevoId, true, DateTime.Now);
                Club.Instancia.ListaClientes.Add(nuevoSocio);


                ClienteDatos.Guardar(nuevoSocio);
            }
            else if (tipoCliente == "NoSocio")
            {
                NoSocio nuevoNoSocio = new NoSocio(nuevoId, nombre, apellido, dni, telefono, direccion, aptoFisico, nuevoId, true);
                Club.Instancia.ListaClientes.Add(nuevoNoSocio);
 
                ClienteDatos.Guardar(nuevoNoSocio);
            }

            return nuevoId;
        }
    }
}