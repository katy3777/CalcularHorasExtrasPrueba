using Datos;

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
        
    }
}