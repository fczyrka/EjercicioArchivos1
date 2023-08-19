using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioFormularios
{
    public partial class FormNewContact : Form
    {
        // MATI: le pongo public así puedo acceder esta variable desde fuera de la clase (en este caso la clase es el formulario)
        public Contacto contacto;

        public FormNewContact()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // MATI: creo una nueva instancia de contacto y le asigno los valores de los campos
            contacto = new Contacto();
            contacto.Nombre = txtNombre.Text;
            contacto.Edad = Convert.ToInt32(txtEdad.Text);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
