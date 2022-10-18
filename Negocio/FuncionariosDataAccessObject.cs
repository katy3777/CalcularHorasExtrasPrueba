using Datos;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class FuncionariosDataAccessObject
    {
        private readonly static FuncionariosDataAccessObject _instance = new FuncionariosDataAccessObject();
        private ConexionDBUtils conexionDBUtils;
        private FuncionariosDataAccessObject()
        {
            this.conexionDBUtils = ConexionDBUtils.ObtenerInstancia();
        }

        public static FuncionariosDataAccessObject Instance
        {
            get
            {
                return _instance;
            }
        }
        public List<Funcionario> obtenerInformacionFuncionarios(int numeroMes,int ultimoDiaMes) {
            List<Funcionario> lista_funcionarios = new List<Funcionario>();
            try
            {
                string query =
                    "SELECT  d.rut," +
                    "        f.nombre," +
                    "        f.sueldo " +
                    "FROM ( " +
                    "SELECT c.rut, " +
                    "       " +
                    "       CASE" +
                    "           WHEN c.fecha > c.siguiente" +
                    "           THEN c.fecha" +
                    "           ELSE c.siguiente" +
                    "       END AS [SALIDA]," +
                    "       CASE " +
                    "           WHEN c.siguiente IS NULL " +
                    "           THEN '19000101' " +
                    "           WHEN c.fecha < c.siguiente " +
                    "           THEN c.fecha " +
                    "           ELSE c.siguiente " +
                    "       END AS [ENTRADA] " +
                    "FROM (" +
                    "    SELECT ROW_NUMBER() OVER(PARTITION BY a.rut" +
                    "       ORDER BY a.rut) AS fila," +
                    "       a.rut, " +
                    "       a.fecha, " +
                    "       LEAD(a.fecha) OVER(PARTITION BY a.rut" +
                    "       ORDER BY a.fecha) AS siguiente" +
                    "         FROM dbo.registro AS a" +
                    ") AS  c " +
                    "WHERE c.fila % 2 != 0) AS D left join funcionarios f on d.rut = f.rut " +
                    "WHERE D.ENTRADA BETWEEN  '2022-"+numeroMes+"-01 00:00:00.000' AND '2022-"+numeroMes+"-"+ultimoDiaMes+" 23:59:59.999' " +
                    "ORDER by rut; ";

                System.Data.DataTable dt = conexionDBUtils.EjecutarSelect(query);
                if (dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Funcionario funcionario = new Funcionario();
                        funcionario.Rut = (string)dr[0];
                        funcionario.Nombre = (string)dr[1];
                        funcionario.Salario = (int)dr[2];
                        lista_funcionarios.Add(funcionario);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return lista_funcionarios;

        }
        public List<RegistroAsistencia> obtenerRegistroAsistenciaFuncionarios(string rut ,int numeroMes,int ultimoDiaMes)
        {
            List<RegistroAsistencia> listaRegistroAsistencias = new List<RegistroAsistencia>();
            try
            {
                string query = "SELECT d.ENTRADA,d.SALIDA"+
                               "FROM ("+
                               "SELECT c.rut, "+
                               "       "+
                               "       CASE"+
                               "           WHEN c.fecha > c.siguiente"+
                               "           THEN c.fecha"+
                               "           ELSE c.siguiente"+
                               "       END AS [SALIDA],"+
                               "       CASE"+
                               "           WHEN c.siguiente IS NULL"+
                               "           THEN '19000101'"+
                               "           WHEN c.fecha < c.siguiente"+
                               "           THEN c.fecha"+
                               "           ELSE c.siguiente"+
                               "       END AS [ENTRADA]"+
                               "FROM ("+
                               "    SELECT ROW_NUMBER() OVER(PARTITION BY a.rut"+
                               "       ORDER BY a.rut) AS fila,"+
                               "       a.rut, "+
                               "       a.fecha, "+
                               "       LEAD(a.fecha) OVER(PARTITION BY a.rut"+
                               "       ORDER BY a.fecha) AS siguiente"+
                               "         FROM dbo.registro AS a"+
                               ") AS  c"+
                               "WHERE c.fila % 2 != 0) AS D"+
                               "AND D.RUT = '"+rut+"'"+
                               "WHERE D.ENTRADA BETWEEN  '2022-"+numeroMes+"-01 00:00:00.000' AND '2022-"+numeroMes+"-"+ultimoDiaMes+" 23:59:59.999' "+
                               ";";

                System.Data.DataTable dt = conexionDBUtils.EjecutarSelect(query);
                if (dt.Rows != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        RegistroAsistencia registroAsistencia = new RegistroAsistencia();
                        registroAsistencia.Entrada = (DateTime)dr[0];
                        registroAsistencia.Salida = (DateTime)dr[1];

                        listaRegistroAsistencias.Add(registroAsistencia);
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            return listaRegistroAsistencias;
        }

        public List<Funcionario> obtenerLosFuncionariosRegistroAsistenciaMes(int numeroMes,int ultimoDiaMes)
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            try
            {
                listaFuncionarios = obtenerInformacionFuncionarios( numeroMes, ultimoDiaMes);
                listaFuncionarios.ForEach(
                    funcionario => funcionario.RegistrosAsistencias = this.obtenerRegistroAsistenciaFuncionarios(funcionario.Rut,numeroMes,ultimoDiaMes)
                    );
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }

            return listaFuncionarios;
        }
    }
}