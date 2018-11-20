using System;
using System.Windows.Forms;

namespace GUI
{
    public partial class IndexForm : Form
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            LoginForm formLogin = new LoginForm();
            Hide();
            formLogin.ShowDialog();
            Close();
        }
    }
}
