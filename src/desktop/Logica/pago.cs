using System;

namespace Club67.Logica
{
    public abstract class Pago
    {
        // Atributos privados 
        private string idPago;
        private float monto;
        private DateTime fechaPago;
        private string medioDePago;
        public Pago(string idPago, float monto, DateTime fechaPago, string medioDePago)
        {
            this.IdPago = idPago;
            this.Monto = monto;
            this.FechaPago = fechaPago;
            this.MedioDePago = medioDePago;
        }

        // Propiedades públicas
        public string IdPago
        {
            get { return idPago; }
            set { idPago = value; }
        }

        public float Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        public DateTime FechaPago
        {
            get { return fechaPago; }
            set { fechaPago = value; }
        }

        public string MedioDePago
        {
            get { return medioDePago; }
            set { medioDePago = value; }
        }
    }
}