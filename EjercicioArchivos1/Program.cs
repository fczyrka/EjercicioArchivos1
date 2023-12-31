﻿using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Ejercicio_de_lectura_de_2_archivos
{

    class Program
    {
        static Alumno[] ListaCompleta;
        static string[] Datos1;
        static string[] Datos2;
        static string[] DatosSeparados;
        static string[] DatosSeparados2;
        static string EleccionDelUsuario;
        static int seleccion = 0;

        static void Main(string[] args)
        {
            CargarDatos();

            while (EleccionDelUsuario != "6")
            {
                EleccionDelUsuario = "0";
                MenuPrincipal();

                if (EleccionDelUsuario == "1")
                {
                    ModificarDatos();
                }
                if (EleccionDelUsuario == "2")
                {
                    OrdenarAlfabeticamente();
                }
                if (EleccionDelUsuario == "3")
                {
                    AgregarAlumnoNuevo();
                    CargarDatos();
                }
                if (EleccionDelUsuario == "4")
                {
                    EliminarAlumno();
                    
                }
                if (EleccionDelUsuario == "5")
                {
                    ImprimiryGuardar();
                }
                if (EleccionDelUsuario == "6")
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
        }



        public class Alumno
        {
            public string Nombre;
            public int Nota;
            public int Edad;
            public string Ciudad;
        }
        static void MenuPrincipal()
        {
            Console.WriteLine("       ");
            Console.WriteLine("       ");
            Console.WriteLine("         Nenú Principal     ");
            Console.WriteLine("       ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 1 para Modificar datos   ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 2 para Ver la lista de datos en orden alfabético      ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 3 para Agregar Alumnos nuevos   ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 4 para Eliminar un Alumnos   ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 5 para ver el listado y Guardar los datos   ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 6 para salir   ");
            
            
            while (EleccionDelUsuario != "1" && EleccionDelUsuario != "2" && EleccionDelUsuario != "3" && EleccionDelUsuario != "4" && EleccionDelUsuario != "5")
            {
            Console.WriteLine("    ");
            Console.WriteLine("    ");
            Console.WriteLine("Seleccione una opción disponible");
            EleccionDelUsuario = Console.ReadLine();
            Console.Clear();
           
            }
        }

        static void CargarDatos()
        {
            String Archivo = "C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos1.txt";
            Datos1 = File.ReadAllLines(Archivo);
            String Archivo2 = "C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos2.txt";
            Datos2 = File.ReadAllLines(Archivo2);

            ListaCompleta = new Alumno[Datos1.Length];

            for (int linea = 0; linea < Datos1.Length; linea++)
            {
                DatosSeparados = Datos1[linea].Split(",");

                Alumno alumnoActual = new Alumno();
                alumnoActual.Nombre = DatosSeparados[0];
                alumnoActual.Nota = Convert.ToInt32(DatosSeparados[1]);

                ListaCompleta[linea] = alumnoActual;
            }

            Alumno alumnoConMayorEdad = ListaCompleta[0];
            for (int AlumnoActual = 0; AlumnoActual < ListaCompleta.Length; AlumnoActual++)
            {
                Alumno alumnoAlCualCargarleMasDatos = ListaCompleta[AlumnoActual];

                for (int PosicionArchivo2 = 0; PosicionArchivo2 < Datos2.Length; PosicionArchivo2++)
                {
                    DatosSeparados2 = Datos2[PosicionArchivo2].Split(",");

                    if (DatosSeparados2[0] == alumnoAlCualCargarleMasDatos.Nombre)
                    {
                        alumnoAlCualCargarleMasDatos.Edad = Convert.ToInt32(DatosSeparados2[1]);
                        alumnoAlCualCargarleMasDatos.Ciudad = DatosSeparados2[2];
                    }
                }

                if (alumnoConMayorEdad.Edad < alumnoAlCualCargarleMasDatos.Edad)
                {
                    alumnoConMayorEdad = alumnoAlCualCargarleMasDatos;
                }
            }

        }

        static void ModificarDatos()
        {
            Console.Clear();
            for (int i = 0; i < ListaCompleta.Length; i++)
            {
                Console.WriteLine(" Presione " + (i + 1) + " para editar datos de " + ListaCompleta[i].Nombre);
            }

            seleccion = Convert.ToInt32(Console.ReadLine());
            Alumno AlumnoElegido = ListaCompleta[seleccion - 1];
            Console.Clear();
            EdiciónDeParametros(AlumnoElegido);

            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos1.txt"))
            {
                for (int i = 0; i < ListaCompleta.Length; i++)
                {
                    writer.WriteLine(ListaCompleta[i].Nombre + "," + ListaCompleta[i].Nota);
                }
                
                writer.Close();
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos2.txt"))
            {
                for (int i = 0; i < ListaCompleta.Length; i++)
                {
                    writer.WriteLine(ListaCompleta[i].Nombre + "," + ListaCompleta[i].Edad + "," + ListaCompleta[i].Ciudad);
                }
                writer.Close();
            }

            static void EdiciónDeParametros(Alumno AlumnoElegido)
            {
                int EleccionParaEditar;

                Console.WriteLine(" Presione 1 para editar el Nombre ");
                Console.WriteLine(" Presione 2 para editar la Nota ");
                Console.WriteLine(" Presione 3 para editar la Edad ");
                Console.WriteLine(" Presione 4 para editar la Ciudad ");
                Console.WriteLine(" -------------------------------- ");
                EleccionParaEditar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                if (EleccionParaEditar == 1)
                {
                    Console.WriteLine(" Escriba el nuevo Nombre y Apellido  ");
                    AlumnoElegido.Nombre = Console.ReadLine();
                }

                if (EleccionParaEditar == 2)
                {
                    Console.WriteLine(" Escriba la nueva Calificación  ");
                    AlumnoElegido.Nota = Convert.ToInt32(Console.ReadLine());
                }

                if (EleccionParaEditar == 3)
                {
                    Console.WriteLine(" Escriba la Edad del Alumno/a  ");
                    AlumnoElegido.Edad = Convert.ToInt32(Console.ReadLine());
                }

                if (EleccionParaEditar == 4)
                {
                    Console.WriteLine(" Escriba la nueva Ciudad  ");
                    AlumnoElegido.Ciudad = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine(" Nombre:  " + AlumnoElegido.Nombre);
                Console.WriteLine(" Nota:    " + AlumnoElegido.Nota);
                Console.WriteLine(" Edad:    " + AlumnoElegido.Edad);
                Console.WriteLine(" Ciudad   " + AlumnoElegido.Ciudad);
                Console.WriteLine("    ");
                Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void OrdenarAlfabeticamente()
        {
            // en este primer for, la variable no la vamos a usar, es solo para que de las suficientes vueltas y en cada vuelta se haga lo del for que está dentro
            for (int i = 0; i < ListaCompleta.Length; i++)
            {
                // acá hago hasta -2 porque voy a comparar con el siguiente, entonces sinó me fallaría al final
                for (int posicionAComparar = 0; posicionAComparar < ListaCompleta.Length - 2; posicionAComparar++)
                {
                    //acá pongo directamente los arrays porque me queda mas claro, porque sinó es mas dificil de entender
                    if (ListaCompleta[posicionAComparar].Nombre.CompareTo(ListaCompleta[posicionAComparar + 1].Nombre) > 0)
                    {
                        Alumno Temporal = ListaCompleta[posicionAComparar + 1];
                        ListaCompleta[posicionAComparar + 1] = ListaCompleta[posicionAComparar];
                        ListaCompleta[posicionAComparar] = Temporal;


                    }
                }
            }
            ImprimirListado();
            
        }

        static void AgregarAlumnoNuevo()
        {
         Alumno NuevoAlumno = new Alumno();

            Console.WriteLine(" Ingrese el Nombre del Alumno nuevo ");
            NuevoAlumno.Nombre = Console.ReadLine();
            Console.WriteLine(" ");
            Console.WriteLine(" Ingrese la Nota del Alumno nuevo ");
            NuevoAlumno.Nota = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine(" Ingrese la Edad del Alumno nuevo ");
            NuevoAlumno.Edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");
            Console.WriteLine(" Ingrese la Ciudad del Alumno nuevo ");
            NuevoAlumno.Ciudad = Console.ReadLine();
            Console.WriteLine(" ");

            Alumno[] ListaParaAgregar = new Alumno[(ListaCompleta.Length + 1)];
            for (int i = 0; i < ListaCompleta.Length; i++)
            {
                ListaParaAgregar[i] = ListaCompleta[i];
            }
            ListaParaAgregar[ListaParaAgregar.Length-1] = NuevoAlumno;

            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos1.txt"))
            {
                for (int i = 0; i < ListaParaAgregar.Length ; i++)
                {
                    writer.WriteLine(ListaParaAgregar[i].Nombre + "," + ListaParaAgregar[i].Nota);
                }

                writer.Close();
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos2.txt"))
            {
                for (int i = 0; i < (ListaParaAgregar.Length); i++)
                {
                    writer.WriteLine(ListaParaAgregar[i].Nombre + "," + ListaParaAgregar[i].Edad + "," + ListaParaAgregar[i].Ciudad);
                }
                writer.Close();
            }
            Console.WriteLine("   ");
            Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
            Console.ReadKey();

        }

        static void EliminarAlumno()
        {
            Console.Clear();
            for (int i = 0; i < ListaCompleta.Length; i++)
            {
                Console.WriteLine(" Presione " + (i + 1) + " para eliminar a " + ListaCompleta[i].Nombre);
            }

            seleccion = Convert.ToInt32(Console.ReadLine());
            Alumno AlumnoEnblanco = new Alumno();
            ListaCompleta[seleccion - 1] = AlumnoEnblanco;
            for (int i = 0; i < ListaCompleta.Length;i++)
            {
                if (ListaCompleta[i] == AlumnoEnblanco && i == ListaCompleta.Length-1)
                {
                    break;
                }
                if (ListaCompleta[i] == AlumnoEnblanco && i < ListaCompleta.Length)
                {

                    int contador = i;
                    ListaCompleta[i] = ListaCompleta[contador + 1];
                    ListaCompleta[contador] = AlumnoEnblanco;
                }               
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos1.txt"))
            {
                for (int i = 0; i < ListaCompleta.Length; i++)
                {
                    if (ListaCompleta[i] != AlumnoEnblanco)
                    {
                        writer.WriteLine(ListaCompleta[i].Nombre + "," + ListaCompleta[i].Nota);
                    }
                }

                writer.Close();
            }
            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\datos2.txt"))
            {
                for (int i = 0; i < ListaCompleta.Length; i++)
                {
                    if (ListaCompleta[i] != AlumnoEnblanco)
                    {
                        writer.WriteLine(ListaCompleta[i].Nombre + "," + ListaCompleta[i].Edad + "," + ListaCompleta[i].Ciudad);
                    }
                }
                writer.Close();
            }
        }

            static void ImprimirListado()
            {
                Console.WriteLine("      ");
                Console.WriteLine("      ");
                Console.WriteLine("               Listado de Estudiantes ");
                Console.WriteLine("      ");
                Console.WriteLine("      ");
                for (int vueltas = 0; vueltas < ListaCompleta.Length; vueltas++)
                {
                    Console.WriteLine("    Estudiante:   " + ListaCompleta[vueltas].Nombre);
                    Console.WriteLine("    Calificación: " + ListaCompleta[vueltas].Nota);
                    Console.WriteLine("    Edad:         " + ListaCompleta[vueltas].Edad + " años ");
                    Console.WriteLine("    Ciudad:       " + ListaCompleta[vueltas].Ciudad);
                    Console.WriteLine("      ");
                    Console.WriteLine("    ---------------------------------     ");
                }
                Console.WriteLine("   ");
                Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                Console.ReadKey();
            }

            static void ImprimiryGuardar()
            {
                Console.WriteLine("      ");
                Console.WriteLine("      ");
                Console.WriteLine("               Listado de Estudiantes ");
                Console.WriteLine("      ");
                Console.WriteLine("      ");
                for (int vueltas = 0; vueltas < ListaCompleta.Length; vueltas++)
                {
                    Console.WriteLine("    Estudiante:   " + ListaCompleta[vueltas].Nombre);
                    Console.WriteLine("    Calificación: " + ListaCompleta[vueltas].Nota);
                    Console.WriteLine("    Edad:         " + ListaCompleta[vueltas].Edad + " años ");
                    Console.WriteLine("    Ciudad:       " + ListaCompleta[vueltas].Ciudad);
                    Console.WriteLine("      ");
                    Console.WriteLine("    ---------------------------------     ");
                }

                using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\Source\\Repos\\fczyrka\\EjercicioArchivos1\\EjercicioArchivos1\\archivos\\Listado De Estudiantes.txt"))
                {

                    writer.WriteLine("      ");
                    writer.WriteLine("      ");
                    writer.WriteLine("               Listado de Estudiantes ");
                    writer.WriteLine("      ");
                    writer.WriteLine("      ");
                    for (int vueltas = 0; vueltas < ListaCompleta.Length; vueltas++)
                    {
                        writer.WriteLine("    Estudiante:   " + ListaCompleta[vueltas].Nombre);
                        writer.WriteLine("    Calificación: " + ListaCompleta[vueltas].Nota);
                        writer.WriteLine("    Edad:         " + ListaCompleta[vueltas].Edad + " años ");
                        writer.WriteLine("    Ciudad:       " + ListaCompleta[vueltas].Ciudad);
                        writer.WriteLine("      ");
                        writer.WriteLine("    ---------------------------------     ");
                    }
                    writer.Close();
                }
                Console.WriteLine("   ");
                Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                Console.ReadKey();
            }



    }
}


