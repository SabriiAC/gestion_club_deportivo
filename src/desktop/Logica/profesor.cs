using System;

namespace Club67.Logica
{
    public class Profesor
    {
        // Atributos privados del docente
        private int idProfesor;
        private string nombre;
        private string apellido;
        private string dni;
        private string telefono;
        private string direccion;
        private float sueldo;
        public Profesor(int idProfesor, string nombre, string apellido, string dni, string telefono, string direccion, float sueldo)
        {
            this.IdProfesor = idProfesor;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Sueldo = sueldo;
        }

        // Propiedades públicas
        public int IdProfesor
        {
            get { return idProfesor; }
            set { idProfesor = value; }
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

        public float Sueldo
        {
            get { return sueldo; }
            set { sueldo = value; }
                    }
        public Profesor(string nombre, string apellido, string dni, string telefono, string direccion, float sueldo)
        {
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Direccion = direccion;
            Sueldo = sueldo;
        }
    
    }
}