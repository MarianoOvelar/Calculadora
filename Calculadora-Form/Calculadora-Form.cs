using System.Runtime.CompilerServices;

namespace Calculadora_Form
{
    public partial class CalculadoraFrom : Form
    {
        public CalculadoraFrom()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region btnNum
        private void btn0_Click(object sender, EventArgs e) { modificarLabel("0"); }
        private void btn1_Click(object sender, EventArgs e) { modificarLabel("1"); }
        private void btn2_Click(object sender, EventArgs e) { modificarLabel("2"); }
        private void btn3_Click(object sender, EventArgs e) { modificarLabel("3"); }
        private void btn4_Click(object sender, EventArgs e) { modificarLabel("4"); }
        private void btn5_Click(object sender, EventArgs e) { modificarLabel("5"); }
        private void btn6_Click(object sender, EventArgs e) { modificarLabel("6"); }
        private void btn7_Click(object sender, EventArgs e) { modificarLabel("7"); }
        private void btn8_Click(object sender, EventArgs e) { modificarLabel("8"); }
        private void btn9_Click(object sender, EventArgs e) { modificarLabel("9"); }
        #endregion
        #region Borrar
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            this.lbSalidaResultado.Text = this.lbSalidaResultado.Text.Substring(0, this.lbSalidaResultado.Text.Length - 1);
            if (this.lbSalidaResultado.Text.Length == 0) modificarLabel("0");
        }
        private void btnBorrarTodo_Click(object sender, EventArgs e) { this.lbSalidaResultado.Text = "0"; }
        #endregion
        #region Funciones
        private void modificarLabel(string texto)
        {
            if (this.lbSalidaResultado.Text == "0") this.lbSalidaResultado.Text = texto;
            else this.lbSalidaResultado.Text += texto;
        }
        #endregion
        #region Operadores
        private void btnSuma_Click(object sender, EventArgs e) { modificarLabel("+"); }
        private void btnResta_Click(object sender, EventArgs e) { modificarLabel("-"); }
        private void btnMultipicacion_Click(object sender, EventArgs e) { modificarLabel("X"); }
        private void btnDivicion_Click(object sender, EventArgs e) { modificarLabel("/"); }
        #endregion
        private void btnComa_Click(object sender, EventArgs e) { modificarLabel(","); }
        private void btnResultado_Click(object sender, EventArgs e) { modificarLabel("="); }
    }

}
