using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arbol;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa la raiz del arbol");
            int b = RecibirNumero();
            Arbol.Arbol A = new Arbol.Arbol(b);
            int c = 0;
            while (c < 9)
            {
                Console.WriteLine("Ingrese el siguiente hijo");
                b = RecibirNumero();
                A.Insertar(b);
                c++;
            }
            Console.WriteLine("Ingrese el dato a eliminar");
            b = RecibirNumero();
            A.Eliminar(b);
        }

        static int RecibirNumero()
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return RecibirNumero();
            }
        }
    }
}
