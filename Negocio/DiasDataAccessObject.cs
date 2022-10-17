using Datos;
using System.Data;

namespace Negocio
{
    public class DiasDataAccessObject
    {
        private ConexionDBUtils conexionDBUtils = ConexionDBUtils.ObtenerInstancia();
        public List<Dias> obtenerLista() {

            List<Dias> list_permisos = new List<Dias>();
            try
            {
                string query = "select nombre_mes from dbo.dias; ";

                System.Data.DataTable dt = conexionDBUtils.EjecutarSelect(query);
                if (dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Dias dias = new Dias();
                        dias.Nombre_mes =(string) dr[0];
                        list_permisos.Add(dias);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return list_permisos;
        }
    } 
} 