using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
namespace Club67.Logica
{
    public class FichaMedica
    {
        // Atributos privados 
        private int nroFicha;
        private string tratamientoNutricional;
        private string cargaFisicaPermitida;
        private DateTime fechaUltimaConsulta;
        private string observaciones;
        public FichaMedica(int nroFicha, string tratamientoNutricional, string cargaFisicaPermitida, DateTime fechaUltimaConsulta, string observaciones)
        {
            this.NroFicha = nroFicha;
            this.TratamientoNutricional = tratamientoNutricional;
            this.CargaFisicaPermitida = cargaFisicaPermitida;
            this.FechaUltimaConsulta = fechaUltimaConsulta;
            this.Observaciones = observaciones;
        }

        // Propiedades públicas
        public int NroFicha
        {
            get { return nroFicha; }
            set { nroFicha = value; }
        }

        public string TratamientoNutricional
        {
            get { return tratamientoNutricional; }
            set { tratamientoNutricional = value; }
        }

        public string CargaFisicaPermitida
        {
            get { return cargaFisicaPermitida; }
            set { cargaFisicaPermitida = value; }
        }

        public DateTime FechaUltimaConsulta
        {
            get { return fechaUltimaConsulta; }
            set { fechaUltimaConsulta = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }


        public void RegistrarDiagnostico(string diagnostico, string nivel, string kilos)
        {
            this.TratamientoNutricional = diagnostico;
            this.FechaUltimaConsulta = DateTime.Now;


            if (!string.IsNullOrEmpty(kilos))
            {
                this.cargaFisicaPermitida = nivel + " - " + kilos + " kg";
            }
            else
            {
                this.cargaFisicaPermitida = nivel + " - Sin carga máxima";
            }
        }
    }
}