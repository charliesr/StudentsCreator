using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    class Program
    {
        private enum OpcionPpal
        {
            newStudent = 1,
            salir = 2
        }

        static void Main(string[] args)
        {
            const string coma = ",";

            var opcionMenuPpal = Menu();
            while (opcionMenuPpal == OpcionPpal.newStudent)
            {
                var alumno = new Strudent();
                Console.WriteLine("Introduzca el ID");
                alumno.ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nombre:");
                alumno.Nombre = Console.ReadLine();

                Console.WriteLine("Apellidos");
                alumno.Apellidos = Console.ReadLine();

                Console.WriteLine("DNI");
                alumno.DNI = Console.ReadLine();

                var text = alumno.ID + coma + alumno.Nombre + coma + alumno.Apellidos+ coma+ alumno.DNI;
                File.AppendAllText("students.txt", text);
                File.AppendAllText("students.txt", "\r\n");
                opcionMenuPpal = Menu();

            }



        }

        private static OpcionPpal Menu()
        {
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1. Crear Alumno");
            Console.WriteLine("2. Salir");
            return (OpcionPpal) Convert.ToInt32(Console.ReadLine());

        }
    }
}
