using Datos;
using Negocio;
using System.Drawing;

namespace Presentacion
{
    public partial class FrmCalcular : Form
    {
        private DiasDataAccessObject diasDataAccessObject = new DiasDataAccessObject();
        public FrmCalcular()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            List<Dias> lista_meses = diasDataAccessObject.obtenerLista();
            foreach (Dias dias in lista_meses)
            {
                cmbMes.Items.Add(dias.Nombre_mes);
            }
        }
    }


}
