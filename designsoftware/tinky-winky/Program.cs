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
            // Når state ændres, underret alle Observers
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


public class Program
{
    public static void Main(string[] args)
    {
        var subject = new ConcreteSubject();

        IObserver observer1 = new ConcreteObserver("tvinkie");
        IObserver observer2 = new ConcreteObserver("Vinky");
        IObserver observer3 = new ConcreteObserver("lala");
        IObserver observer4 = new ConcreteObserver("Poh");

        subject.Attach(observer1);
        subject.Attach(observer2);
        subject.Attach(observer3);
        subject.Attach(observer4);

        subject.State = "Gesper er en lille gigget";
        //subject.State = "forsent små gigget";

        /*
        subject.Detach(observer3);
        subject.State = "Again";

        */
}
}   