using System.Windows.Forms;
using BE;

namespace GUI
{
    public partial class DatosUsuario : UserControl
    {
        public delegate void delOnLogOff(int jugador);
        public event delOnLogOff OnLogOff;

        private int jugador;
        public DatosUsuario(Juego nuevoJuego, int numeroJugador)
        {
            jugador = numeroJugador;
            var user = nuevoJuego.Jugadores[numeroJugador];
            InitializeComponent();
            label2.Text = user.Nombre;
            label4.Text = user.PartidasGanadas.ToString();
            label6.Text = user.PartidasPerdidas.ToString();
            label8.Text = user.PartidasGanadas + user.PartidasPerdidas == 0 ? "0" : (user.PartidasGanadas / (user.PartidasGanadas + user.PartidasPerdidas)).ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            OnLogOff(jugador);
            Hide();
        }
    }
}
