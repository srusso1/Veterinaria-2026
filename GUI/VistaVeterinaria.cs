using BLL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class VistaVeterinaria : IVistas
    {
        ServicioVeterinario servicio = new ServicioVeterinario();
        public void Capturar()
        {
            do
            {
                Veterinario veterinario = new Veterinario();
                Console.Clear();
                Console.SetCursorPosition(30, 5); Console.Write("R E G I S T R A R - V E T E R I N A R I O");
                Console.SetCursorPosition(10,8); Console.Write("ID");
                Console.SetCursorPosition(10, 10); Console.Write("NOMBRES");
                Console.SetCursorPosition(10, 12); Console.Write("DIRECCION");
                Console.SetCursorPosition(10, 14); Console.Write("TELEFONO");
                Console.SetCursorPosition(10, 20); Console.Write("Digite 0 en el campo ID para salir de la captura...");


                Console.SetCursorPosition(21, 8); veterinario.Id = int.Parse(Console.ReadLine());
                if (veterinario.Id==0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 1); Console.Write("GRACIAS POR USAR PRODUCTOS JOHNP ....");
                    break;
                }
                Console.SetCursorPosition(21, 10); veterinario.Nombres= Console.ReadLine();
                Console.SetCursorPosition(21,12); veterinario.Direccion = Console.ReadLine();
                Console.SetCursorPosition(21, 14); veterinario.Telefono = Console.ReadLine();

                var mensaje=servicio.Guardar(veterinario);
                Console.Clear();
                Console.SetCursorPosition(30, 1); Console.Write(mensaje);
                Console.ReadKey();

            } while (true);
        }

        public void Menu()
        {
            int op;
            do
            {
                Console.Clear();
                Console.SetCursorPosition(30, 5); Console.Write("M E N U   V E T E R I N A R I O");

                Console.SetCursorPosition(32, 10); Console.Write("1. Capturar");
                Console.SetCursorPosition(32, 12); Console.Write("2. Consultar");
                Console.SetCursorPosition(32, 14); Console.Write("3. Actualizar");
                Console.SetCursorPosition(32, 16); Console.Write("4. Eliminar");

                Console.SetCursorPosition(32, 22); Console.Write("0. Salir");
                Console.SetCursorPosition(32, 24); Console.Write("Digite una opción: ");
                Console.SetCursorPosition(51, 24); op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Capturar();
                        break;
                    case 2:
                        Consultar();
                        break;
                    case 4:
                        Eliminar();
                        break;


                }

            } while (op !=0);
        }

        public void Consultar()
        {
            Console.Clear();
            var lista = servicio.Consultar();
            if(lista.Count == 0)
            {
                Console.SetCursorPosition(30, 1); Console.Write("No hay veterinarios registrados, pulse cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(30, 5); Console.Write("C O N S U L T A - V E T E R I N A R I O S");
            Console.SetCursorPosition(20, 8); Console.Write($"Total de veterinarios registrados: {lista.Count}");
            int y = 13;
            Console.SetCursorPosition(20, 10); Console.Write("--------------------------------------------------------------------------------");
            Console.SetCursorPosition(20, 11); Console.Write("ID");
            Console.SetCursorPosition(30, 11); Console.Write("NOMBRE");
            Console.SetCursorPosition(60, 11); Console.Write("DIRECCIÓN");
            Console.SetCursorPosition(90, 11); Console.Write("TELÉFONO");
            Console.SetCursorPosition(20, 10); Console.Write("--------------------------------------------------------------------------------");
            for (int i = 0; i < lista.Count; i++, y++)
            {
                Console.SetCursorPosition(20, y); Console.Write(lista[i].Id);
                Console.SetCursorPosition(30, y); Console.Write(lista[i].Nombres);
                Console.SetCursorPosition(60, y); Console.Write(lista[i].Direccion);
                Console.SetCursorPosition(90, y); Console.Write(lista[i].Telefono);
                Console.SetCursorPosition(20, y+1); Console.Write("--------------------------------------------------------------------------------");
            }
           
            Console.ReadKey();
        }

        public void Actualizar()
        {
            throw new NotImplementedException();
        }

        public void Eliminar()
        {
            Console.Clear();

            var lista = servicio.Consultar();
            int IdVeterinario;

            if (lista.Count == 0)
            {
                Console.SetCursorPosition(30, 1); Console.Write("No hay veterinarios registrados, pulse cualquier tecla para continuar...");
                Console.ReadKey();
                return;
            }
            Console.SetCursorPosition(30, 5); Console.Write("E L I M I N A R - V E T E R I N A R I O S");
            Console.SetCursorPosition(20, 8); Console.Write("Digite el ID del veterinario a eliminar: ");
            Console.SetCursorPosition(61, 8); IdVeterinario = int.Parse(Console.ReadLine());
            if (IdVeterinario < 1)
            {
                Console.SetCursorPosition(20, 15); Console.Write("ID inválido, debe ser un número entero positivo...");
                return;
            }

            var veterinarioEncontrado = servicio.BuscarPorId(IdVeterinario);

            if(veterinarioEncontrado != null)
            {
                Console.SetCursorPosition(20, 10); Console.Write("> Información del veterinario a eliminar:");
                Console.SetCursorPosition(20, 12); Console.Write($"Nombres: {veterinarioEncontrado.Nombres}");
                Console.SetCursorPosition(20, 13); Console.Write($"Dirección: {veterinarioEncontrado.Direccion}");
                Console.SetCursorPosition(20, 14); Console.Write($"Teléfono: {veterinarioEncontrado.Telefono}");
                Console.SetCursorPosition(10, 16); Console.Write("¿Estás seguro de eliminar este veterinario? Digite 1 para CONFIRMAR - 0 para CANCELAR: ");
                Console.SetCursorPosition(97, 16); int confirmacion = int.Parse(Console.ReadLine());
                switch (confirmacion)
                {
                    case 0:
                        Console.SetCursorPosition(20, 18); Console.Write("Eliminación cancelada, pulse cualquier tecla para continuar...");
                        break;
                    case 1:
                        bool eliminado = servicio.Eliminar(veterinarioEncontrado);
                        if (eliminado)
                        {
                            Console.SetCursorPosition(20, 18); Console.Write("Veterinario eliminado correctamente, pulse cualquier tecla para continuar...");
                        }
                        else
                        {
                            Console.SetCursorPosition(20, 18); Console.Write("Error al eliminar el veterinario, pulse cualquier tecla para continuar...");
                        }
                        break;
                    default:
                        Console.SetCursorPosition(20, 18); Console.Write("Opción inválida, pulse cualquier tecla para continuar...");
                        break;
                }
            }
            else
            {
                Console.SetCursorPosition(20, 18); Console.Write($"No se encontró un veterinario con ID {IdVeterinario}, pulse cualquier tecla para continuar...");
            }

            Console.ReadKey();
        }
    }
}
