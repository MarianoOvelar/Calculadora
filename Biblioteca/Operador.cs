using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    public class Operador
    {
        private delegate float Operacion(float[] num);
        static private Dictionary<char, Operacion> operaciones = new Dictionary<char, Operacion>();
        static Operador() {
            operaciones.Add('+', Sumar);
            operaciones.Add('-', Resta);
            operaciones.Add('*', Multiplicacion);
            operaciones.Add('/', Divicion);
        }
        static public float hacerOperacion(float num1,float num2,char opeElegida)
        {
            return operaciones[opeElegida]([num1,num2]);
        }
        static private float Sumar(float[] num) { return num[0] + num[1]; }
        static private float Resta(float[] num) { return num[0] - num[1]; }
        static private float Multiplicacion(float[] num) { return num[0] * num[1]; }
        static private float Divicion(float[] num)
        {
            Exception ex = new DivideByZeroException("No se puede dividir por cero.");
            return num[1] == 0 ? throw ex : (num[0] / num[1]);
        }
    }
}
