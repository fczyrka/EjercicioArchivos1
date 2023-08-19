using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjercicioFormularios
{
    public partial class FormMain : Form
    {

        List<Contacto> contactosActuales = new List<Contacto>();

        public FormMain()
        {
            InitializeComponent();
            // tambien la carga del archivo podria ir aca
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cargar lista del archivo
        }

        void refrescarLista()
        {
            lstContactos.Items.Clear();

            for (int i = 0; i < contactosActuales.Count; i++)
            {
                lstContactos.Items.Add(contactosActuales[i]);
            }
         }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // MATI: creo una instancia del form de nuevo y la muestro
            FormNewContact formNewContact = new FormNewContact();

            // el form no va a salir de showDialog hasta que lo cierres
            // el form me devuelve un resultado, lo guardo en la variable resultado
            DialogResult resultado = formNewContact.ShowDialog();

            // me fijo si el resultado es cancelar entonces no hago nada (salgo del método actual)
            if (resultado == DialogResult.Cancel)
            {
                return;
            }

            // si sigo es porque retornó Ok, entonces tomo la instancia de contacto que se creó en el form (en el método aceptar) y la agrego a la lista
            contactosActuales.Add(formNewContact.contacto);
            // la variable contacto puedo accederla porque es public
            // igual lo importante es que estoy tomando la referencia a la instancia de formNewContact.contacto, que la creamos en el método aceptar

            // refresco el list box así se ven los cambios
            refrescarLista();


        }
    }
}
