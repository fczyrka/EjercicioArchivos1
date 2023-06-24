using System;
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
        static int EleccionDelUsuario = 0;

        static void Main(string[] args)
        {
            CargarDatos();

            while (EleccionDelUsuario != 5)
            {
                MenuPrincipal();

                if (EleccionDelUsuario == 1)
                {
                    ModificarDatos();
                }
                if (EleccionDelUsuario == 2)
                {
                    OrdenarAlfabeticamente();
                }
                if (EleccionDelUsuario == 4)
                {
                    ImprimiryGuardar();
                }
                if (EleccionDelUsuario == 5)
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
            Console.WriteLine("   Presione 4 para ver el listado y Guardar los datos   ");
            Console.WriteLine("       ");
            Console.WriteLine("   Presione 5 para salir   ");

            EleccionDelUsuario = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine(" Presione " + (i+1) + " para editar datos de " + ListaCompleta[i].Nombre);               
            }
            int seleccion = 0;
            seleccion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            if (seleccion == 1)
            {
                Alumno AlumnoElegido = ListaCompleta[seleccion-1];
                int EleccionParaEditar;
                Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                Console.WriteLine("     ");
                EleccionParaEditar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (EleccionParaEditar == 1)
                {
                    Console.WriteLine(" Escriba el nuevo Nombre y Apellido  ");
                    ListaCompleta[seleccion-1].Nombre = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 2)
                {
                    Console.WriteLine(" Escriba la Nota en números  ");
                    ListaCompleta[seleccion - 1].Nota = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 3)
                {
                    Console.WriteLine(" Escriba la Edad en números  ");
                    ListaCompleta[seleccion - 1].Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();

                }
                if (EleccionParaEditar == 4)
                {
                    Console.WriteLine(" Escriba la nueva Ciudad  ");
                    ListaCompleta[seleccion - 1].Ciudad = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            if (seleccion == 2)
            {
                Alumno AlumnoElegido = ListaCompleta[seleccion - 1];
                int EleccionParaEditar;
                Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                Console.WriteLine("     ");
                EleccionParaEditar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                Console.WriteLine("     ");
                Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                Console.ReadKey();
                Console.Clear();

                if (EleccionParaEditar == 1)
                {
                    Console.WriteLine(" Escriba el nuevo Nombre y Apellido  ");
                    ListaCompleta[seleccion - 1].Nombre = Console.ReadLine();
                    Console.Clear();
                }
                if (EleccionParaEditar == 2)
                {
                    Console.WriteLine(" Escriba la Nota en números  ");
                    ListaCompleta[seleccion - 1].Nota = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                if (EleccionParaEditar == 3)
                {
                    Console.WriteLine(" Escriba la Edad en números  ");
                    ListaCompleta[seleccion - 1].Edad = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                }
                if (EleccionParaEditar == 4)
                {
                    Console.WriteLine(" Escriba la nueva Ciudad  ");
                    ListaCompleta[seleccion - 1].Ciudad = Console.ReadLine();
                    Console.Clear();
                }
            }

            if (seleccion == 3)
            {
                Alumno AlumnoElegido = ListaCompleta[seleccion - 1];
                int EleccionParaEditar;
                Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                Console.WriteLine("     ");
                EleccionParaEditar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (EleccionParaEditar == 1)
                {
                    Console.WriteLine(" Escriba el nuevo Nombre y Apellido  ");
                    ListaCompleta[seleccion - 1].Nombre = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 2)
                {
                    Console.WriteLine(" Escriba la Nota en números  ");
                    ListaCompleta[seleccion - 1].Nota = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 3)
                {
                    Console.WriteLine(" Escriba la Edad en números  ");
                    ListaCompleta[seleccion - 1].Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 4)
                {
                    Console.WriteLine(" Escriba la nueva Ciudad  ");
                    ListaCompleta[seleccion - 1].Ciudad = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            if (seleccion == 4)
            {
                Alumno AlumnoElegido = ListaCompleta[seleccion - 1];
                int EleccionParaEditar;
                Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                Console.WriteLine("     ");
                EleccionParaEditar = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (EleccionParaEditar == 1)
                {
                    Console.WriteLine(" Escriba el nuevo Nombre y Apellido  ");
                    ListaCompleta[seleccion - 1].Nombre = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 2)
                {
                    Console.WriteLine(" Escriba la Nota en números  ");
                    ListaCompleta[seleccion - 1].Nota = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 3)
                {
                    Console.WriteLine(" Escriba la Edad en números  ");
                    ListaCompleta[seleccion - 1].Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (EleccionParaEditar == 4)
                {
                    Console.WriteLine(" Escriba la nueva Ciudad  ");
                    ListaCompleta[seleccion - 1].Ciudad = Console.ReadLine();
                    Console.WriteLine(" Presione 1 para editar Nombre " + AlumnoElegido.Nombre);
                    Console.WriteLine(" Presione 2 para editar Nota " + AlumnoElegido.Nota);
                    Console.WriteLine(" Presione 3 para editar Edad " + AlumnoElegido.Edad);
                    Console.WriteLine(" Presione 4 para editar Ciudad " + AlumnoElegido.Ciudad);
                    Console.WriteLine("     ");
                    Console.WriteLine("      Presione cualquier tecla para volver al menú    ");
                    Console.ReadKey();
                    Console.Clear();
                }
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
