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
        static private Dictionary<int, Operacion> operaciones = new Dictionary<int, Operacion>();
        static Operador() {
            operaciones.Add(1, Sumar);
            operaciones.Add(2, Resta);
            operaciones.Add(3, Multiplicacion);
            operaciones.Add(4, Divicion);
        }
        static public float hacerOperacion(int opcionElegida)
        {
            Console.Clear();
            return operaciones[opcionElegida](pedriNumeros());
        }
        static private float Sumar(float[] num) { return num[0] + num[1]; }
        static private float Resta(float[] num) { return num[0] - num[1]; }
        static private float Multiplicacion(float[] num) { return num[0] * num[1]; }
        static private float Divicion(float[] num)
        {
            Exception ex = new DivideByZeroException("No se puede dividir por cero.");
            return num[1] == 0 ? throw ex : (num[0] / num[1]);
        }
        static private float[] pedriNumeros()
        {
            float[] num = [0, 0];
            int index = 0;
            do
            {
                Console.WriteLine($"ingres el valor {index + 1}");
                //si recive un numero lo guarda, luego incrementa index.
                if (float.TryParse(Console.ReadLine(), out num[index])) index++;
                else Console.WriteLine("Solo puede ingresar numeros");
            } while (index < 2);
            return num;
        }
    }
}
