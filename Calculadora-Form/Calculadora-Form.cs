using System.Runtime.CompilerServices;
using Calculadora;

namespace Calculadora_Form
{
    public partial class CalculadoraFrom : Form
    {
        public CalculadoraFrom()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        #region BtnNum
        private void Btn0_Click(object sender, EventArgs e) { modificarLabelNumero("0"); }
        private void Btn1_Click(object sender, EventArgs e) { modificarLabelNumero("1"); }
        private void Btn2_Click(object sender, EventArgs e) { modificarLabelNumero("2"); }
        private void Btn3_Click(object sender, EventArgs e) { modificarLabelNumero("3"); }
        private void Btn4_Click(object sender, EventArgs e) { modificarLabelNumero("4"); }
        private void Btn5_Click(object sender, EventArgs e) { modificarLabelNumero("5"); }
        private void Btn6_Click(object sender, EventArgs e) { modificarLabelNumero("6"); }
        private void Btn7_Click(object sender, EventArgs e) { modificarLabelNumero("7"); }
        private void Btn8_Click(object sender, EventArgs e) { modificarLabelNumero("8"); }
        private void Btn9_Click(object sender, EventArgs e) { modificarLabelNumero("9"); }
        private void BtnComa_Click(object sender, EventArgs e) { modificarLabelNumero(","); }

        #endregion

        #region BtnBorrar
        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            this.lbNumero.Text = this.lbNumero.Text.Substring(0, this.lbNumero.Text.Length - 1);
            if (this.lbNumero.Text.Length == 0) modificarLabelNumero("0");
        }
        private void BtnBorrarTodo_Click(object sender, EventArgs e) { this.RestaurarTodo(); }
        #endregion

        #region BtnOperadores
        private void BtnSuma_Click(object sender, EventArgs e) { ModificarOperador('+'); }
        private void BtnResta_Click(object sender, EventArgs e) { ModificarOperador('-'); }
        private void BtnMultipicacion_Click(object sender, EventArgs e) { ModificarOperador('*'); }
        private void BtnDivicion_Click(object sender, EventArgs e) { ModificarOperador('/'); }
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            sePresionoIgual = true;
            this.Calcular();
        }
        #endregion

        #region ModificarLabel
        private void modificarLabelNumero(string texto)
        {
            if (this.lbNumero.Text == "0" || seIngresaOtroNumero) this.lbNumero.Text = texto;
            else this.lbNumero.Text += texto;
            seIngresaOtroNumero = false;
        }
        #endregion
        
        #region Funciones
        private void RestaurarTodo()
        {
            this.operadorSelecionado = ' ';
            this.num1 = 0;
            this.num2 = 0;
            this.resultado = 0;
            this.lbNumero.Text = "0";
            this.lbFormula.Text = "";
            this.seIngresaOtroNumero = false;
        }

        private void ModificarOperador(char operador)
        {
            if (!seIngresaOtroNumero) Calcular();
            seIngresaOtroNumero = true;
            if (this.operadorSelecionado == ' ') this.num1 = float.Parse(this.lbNumero.Text);
            this.operadorSelecionado = operador;
            this.lbFormula.Text = this.num1.ToString() + operador;

        }

        private void Calcular()
        {
            if (this.operadorSelecionado == ' ')
            {
                this.num1 = float.Parse(this.lbNumero.Text);
                this.lbFormula.Text = this.num1.ToString() + "=";
                return;
            }

            if (sePresionoIgual)
            {
                if (!seIngresaOtroNumero)
                {
                    this.num2 = float.Parse(this.lbNumero.Text);
                    this.lbFormula.Text = this.num1.ToString() + operadorSelecionado + this.num2.ToString() + "=";
                    this.resultado = Operador.hacerOperacion(this.num1, this.num2, this.operadorSelecionado);
                    this.lbNumero.Text = this.resultado.ToString();
                    this.num1 = this.resultado;
                    this.numAux = num2;
                    seIngresaOtroNumero = true;
                }
                else
                {
                    this.lbFormula.Text = this.resultado.ToString() + operadorSelecionado + this.numAux.ToString() + "=";
                    this.resultado = Operador.hacerOperacion(this.resultado, this.numAux, this.operadorSelecionado);
                    this.lbNumero.Text = this.resultado.ToString();
                    this.num1 = this.resultado;

                }
                sePresionoIgual = false;
                return;
            }
            this.num2 = float.Parse(this.lbNumero.Text);
            this.resultado = Operador.hacerOperacion(this.num1, this.num2, this.operadorSelecionado);
            this.lbNumero.Text = this.resultado.ToString();
            this.num1 = this.resultado;
            this.lbFormula.Text = this.num1.ToString() + operadorSelecionado;
        }
        #endregion

        private void CalculadoraFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            string operadores = "+-*/";
            if (char.IsDigit(e.KeyChar) || operadores.IndexOf(e.KeyChar) != -1)
            {
                if (e.KeyChar == '*') BtnMultipicacion_Click(sender, e);
                else if (e.KeyChar == '/') BtnDivicion_Click(sender, e);
                else if (e.KeyChar == '+') BtnSuma_Click(sender, e);
                else if (e.KeyChar == '-') BtnResta_Click(sender, e);
                else this.lbFormula.Text += e.KeyChar.ToString();
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
                BtnIgual_Click(sender, e);

            }
        }





        #region Variables
        private char operadorSelecionado = ' ';
        private float num1 = 0;
        private float num2 = 0;
        private float numAux = 0;
        private float resultado = 0;
        private bool sePresionoIgual = false;
        private bool seIngresaOtroNumero = false;

        #endregion
    }
}