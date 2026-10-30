using System;

namespace Club67.Logica
{
    public class PagoMensual : Pago
    {
        // Atributo propio 
        private DateTime fechaVencimiento;
        public PagoMensual(string idPago, float monto, DateTime fechaPago, string medioDePago, DateTime fechaVencimiento)
            : base(idPago, monto, fechaPago, medioDePago)
        {
            this.fechaVencimiento = fechaVencimiento;
        }

        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        
    }
}