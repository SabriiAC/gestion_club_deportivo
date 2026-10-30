using System;
using System.IO;
using System.Diagnostics;

namespace Club67.Logica
{
    public class carnet
    {
        // ATRIBUTOS PRIVADOS 
        private int numeroCarnet;
        private DateTime fechaEmision;
        private string estadoCarnet;

        // CONSTRUCTOR DE CARNET
        public carnet(int numeroCarnet, DateTime fechaEmision, string estadoCarnet)
        {
            this.numeroCarnet = numeroCarnet;
            this.fechaEmision = fechaEmision;
            this.estadoCarnet = estadoCarnet;
        }

        // GET Y SET
        public int NumeroCarnet
        {
            get { return numeroCarnet; }
            set { numeroCarnet = value; }
        }

        public DateTime FechaEmision
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public string EstadoCarnet
        {
            get { return estadoCarnet; }
            set { estadoCarnet = value; }
        }

        public string imprimirCarnet(string nombreCompleto, string dni)
        {
            return
                "==================================================\n" +
                "             BIENVENIDO A CLUB DEPORTIVO          \n" +
                "              CARNET DE SOCIO                     \n" +
                "==================================================\n" +
                "Nro Carnet: " + this.NumeroCarnet + "\n" +
                "Fecha Emisión: " + this.FechaEmision.ToString("dd/MM/yyyy") + "\n" +
                "Estado: " + this.EstadoCarnet + "\n" +
                "--------------------------------------------------\n" +
                "DATOS DEL ASOCIADO:\n" +
                "Nombre:    " + nombreCompleto + "\n" +
                "DNI:       " + dni + "\n" +
                "==================================================\n";
        }

        // Método para guardar y abrir el carnet
        public void ImprimirYAbrir(string nombreCompleto, string dni)
        {
            try
            {
                // Generación de ruta en Mis Documentos
                string rutaMisDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string nombreArchivo = "Carnet_Socio_" + dni + ".txt";
                string rutaCompleta = Path.Combine(rutaMisDocumentos, nombreArchivo);

                // Obtención del contenido formateado
                string carnetContenido = this.imprimirCarnet(nombreCompleto, dni);

                // Escritura física en disco
                File.WriteAllText(rutaCompleta, carnetContenido);

                // Apertura del archivo de texto generado
                ProcessStartInfo psi = new ProcessStartInfo(rutaCompleta)
                {
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al emitir y abrir el archivo del carnet: " + ex.Message);
            }
        }
    }
}