namespace Kata.Tests;
using NUnit.Framework;
using Kata;

public class UnitTest1
{
     private Class1? _uut;
     

    public UnitTest1()
    {
    }

    [SetUp]
    public void Setup(){
        _uut = new Class1(10000); // Assuming an initial balance of 10000
    }


    [Test]
    public void Withdrawl()
    {
        // Arrange
        double amount = 1000; // Example amount to withdraw
        double initialBalance = _uut.Balance; // Assuming Class1 has a Balance property
         _uut.Withdrawl(amount); // Assuming withdrawl method returns the new balance
        double expectedBalance = initialBalance - amount;
        // Assert
        Assert.That(_uut.Balance, Is.EqualTo(expectedBalance));
    }
    

    [Test]
    public void Deposit()
    {
        // Arrange
        double amount = 1000; // Example amount to deposit
        double initialBalance = _uut.Balance; // Assuming Class1 has a Balance property
         _uut.Deposit(amount); // Assuming deposit method returns the new balance
        double expectedBalance = initialBalance + amount;
        // Assert
        Assert.That(_uut.Balance, Is.EqualTo(expectedBalance));
    }}