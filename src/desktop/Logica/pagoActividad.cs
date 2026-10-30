using System;

namespace Club67.Logica
{
    public class PagoActividad : Pago
    {
   
        public PagoActividad(string idPago, float monto, DateTime fechaPago, string medioDePago)
    : base(idPago, monto, fechaPago, medioDePago)
        { }

    }
}