using BE;
using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class JuegoForm : Form
    {
        private Juego juego;
        public JuegoForm(Juego nuevoJuego)
        {
            juego = nuevoJuego;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
