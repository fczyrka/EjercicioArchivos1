using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Ejercicio_de_lectura_de_2_archivos
{

    class Program
    {

        /*
         * 
         Funciòn que abre archivo
        Función que recorra los arrays devueltos y use el NOMBRE (característica igual para unificar los datos) 
        Acá puedo usar una clase Alumno que se vaya instanciando por cada vuelta del for y complete los datos de cada alumno).
        Ordenar todas las instancias en un nuevo array tipo Alumno
         */




        static Alumno[] ListaCompleta;
        static string[] Datos1;
        static string[] Datos2;
        static string[] DatosSeparados;
        static string[] DatosSeparados2;

        static void Main(string[] args)
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

            // imprimir el alumno de mayor edad

            OrdenarAlfabeticamente();
            ImprimiryGuardar();

        }



        public class Alumno
        {
            public string Nombre;
            public int Nota;
            public int Edad;
            public string Ciudad;
        }

        static void OrdenarAlfabeticamente()
        {
            for (int PosicionQueVoyAComparar = 0; PosicionQueVoyAComparar < ListaCompleta.Length;PosicionQueVoyAComparar++) 
            {
                Alumno AlumnoActual = ListaCompleta[PosicionQueVoyAComparar];
                for (int ConLoQueEstoyComparando = 0; ConLoQueEstoyComparando < ListaCompleta.Length - 1;ConLoQueEstoyComparando++)
                {
                    Alumno AlumnoConElQueComparo = ListaCompleta[ConLoQueEstoyComparando];
                    if (AlumnoActual.Nombre.CompareTo(AlumnoConElQueComparo.Nombre) > 0)
                    {
                        Alumno Temporal = AlumnoActual;
                        ListaCompleta[PosicionQueVoyAComparar] = AlumnoConElQueComparo;
                        ListaCompleta[ConLoQueEstoyComparando] = Temporal;
                        AlumnoActual = AlumnoConElQueComparo; 
                    }
                }
            }
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
        }

        

    }
}
