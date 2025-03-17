using System;
using System.Collections.Generic;

/*******************************************************
*                                                     *
*                  IObserver Interface                *
*  Dette interface definerer en metode til at modtage  *
*  opdateringer fra Subject-klassen.                  *
*                                                     *
*******************************************************/
public interface IObserver
{
    void Update(string message);
}

/*******************************************************
*                                                     *
*            Subject Abstrakt Klasse                  *
*  Denne klasse klasse står for at tilføje, fjerne og *
*    kalder funktion notify fra overstående klasse    *
*                                                     *
*******************************************************/
public abstract class Subject
{
    private readonly List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    protected void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

/*******************************************************
*                                                     *
*            ConcreteSubject Klasse                   *
*  Denne klasse repræsenterer et konkret Subject,      *
*  som ændrer sin tilstand og underretter observere.  *
*                                                     *
*******************************************************/
public class ConcreteSubject : Subject
{
    private string state;
    public string State
    {
        get => state;
        set
        {
            state = value;
            Notify("State changed to: " + state);
        }
    }
}

/*******************************************************
*                                                     *
*            ConcreteObserver Klasse                  *
*  Denne klasse repræsenterer en konkret Observer,     *
*  som reagerer på underretninger fra Subject.        *
*                                                     *
*******************************************************/
public class ConcreteObserver : IObserver
{
    private readonly string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"[{name}] received update: {message} updated by alarm system");
    }
}

namespace arraygen
{
    class arraygenerater1
    {
        public int[] arraygenerater(int size, int seed)
        {
            int[] arr = new int[size];
            Random rand = new Random(seed);

            for (int i = 0; i < size; i++)
            {
                arr[i] = rand.Next(1, 100); // Generates a random number between 1 (inclusive) and 100 (exclusive)
            }

            return arr;
        }
    }

    class arraygeneraterSorter : IObserver
    {
        private int[] arr;

        public arraygeneraterSorter(int[] arr)
        {
            this.arr = arr;
        }

        public void Update(string message)
        {
            if (message.Contains("array_generated"))
            {
                Console.WriteLine($" {message} updated by alarm system");
                Array.Sort(arr);
                Console.WriteLine("Array sorted:");
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                   
                }
                
            }

           
        }

    }

        class arraygeneraterReverseSorter : IObserver
    {
        private int[] arr;

        public arraygeneraterReverseSorter(int[] arr)
        {
            this.arr = arr;
        }
           public void Update(string message)
        {
            if (message.Contains("Array_sorted"))
            {
                Console.WriteLine($" {message} updated by alarm system");
                Array.Sort(arr, (a, b) => b.CompareTo(a));  
                Console.WriteLine("Array sorted:");
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                   
                }
            }

        
        }}


        
    

    public class Program
    {
        public static void Main(string[] args)
        {
            var subject = new ConcreteSubject();

        

            arraygenerater1 generator = new arraygenerater1();
            int[] generatedArray = generator.arraygenerater(10, 1);




            IObserver sorter = new arraygeneraterSorter(generatedArray);
            IObserver reverseSorter = new arraygeneraterReverseSorter(generatedArray); // sådan det virker er at man tilføjer iobserver inhertance, se classen Sorter
            subject.Attach(sorter); 
            subject.Attach(reverseSorter); 

            foreach (int i in generatedArray)
            {
                System.Console.WriteLine(i);
            }

            subject.State = "array_generated"; 

            subject.State = "Array_sorted"; 

            
        }
    }
}