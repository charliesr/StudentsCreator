﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCreator
{
    class Program
    {
        public enum TipoArchivo
        {
            Json = 1,
            Txt = 2

        }

        private enum OpcionPpal
        {
            newStudent = 1,
            salir = 2,
            setFile = 3
        }

        static void Main(string[] args)
        {
            const string coma = ",";
            
            var opcionMenuPpal = Menu();
            while (opcionMenuPpal == OpcionPpal.newStudent)
            {

                switch (opcionMenuPpal)
                {
                    case OpcionPpal.newStudent:

                    case OpcionPpal.salir:

                    case OpcionPpal.setFile:
                    default:
                        break;
                }
                var alumno = new Student();
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
            Console.WriteLine("2. Escoger tipo de archivo");
            Console.WriteLine("3. Salir");
            return (OpcionPpal) Convert.ToInt32(Console.ReadLine());

        }
    }
}
