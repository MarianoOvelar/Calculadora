
using Calculadora;
int[] num = [0, 0];
float resultado = 0;
bool salir = true;
do
{
    try
    {
        resultado = Operador.hacerOperacion(Menu.Mostrar());
        Console.WriteLine($"El resultado es: {(float)Math.Round(resultado, 2)}");
        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    salir = Menu.Salir();
    Console.Clear();
} while (salir);


