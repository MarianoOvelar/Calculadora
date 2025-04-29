
#region Usings
using Calculadora;
#endregion

#region Variables
int[] num = [0, 0];
float resultado = 0;
bool salir = true;
int menuOpcion = 0;
#endregion

#region Main
do
{
    #region try
    try
    {
        menuOpcion = Menu.Mostrar();
        if (menuOpcion == 5) salir = false;
        if (salir)
        {
            resultado = Operador.hacerOperacion(menuOpcion);
            Console.WriteLine($"El resultado es: {(float)Math.Round(resultado, 2)}");
        }

    }
    #endregion
    #region catch
    catch (Exception ex) { Console.WriteLine(ex.Message); }
    #endregion
    #region Salir
    salir = Menu.Salir();
    Console.Clear();
    #endregion
} while (salir);

#endregion

