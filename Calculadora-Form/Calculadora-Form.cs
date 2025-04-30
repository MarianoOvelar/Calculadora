using System.Runtime.CompilerServices;

namespace Calculadora_Form
{
    public partial class CalculadoraFrom : Form
    {
        public CalculadoraFrom()
        {
            InitializeComponent();
            this.KeyPreview = true; // Asegúrate de que esto esté aquí

        }

        #region BtnNum
        private void Btn0_Click(object sender, EventArgs e) { modificarLabel("0"); }
        private void Btn1_Click(object sender, EventArgs e) { modificarLabel("1"); }
        private void Btn2_Click(object sender, EventArgs e) { modificarLabel("2"); }
        private void Btn3_Click(object sender, EventArgs e) { modificarLabel("3"); }
        private void Btn4_Click(object sender, EventArgs e) { modificarLabel("4"); }
        private void Btn5_Click(object sender, EventArgs e) { modificarLabel("5"); }
        private void Btn6_Click(object sender, EventArgs e) { modificarLabel("6"); }
        private void Btn7_Click(object sender, EventArgs e) { modificarLabel("7"); }
        private void Btn8_Click(object sender, EventArgs e) { modificarLabel("8"); }
        private void Btn9_Click(object sender, EventArgs e) { modificarLabel("9"); }
        #endregion
        #region Borrar
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            this.lbSalidaResultado.Text = this.lbSalidaResultado.Text.Substring(0, this.lbSalidaResultado.Text.Length - 1);
            if (this.lbSalidaResultado.Text.Length == 0) modificarLabel("0");
        }
        private void BtnBorrarTodo_Click(object sender, EventArgs e) { this.lbSalidaResultado.Text = "0"; }
        #endregion
        #region Funciones
        private void modificarLabel(string texto)
        {

            if (this.lbSalidaResultado.Text == "0") this.lbSalidaResultado.Text = texto;
            else this.lbSalidaResultado.Text += texto;


        }
        #endregion
        #region Operadores
        private void BtnSuma_Click(object sender, EventArgs e) { modificarLabel("+"); }
        private void BtnResta_Click(object sender, EventArgs e) { modificarLabel("-"); }
        private void BtnMultipicacion_Click(object sender, EventArgs e) { modificarLabel("x"); }
        private void BtnDivicion_Click(object sender, EventArgs e) { modificarLabel("÷"); }
        private void BtnComa_Click(object sender, EventArgs e) { modificarLabel(","); }
        private void BtnResultado_Click(object sender, EventArgs e) { modificarLabel("="); }
        #endregion
        private bool enterPresionadoRecientemente = false;

        private void CalculadoraFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            string operadores = "+-*/";
            if (char.IsDigit(e.KeyChar) || operadores.IndexOf(e.KeyChar) != -1)
            {
                if (e.KeyChar == '*') modificarLabel("x");
                else if (e.KeyChar == '/') modificarLabel("÷");
                else modificarLabel(e.KeyChar.ToString());
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                BtnBorrar_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                BtnBorrarTodo_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnResultado_Click(sender, e);

            }
        }

    }

}
