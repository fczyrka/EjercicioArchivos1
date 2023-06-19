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
            String Archivo = "archivos\\Datos1.txt";
            Datos1 = File.ReadAllLines(Archivo);
            String Archivo2 = "archivos\\Datos2.txt";
            Datos2 = File.ReadAllLines(Archivo2);

            ListaCompleta = new Alumno[Datos1.Length];

            int indicador = 0;
            int indicador2 = 0;

            for (int linea = 0; linea < Datos1.Length; linea++)
            {
               indicador = 0;
               indicador2 = 1;
               DatosSeparados = Datos1[linea].Split(",");
               DatosSeparados2 = Datos2[linea].Split(",");
               ListaCompleta[linea] = new Alumno();
               ListaCompleta[linea].Nombre = DatosSeparados[indicador];
               ListaCompleta[linea].Edad = Convert.ToInt32(DatosSeparados2[indicador2]);
               indicador++;
               indicador2++;
               ListaCompleta[linea].Nota = Convert.ToInt32(DatosSeparados[indicador]);
               ListaCompleta[linea].Ciudad = DatosSeparados2[indicador2];
            }
            ImprimiryGuardar();
        }

        public class Alumno
        {
            public string Nombre;
            public int Nota;
            public int Edad;
            public string Ciudad;
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

            using (StreamWriter writer = new StreamWriter("C:\\Users\\matia\\source\\repos\\Ejercicio de lectura de 2 archivos\\Listado De Estudiantes.txt"))
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
