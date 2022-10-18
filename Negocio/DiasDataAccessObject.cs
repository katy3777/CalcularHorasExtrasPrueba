using Datos;
using System.Data;

namespace Negocio
{
    public class DiasDataAccessObject
    {
        private ConexionDBUtils conexionDBUtils = ConexionDBUtils.ObtenerInstancia();
        public List<MesInfo> obtenerLista() {

            List<MesInfo> lista_mesInfo = new List<MesInfo>();
            try
            {
                string query = "select mes, nombre_mes,dias from dbo.dias; ";

                System.Data.DataTable dt = conexionDBUtils.EjecutarSelect(query);
                if (dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MesInfo mesInfo = new MesInfo();
                        mesInfo.Mes = (int)dr[0];
                        mesInfo.Nombre_mes= (string)dr[1];
                        mesInfo.Dia= (int)dr[2];

                        lista_mesInfo.Add(mesInfo);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lista_mesInfo;
        }
    } 
} 