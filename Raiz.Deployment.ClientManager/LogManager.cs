using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace Raiz.Deployment.ClientManager
{
    public class LogManager
    {
        private string _rutaLocal = string.Empty;
        private string _nombreLog = string.Empty;

        public LogManager()
        {
            _rutaLocal = DeploySettings.ObtenerRutaLocal();
            _nombreLog = DeploySettings.ObtenerNombreLog();
        }

        public void RegistrarDescarga(DescargaComponente descarga)
        {
            //Verificar la existencia de la carpeta destino
            //Creación de la ruta local
            if (!Directory.Exists(_rutaLocal))
            {
                Directory.CreateDirectory(_rutaLocal);
            }
            //Verificar la existencia del archivo de log
            using (var file = new StreamWriter(Path.Combine(_rutaLocal, _nombreLog),true))
            {
                        file.WriteLine(string.Format(
                        "{0},{1},{2},{3},{4},{5},{6}",
                        descarga.FechaDescarga,
                        descarga.Componente,
                        descarga.Modulo,
                        descarga.version,
                        descarga.descargaObligatoria,
                        (int)descarga.estado,
                        descarga.Id));
                file.Close();
            }

        }


        public  List<DescargaComponente> ListarDescargas()
        {
            var file = new FileInfo(Path.Combine(_rutaLocal, _nombreLog));
            var result = new List<DescargaComponente>();

            if (!File.Exists(Path.Combine(_rutaLocal, _nombreLog))) return result;

                using (var con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"" +
                        file.DirectoryName + "\";Extended Properties='text;HDR=Yes;FMT=Delimited(,)';"))
                {
                    using (var cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]", file.Name), con))
                    {
                        con.Open();
 
                        // Using a DataReader to process the data
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the current reader entry...
                                var descarga = new DescargaComponente();
                               // var r1 = reader.GetValue(3);

                                descarga.FechaDescarga =Convert.ToDateTime(reader.GetValue(0));
                                descarga.Componente = (string) reader.GetValue(1);
                                descarga.Modulo =Convert.ToString(reader.GetValue(2));
                                descarga.version = reader.GetValue(3).ToString();
                                descarga.descargaObligatoria =Convert.ToBoolean(reader.GetValue(4));
                                descarga.estado = (DescargaComponente.EstadoDescarga)reader.GetValue(5);
                                descarga.Id =new Guid(reader.GetValue(6).ToString());
                                result.Add(descarga);

                            }
                        }
                        
                    }
                }
            return result;
        }


    }
}
