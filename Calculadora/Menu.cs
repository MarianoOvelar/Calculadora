using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    internal static class Menu
    {
        static public int Mostrar()
        {
            Console.WriteLine(opciones);
            while (true)
            {
                opcionElegida = pedirNumero();
                if (opcionElegida > 0 && opcionElegida <= opcionesMax) break;
                else Console.WriteLine($"Solo puede elegir opciones del 1 al {opcionesMax}");
            }
            return opcionElegida;
        }
      
        static private int pedirNumero()
        {
            int num = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out num)) return num;
                else Console.WriteLine("Solo puede ingresar numeros");
            }
        }
        static public bool Salir()
        {
            Console.WriteLine("Ingrese S para salir!!");
             res = Console.ReadLine();
            return res is "s" || res is "S" ? false : true;
        }
        static private string? res = "";
        static private string newL = Environment.NewLine;
        static private string opciones = $"1_ Suma{newL}2_ Resta{newL}3_ Multiplicaciones{newL}4_ Divicion{newL}Elija la operacion a realizar!!";
        static private int opcionElegida = 0;
        static private int opcionesMax = 4;
    }
}
