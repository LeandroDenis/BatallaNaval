using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BaseService
    {
        protected SqlConnection conexion = new SqlConnection();
        protected SqlTransaction transaccion;

        public void Abrir()
        {
            if (conexion.State != ConnectionState.Open)
            {
                conexion.ConnectionString = ConfigurationManager.ConnectionStrings["BatallaNaval"].ConnectionString;
                conexion.Open();
            }
        }

        public void Cerrar()
        {
            conexion.Close();
        }

        public void IniciarTransaccion()
        {

            if (transaccion == null && conexion.State == ConnectionState.Open)
            {
                transaccion = conexion.BeginTransaction();
            }
        }

        public void Confirmar()
        {
            transaccion.Commit();
            transaccion = null;
        }

        public void Cancelar()
        {
            transaccion.Rollback();
            transaccion = null;
        }
    }
}