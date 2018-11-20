using BE;
using DAL;

namespace BLL
{
    public class LoginController
    {
        LoginService service = new LoginService();

        public bool VerificarCredenciales(Usuario user)
        {
            if (!string.IsNullOrWhiteSpace(user.Nombre) && !string.IsNullOrWhiteSpace(user.Contraseña))
            {
                return service.Validar(user);
            }
            return false;
        }

        public Usuario ObtenerUsuario(Usuario user)
        {
            if (!string.IsNullOrWhiteSpace(user.Nombre))
            {
                return service.GetUsuario(user);
            }
            return null;
        }

        public bool CrearUsuario(Usuario user)
        {
            if (!string.IsNullOrWhiteSpace(user.Nombre) && !string.IsNullOrWhiteSpace(user.Contraseña))
            {
                return service.AltaUsuario(user);
            }
            return false;
        }

        public bool Deslogear(Juego juego, int jugador)
        {
            return service.LogOff(juego, jugador);           
        }

        public void LogIn(Juego juego, Usuario usuario)
        {
            service.Login(juego, usuario);
        }
    }
}
