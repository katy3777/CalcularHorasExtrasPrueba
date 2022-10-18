using Datos;
using Negocio;
using System.Drawing;
using System.Security.Cryptography.Xml;

namespace Presentacion
{
    public partial class FrmCalcular : Form
    {
        private DiasDataAccessObject diasDataAccessObject = new DiasDataAccessObject();
        private FuncionariosDataAccessObject funcionariosDataAccessObject = FuncionariosDataAccessObject.Instance;
        List<MesInfo> lista_meses;
        public FrmCalcular()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarComboBox();




        }
        private void llenarComboBox() {
            lista_meses = diasDataAccessObject.obtenerLista();
            this.comboBoxProcesarMes.Items.Add("Seleccione el Mes para Procesar");
            foreach (MesInfo mesInfo in lista_meses)
            {
                this.comboBoxProcesarMes.Items.Add((string)mesInfo.Nombre_mes);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mes_a_procesar = this.comboBoxProcesarMes.SelectedItem.ToString();
            MesInfo mesinfo = this.lista_meses.Where(mes => mes.Nombre_mes == mes_a_procesar).ToList<MesInfo>()[0];
            List<Funcionario> funcionarios = funcionariosDataAccessObject
                .obtenerLosFuncionariosRegistroAsistenciaMes(mesinfo.Mes, mesinfo.Dia);

            funcionarios.ForEach(
                funcionario => this.ProcesarFuncionario(funcionario)
            );
        }

        private void ProcesarFuncionario(Funcionario funcionario)
        {
            var asistencia = funcionario.RegistrosAsistencias;
            asistencia.ForEach(
                diaTrabajado => this.CalcularHoraExtra(diaTrabajado)
                );
        }

        private void CalcularHoraExtra(RegistroAsistencia diaTrabajado)
        {
            var at = diaTrabajado.Salida.Subtract(diaTrabajado.Entrada);
        }
    }


}
