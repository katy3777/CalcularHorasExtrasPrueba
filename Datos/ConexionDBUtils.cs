using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class ConexionDBUtils
    {
        private SqlConnection _sqlConnection;
        private static ConexionDBUtils? _instance = null;

        private ConexionDBUtils()
        {
            this._sqlConnection = new SqlConnection("Data Source=localhost;" +
                                                    "Initial Catalog=DB_REQUERIMIENTOS;" +
                                                    "User ID=sa;" +
                                                    "Password=sa_pwd_2623141;");
        }
        public static ConexionDBUtils ObtenerInstancia()
        {
            if (_instance == null)
            {
                _instance = new ConexionDBUtils();
            }
            return _instance;
        }

        public DataTable EjecutarSelect(string select)
        {
            DataTable dt = new DataTable();
            try
            {
                this._sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(select, _sqlConnection);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                try
                {

                    this._sqlConnection.Close();
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
            return dt;
        }
        public int EjecutarInsert(string insert)
        {
            int numeroRegistrosAfectados = 0;
            try
            {
                this._sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(insert, _sqlConnection);
                numeroRegistrosAfectados = cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                this._sqlConnection.Close();
            }
            return numeroRegistrosAfectados;
        }
        public void AbrirConexion()
        {
            try
            {
                this._sqlConnection.Open();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                System.Console.WriteLine(invalidOperationException.Message);
                throw invalidOperationException;
            }
            catch (SqlException sqlException)
            {
                System.Console.WriteLine(sqlException.Message);
                throw sqlException;
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception.Message);
                throw;
            }
            finally
            {
                try
                {
                    this._sqlConnection.Close();
                }
                catch (SqlException sqlException)
                {
                    System.Console.WriteLine(sqlException.Message);
                    throw sqlException;
                }
            }

        }
    }
}