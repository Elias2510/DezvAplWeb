using System;
using System.Collections.Generic;

public class Materie
{
    public string Titlu { get; set; }
    public string Durata { get; set; }

    public Materie(string titlu, string durata)
    {
        Titlu = titlu;
        Durata = durata;
    }
}

public class Student
{
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public List<Materie> Materii { get; set; }

    public Student(string nume, string prenume)
    {
        Nume = nume;
        Prenume = prenume;
        Materii = new List<Materie>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var student1 = new Student("Elias", "Milosi");
        student1.Materii.Add(new Materie("Matematica", "2 ore"));
        student1.Materii.Add(new Materie("Fizica", "1.5 ore"));

        var student2 = new Student("Ana", "Alexandrescu");
        student2.Materii.Add(new Materie("Limba engleză", "1.5 ore"));
        student2.Materii.Add(new Materie("Istorie", "1.0 ore"));

        var listaStudenti = new List<Student> { student1, student2 };

        foreach (var student in listaStudenti)
        {
            Console.WriteLine($"Nume: {student.Nume}, Prenume: {student.Prenume}");
            Console.WriteLine("Materii:");
            foreach (var materie in student.Materii)
            {
                Console.WriteLine($"  Titlu: {materie.Titlu}, Durata: {materie.Durata}");
            }
            Console.WriteLine();
        }
    }
}
