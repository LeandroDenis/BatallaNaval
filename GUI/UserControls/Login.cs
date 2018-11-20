using System;
using System.Windows.Forms;
using BLL;
using BE;

namespace GUI
{
    public partial class Login : UserControl
    {
        private Juego juego;
        public Login(Juego nuevoJuego)
        {
            this.juego = nuevoJuego;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginController ctrller = new LoginController();
            Usuario user = new Usuario();
            user.Nombre = textBox1.Text;
            user.Contraseña = textBox2.Text;
            Usuario usuario = ctrller.ObtenerUsuario(user);
            if (usuario != null)
            {
                if (ctrller.VerificarCredenciales(user))
                {
                    ctrller.LogIn(juego, usuario);
                    label5.Text = "Usuario logeado con exito";
                    OcultarTrasLogin();
                }
                else
                {
                    label5.Text = "Usuario y/o contraseña incorrecta";
                }
            }
            else
            {
                var res = ctrller.CrearUsuario(user);
                if (!res)
                {
                    label5.Text = "Ocurrio un error al crear el usuario";
                }
                else
                {
                    label5.Text = "Usuario creado";
                    OcultarTrasLogin();
                }
            }
        }

        private void OcultarTrasLogin()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
        }
    }
}