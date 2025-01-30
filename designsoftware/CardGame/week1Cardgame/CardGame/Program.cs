using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography.X509Certificates;

public class Cards
{
    // herunder defineres først variablerne
    public string Suit { private set; get; }
    public int Number { get; set; }

    public Cards(string suit, int number)
    {
        Suit = suit;
        Number = number;
    }

    public int calculateValue()
    {
        int multipliervalue = 0;
        if (Suit == "blue")
            multipliervalue = 2;
        if (Suit == "red")
            multipliervalue = 1;
        if (Suit == "green")
            multipliervalue = 3;
        if (Suit == "yellow")
            multipliervalue = 4;

        return Number * multipliervalue;
    }
}

public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public List<Cards> Hand { get; set; }

    public Player(string name)
    {
        Name = name;
        Score = 0;
        Hand = new List<Cards>();
    }

    public void DrawCard()
    {
        Hand.Add(randomCard());
    }

    public void CalculateScore()
    {
        Score = 0;
        foreach (var card in Hand)
        {
            Score += card.calculateValue();
        }
    }

    public static Cards randomCard()
    {
        Random random = new Random();
        List<string> suits = new List<string> { "blue", "red", "green", "yellow" };
        int randomSuit = random.Next(0, suits.Count);
        int randomNumber = random.Next(1, 14);
        return new Cards(suits[randomSuit], randomNumber);
    }

    public void showhand()
    {
        foreach (var card in Hand)
        {
            Console.WriteLine($"Suit: {card.Suit}, Number: {card.Number}");
        }
    }
}

public class Deck
{
    public List<Cards> Cards { get; set; }

    public Deck()
    {
        Cards = new List<Cards>();
        foreach (var suit in new List<string> { "blue", "red", "green", "yellow" })
        {
            for (int i = 1; i < 14; i++)
            {
                Cards.Add(new Cards(suit, i));
            }
        }
    }

    public Cards deal()
    {
        Cards card = Cards[0];
        Cards.RemoveAt(0);
        return card;
    }
}

public class Game
{
    public List<Player> Players { get; set; }
    public Deck Deck { get; set; }

    public Game()
    {
        Players = new List<Player>();
        Deck = new Deck();
    }

    public void AddPlayer(string name)
    {
        Players.Add(new Player(name));
    }

    public void StartGame()
    {
        foreach (var player in Players)
        {
            player.DrawCard();
            player.DrawCard();
            player.CalculateScore();
        }
    }

    public void ShowHands()
    {
        foreach (var player in Players)
        {
            Console.WriteLine($"Player: {player.Name}");
            player.showhand();
            Console.WriteLine($"Score: {player.Score}");
        }
    }

    public void ShowWinner()
    {
        Player winner = Players[0];
        foreach (var player in Players)
        {
            if (player.Score > winner.Score)
            {
                winner = player;
            }
        }
        Console.WriteLine($"The winner is: {winner.Name}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Game cardGame = new Game();

        // Add players
        cardGame.AddPlayer("Alice");
        cardGame.AddPlayer("Bob");

        // Start the game
        cardGame.StartGame();

        // Show hands and scores
        cardGame.ShowHands();

        // Show the winner
        cardGame.ShowWinner();
    }
}
