using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Raiz.Deployment.DTO;
using Version = System.Version;

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
                        "{0};{1};{2};{3};{4};{5};{6}",
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
                        file.DirectoryName + "\";Extended Properties='text;HDR=No;FMT=Delimited(;)';"))
                {
                    using (var cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]", file.Name), con))
                    {
                        con.Open();
                        var dt=new DataTable();
                        var da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        for (var i = 0; i < dt.Rows.Count; i++)
                        {
                            var descarga = new DescargaComponente();
                            var cadenas = dt.Rows[i][0].ToString().Split(';');
                            if (cadenas.Length < 2) continue;
                            var version =new Version(cadenas[3]);

                            descarga.FechaDescarga = Convert.ToDateTime(cadenas[0]);
                            descarga.Componente = (string)cadenas[1];
                            descarga.Modulo = Convert.ToString(cadenas[2]);
                            descarga.version = version;

                            descarga.descargaObligatoria = Convert.ToBoolean(cadenas[4]);
                            descarga.estado = (DescargaComponente.EstadoDescarga)Convert.ToInt32(cadenas[5]);
                            descarga.Id = new Guid(cadenas[6]);
                            result.Add(descarga);
                        }

                        /*
                        // Using a DataReader to process the data
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Process the current reader entry...
                                    var descarga = new DescargaComponente();
                                    var r1 = reader.GetValue(3);
                                    //var r2 = reader.GetValue(4).ToString();
                                    //var r3 = reader.GetValue(5).ToString();
                                    var version = new Version(reader.GetValue(3).ToString());

                                    descarga.FechaDescarga = Convert.ToDateTime(reader.GetValue(0));
                                    descarga.Componente = (string)reader.GetValue(1);
                                    descarga.Modulo = Convert.ToString(reader.GetValue(2));
                                    descarga.version = version;

                                    descarga.descargaObligatoria = Convert.ToBoolean(reader.GetValue(4));
                                    descarga.estado = (DescargaComponente.EstadoDescarga)reader.GetValue(5);
                                    descarga.Id = new Guid(reader.GetValue(6).ToString());
                                    result.Add(descarga);


                                }
                            }

                        */
                        
                    }
                }
            return result;
        }


    }
}
