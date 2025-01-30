using CalculatorApp;
using NUnit.Framework;
namespace Calculator.Test.Unit;

public class CalculatorUnitTest{
    private Calc? _uut;

    [SetUp]
    public void Setup(){
        _uut = new Calc();
    }


    [Test]
    public void Add_AddTwoInts_SumIsCorrect(){
        // Arrange

        // Act
        double result = _uut.add(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(5.0));
    }
    [Test]
    public void Add_AddTwoFloats_SumIsCorrect(){
        // Arrange

        // Act
        double result = _uut.add(2.22, 3.33);

        // Assert
        Assert.That(result, Is.EqualTo(5.55).Within(0.01));
    }
    [Test]
    public void Add_SubtractTwofloat_SumIsCorrect(){
        // Arrange

        // Act
        double result = _uut.subtract(2, 3);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
    [Test]
    public void Add_SubtractTwofloats_SumIsCorrect(){
        // Arrange

        // Act
        double result = _uut.subtract(5.33, 2.11);

        // Assert
        Assert.That(result, Is.EqualTo(3.22).Within(0.01));
    }
}
