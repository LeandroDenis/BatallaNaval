using System;
using BE;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class LoginService : BaseService
    {
        public bool Validar(Usuario user)
        {
            Abrir();
            using (SqlCommand comando = new SqlCommand())
            {
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE NOMBRE = @Nombre AND PASSWORD = @Password";
                comando.Parameters.AddWithValue("@Nombre", user.Nombre);
                comando.Parameters.AddWithValue("@Password", user.Contraseña);

                int existe = (int)comando.ExecuteScalar();

                comando.Dispose();
                Cerrar();
                return existe == 1 ? true : false;
            }
        }

        public bool LogOff(Juego juego, int jugador)
        {
            try
            {
                Bitacora.Write("Se procede a deslogear al usuario: " + juego.Jugadores[jugador].Nombre);
                if (juego.Jugadores.Count > 1)
                {
                    juego.Jugadores.Remove(juego.Jugadores[jugador]);
                }
                else
                {
                    juego.Jugadores.Clear();
                }
                Bitacora.Write("Deslogeo exitoso");
                return true;
            }
            catch (Exception ex)
            {
                Bitacora.Write("Error deslogeando al jugador: " + ex.Message);
                return false;
            }
        }

        public bool AltaUsuario(Usuario user)
        {
            try
            {
                Bitacora.Write("Se procede a crear al usuario: " + user.Nombre);
                Abrir();
                using (SqlCommand comando = new SqlCommand())
                {
                    Usuario usuario = new Usuario();

                    comando.Connection = conexion;
                    comando.Transaction = transaccion;
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "INSERT INTO  Usuarios VALUES (@Nombre, @Password, @Ganadas, @Perdidas)";
                    comando.Parameters.AddWithValue("@Nombre", user.Nombre);
                    comando.Parameters.AddWithValue("@Password", user.Contraseña);
                    comando.Parameters.AddWithValue("@Ganadas", user.PartidasGanadas);
                    comando.Parameters.AddWithValue("@Perdidas", user.PartidasPerdidas);

                    comando.ExecuteNonQuery();

                    Confirmar();
                    comando.Dispose();
                    Cerrar();
                    Bitacora.Write("Usuario creado con exito");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Write("Error al crear el usuario: " + ex.Message);
                Cancelar();
                Cerrar();
                return false;
            }


        }

        public void Login(Juego juego, Usuario usuario)
        {
            Bitacora.Write("Se procede a logear al usuario: " + usuario.Nombre);
            juego.Jugadores.Add(usuario);
            Bitacora.Write("Logeo exitoso");
        }

        public Usuario GetUsuario(Usuario user)
        {
            Abrir();
            using (SqlCommand comando = new SqlCommand())
            {
                Usuario usuario = null;

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM Usuarios WHERE NOMBRE = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", user.Nombre);

                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    usuario = new Usuario();
                    usuario.Nombre = lector["Nombre"].ToString();
                    usuario.PartidasGanadas = (int)lector["Ganadas"];
                    usuario.PartidasPerdidas = (int)lector["Perdidas"];
                }

                lector.Close();
                comando.Dispose();
                Cerrar();
                return usuario;
            }
        }
    }
}
