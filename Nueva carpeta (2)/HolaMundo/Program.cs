using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen
{
    public abstract class Persona
    {
        public Guid Id { get; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        protected Persona(string nombre, int edad)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Edad = edad;
        }

        public abstract void MostrarInfo();
    }

    public class Estudiante : Persona
    {
        public decimal Promedio { get; set; }

        public Estudiante(string nombre, int edad, decimal promedio) : base(nombre, edad)
        {
            Promedio = promedio;
        }

        public override void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Edad: {Edad}");
            Console.WriteLine($"Promedio: {Promedio}");
        }
    }

    public class Curso
    {
        public string NombreCurso { get; set; }
        public List<Estudiante> ListaEstudiantes { get; set; }

        public Curso(string nombreCurso)
        {
            NombreCurso = nombreCurso;
            ListaEstudiantes = new List<Estudiante>();
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            ListaEstudiantes.Add(estudiante);
        }

        public void MostrarEstudiantes()
        {
            Console.WriteLine($"--- Estudiantes en el curso: {NombreCurso} ---");
            foreach (var estudiante in ListaEstudiantes)
            {
                estudiante.MostrarInfo();
                Console.WriteLine("--------------------");
            }
        }

        public List<Estudiante> ObtenerMejoresEstudiantes()
        {
            return ListaEstudiantes.Where(e => e.Promedio >= 8).ToList();
        }

        public List<Estudiante> ObtenerEstudiantesReprobados()
        {
            return ListaEstudiantes.Where(e => e.Promedio < 8).ToList();
        }

        public (decimal Promedio, List<Estudiante> Estudiantes) PromedioGrupo()
        {
            if (ListaEstudiantes.Count == 0)
            {
                return (0, new List<Estudiante>());
            }

            decimal promedioGrupo = ListaEstudiantes.Average(e => e.Promedio);
            List<Estudiante> estudiantesConPromedioMayorOIgual = ListaEstudiantes.Where(e => e.Promedio >= promedioGrupo).ToList();
            return (promedioGrupo, estudiantesConPromedioMayorOIgual);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Estudiante estudiante1 = new Estudiante("Diego David Nava", 20, 9.5m);
            Estudiante estudiante2 = new Estudiante("Sebastian Mancilla", 22, 7.2m);
            Estudiante estudiante3 = new Estudiante("Bello Chino", 21, 8.0m);

            Curso cursoProgramacion = new Curso("Programación Avanzada");

            cursoProgramacion.AgregarEstudiante(estudiante1);
            cursoProgramacion.AgregarEstudiante(estudiante2);
            cursoProgramacion.AgregarEstudiante(estudiante3);

            cursoProgramacion.MostrarEstudiantes();

            Console.WriteLine(@"--- Mejores Estudiantes (Promedio >= 8) ---");
            List<Estudiante> mejores = cursoProgramacion.ObtenerMejoresEstudiantes();
            foreach (var est in mejores)
            {
                Console.WriteLine($"- {est.Nombre} (Promedio: {est.Promedio})");
            }

            Console.WriteLine(@"--- Estudiantes Reprobados (Promedio < 8) ---");
            List<Estudiante> reprobados = cursoProgramacion.ObtenerEstudiantesReprobados();
            foreach (var est in reprobados)
            {
                Console.WriteLine($"- {est.Nombre} (Promedio: {est.Promedio})");
            }

            var resultadoPromedio = cursoProgramacion.PromedioGrupo();
            Console.WriteLine(@"--- Promedio del Grupo ---");
            Console.WriteLine($"El promedio general del curso es: {resultadoPromedio.Promedio:F2}");
            Console.WriteLine(@"Estudiantes con promedio igual o superior al del grupo:");
            foreach (var est in resultadoPromedio.Estudiantes)
            {
                Console.WriteLine($"- {est.Nombre} (Promedio: {est.Promedio})");
            }
        }
    }
}