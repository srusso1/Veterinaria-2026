using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class VistaPrincipal
    {
        public void Menu()
        {
            int op ;
            do
            {
                
                Console.Clear();
                Console.SetCursorPosition(30, 5); Console.Write("M E N U   P R I N C I P A L");

                Console.SetCursorPosition(32, 10); Console.Write("1. Gestión de Veterinarios");
                Console.SetCursorPosition(32, 12); Console.Write("2. Gestión de Propietarios");
                Console.SetCursorPosition(32, 14); Console.Write("3. Gestión de Mascotas");
                Console.SetCursorPosition(32, 16); Console.Write("4. la estoy pensando ....");

                Console.SetCursorPosition(32, 22); Console.Write("0. Salir");
                Console.SetCursorPosition(32, 24); Console.Write("Digite una opción: ");
                Console.SetCursorPosition(51, 24); op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        new VistaVeterinaria().Menu();
                        break;
                    default:
                        break;
                }

                //Console.ReadKey();

            } while (op!=0);
        }
    }
}
