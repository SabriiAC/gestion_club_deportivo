using System;
using System.Collections.Generic;
using Club67.Datos;

namespace Club67.Logica
{
    public class Club
    {
        // Constantes de negocio
        public const float ValorCuotaMensual = 18000f;

        // Atributos privados 
        private string nombre;
        private List<Cliente> listaClientes;
        private List<Actividad> listaActividades;
        private List<Profesor> listaProfesores;
        private List<Pago> listaPagos;

        // Singleton
        private static Club instancia;
        public static Club Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Club("Club 67");
                }
                return instancia;
            }
        }

        // Constructor
        public Club(string nombre)
        {
            this.nombre = nombre;
            this.listaClientes = new List<Cliente>();
            this.listaActividades = new List<Actividad>();
            this.listaProfesores = new List<Profesor>();
            this.listaPagos = new List<Pago>();
        }

        // Propiedades públicas 
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public List<Cliente> ListaClientes
        {
            get { return listaClientes; }
            set { listaClientes = value; }
        }

        public List<Actividad> ListaActividades
        {
            get { return listaActividades; }
            set { listaActividades = value; }
        }

        public List<Profesor> ListaProfesores
        {
            get { return listaProfesores; }
            set { listaProfesores = value; }
        }

        public List<Pago> ListaPagos
        {
            get { return listaPagos; }
            set { listaPagos = value; }
        }

        //  Sincronización desde MySQL 
        public void SincronizarBaseDatos()
        {
            ListaClientes.Clear();
            List<Cliente> clientesDb = ClienteDatos.ObtenerTodos();
            ListaClientes.AddRange(clientesDb);

            ListaProfesores.Clear();
            List<Profesor> profesoresDb = ProfesorDatos.ObtenerTodos();
            ListaProfesores.AddRange(profesoresDb);
        }

        // Procesamiento de cobro de cuota o actividad
        public bool ProcesarTransaccion(string dni, float monto, string medioPago)
        {            
            Cliente clienteActual = this.listaClientes.Find(c => c.Dni == dni);
            if (clienteActual == null) return false;

            string idPagoNuevo = "PAGO - " + (this.listaPagos.Count + 1);
            DateTime fechaHoy = DateTime.Now;

            if (clienteActual is Socio elSocio)
            {
                // Actualiza el estado del socio 
                elSocio.RegistrarPagoMensual();

                ClienteDatos.Actualizar(elSocio);

                PagoMensual nuevoPagoMensual = new PagoMensual(idPagoNuevo, monto, fechaHoy, medioPago, elSocio.FechaVencimiento);
                this.listaPagos.Add(nuevoPagoMensual);

                PagoDatos.Guardar(nuevoPagoMensual, dni);
            }
            else if (clienteActual is NoSocio elNoSocio)
            {
                elNoSocio.RegistrarPagoActividad();

                PagoActividad nuevoPagoActividad = new PagoActividad(idPagoNuevo, monto, fechaHoy, medioPago);
                this.listaPagos.Add(nuevoPagoActividad);

                PagoDatos.Guardar(nuevoPagoActividad, dni);
            }

            return true;
        }

        public void RegistrarNuevoProfesor(Profesor nuevoProfe)
        {
            ProfesorDatos.Guardar(nuevoProfe);

            this.listaProfesores.Add(nuevoProfe);

            this.SincronizarBaseDatos();
        }



        public bool RegistrarAsistenciaProfesor(string dni)
        {           
            Profesor profeEncontrado = this.listaProfesores.Find(p => p.Dni == dni);

            if (profeEncontrado == null) return false;

            bool resultadoDb = ProfesorDatos.RegistrarAsistencia(profeEncontrado.IdProfesor, profeEncontrado.Dni);

            return resultadoDb;
        }
    }
}