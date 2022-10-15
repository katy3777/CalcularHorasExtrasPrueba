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
                string query = "select  mes from dbo.dias; ";

                System.Data.Lista<Dias> lD = conexionDBUtils.EjecutarSelect(query);
                if (dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Dias dias = new dias();
                        dias.Id = (int)dr[0];
                        permiso.NombrePermiso = (string)dr[1];

                        list_permisos.Add(permiso);
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