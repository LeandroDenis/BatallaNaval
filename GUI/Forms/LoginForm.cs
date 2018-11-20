using BE;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using BLL;

namespace GUI
{
    public partial class LoginForm : Form
    {
        private Juego nuevoJuego = new Juego();

        public LoginForm()
        {
            Login loginUsuario1 = new Login(nuevoJuego);
            Login loginUsuario2 = new Login(nuevoJuego);
            loginUsuario1.Location = new Point(100, 75);
            loginUsuario2.Location = new Point(650, 75);
            switch (nuevoJuego.Jugadores.Count())
            {
                case 0:
                    Controls.Add(loginUsuario1);
                    Controls.Add(loginUsuario2);
                    break;
                case 1:
                    Controls.Add(loginUsuario1);
                    DatosUsuario user = new DatosUsuario(nuevoJuego, 0);
                    user.Location = new Point(650, 75);
                    user.OnLogOff += OnLogOff;
                    Controls.Add(user);
                    break;
                case 2:
                    DatosUsuario user1 = new DatosUsuario(nuevoJuego, 0);
                    user1.OnLogOff += OnLogOff;
                    DatosUsuario user2 = new DatosUsuario(nuevoJuego, 1);
                    user2.OnLogOff += OnLogOff;
                    user1.Location = new Point(100, 75);
                    user2.Location = new Point(650, 75);
                    Controls.Add(user1);
                    Controls.Add(user2);
                    break;
                default:
                    break;
            }
            InitializeComponent();
        }

        private void OnLogOff(int jugador)
        {
            LoginController ctrller = new LoginController();
            ctrller.Deslogear(nuevoJuego, jugador);
            if (jugador == 0)
            {
                Login loginUsuario1 = new Login(nuevoJuego);
                loginUsuario1.Location = new Point(100, 75);
                Controls.Add(loginUsuario1);
            }
            else {
                Login loginUsuario2 = new Login(nuevoJuego);
                loginUsuario2.Location = new Point(650, 75);
                Controls.Add(loginUsuario2);
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (nuevoJuego.Jugadores.Count() == 2)
            {
                JuegoForm juego = new JuegoForm(nuevoJuego);
                var toRemove = Controls.OfType<Login>().ToList();
                foreach (Control control in toRemove)
                {
                    Controls.Remove(control);
                }
                DatosUsuario user1 = new DatosUsuario(nuevoJuego, 0);
                user1.OnLogOff += OnLogOff;
                DatosUsuario user2 = new DatosUsuario(nuevoJuego, 1);
                user2.OnLogOff += OnLogOff;
                user1.Location = new Point(100, 75);
                user2.Location = new Point(650, 75);
                Controls.Add(user1);
                Controls.Add(user2);

                Hide();
                juego.ShowDialog();
                Show();
            }
            else
            {
                label1.Visible = true;
                label1.Text = "Se necesita que esten logeados los dos jugadores";
            }
        }
    }
}
