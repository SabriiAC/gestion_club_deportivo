using System;
using System.Collections.Generic;

namespace Club67.Logica
{
    public class Actividad
    {
        private string idActividad;
        private string nombre;
        private string horario;
        private int cupoMaximo;
        private float precio;
        public Actividad(string idActividad, string nombre, string horario, int cupoMaximo, float precio)
        {
            this.IdActividad = idActividad;
            this.Nombre = nombre;
            this.Horario = horario;
            this.Precio = precio;
            this.CupoMaximo = cupoMaximo; 
        }
        public string IdActividad
        {
            get { return idActividad; }
            set { idActividad = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Horario
        {
            get { return horario; }
            set { horario = value; }
        }

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int CupoMaximo
        {
            get { return cupoMaximo; }
            set
            {

                if (value <= 0)
                {
                    throw new ArgumentException("El cupo máximo debe ser mayor a cero.");
                }
                cupoMaximo = value;
            }
            
        }

        public static List<Actividad> ObtenerCatalogo()
        {
            List<Actividad> catalogo = new List<Actividad>();

            catalogo.Add(new Actividad("1", "Gimnasio Pase Libre", "08:00", 30, 6000f));
            catalogo.Add(new Actividad("2", "Natación", "09:00", 15, 7000f));
            catalogo.Add(new Actividad("3", "Pilates", "10:00", 12, 5500f));
            catalogo.Add(new Actividad("4", "Spinning", "18:00", 20, 5000f));
            catalogo.Add(new Actividad("5", "Crossfit", "19:00", 25, 6500f));

            return catalogo;
        }



    }
}