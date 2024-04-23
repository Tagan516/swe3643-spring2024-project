using CalculatorEngine;
namespace CalculatorEngineUnitTests;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Divide_TwoPositiveWholeNumbers_ReturnsCorrectAnswer()
    {
        //arrange
        CalculatorFunctions calculator = new CalculatorFunctions();
        double numerator = 25;
        double denominator = 5;

        //act
        CalculationResult divisionResult = calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_NegativeDivisionWithWholeNumbers_ReturnsCorrectAnswer()
    {
        //arrange
        CalculatorFunctions calculator = new CalculatorFunctions();
        double numerator = -25;
        double denominator = 5;

        //act
        CalculationResult divisionResult = calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_PositiveFloatingPointDivision_ReturnsCorrectAnswer()
    {
        //arrange
        CalculatorFunctions calculator = new CalculatorFunctions();
        double numerator = 5.74;
        double denominator = 1.3;

        //act
        CalculationResult divisionResult = calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_DivisionByZero_ReturnsPositiveInfinity()
    {
        //arrange
        CalculatorFunctions calculator = new CalculatorFunctions();
        double numerator = 10;
        double denominator = 0;

        //act
        CalculationResult divisionResult = calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_NegativeDivisionByZero_ReturnsNegativeInfinity()
    {
        //arrange
        CalculatorFunctions calculator = new CalculatorFunctions();
        double numerator = -5;
        double denominator = 0;
        double negInfinity = Double.NegativeInfinity;
        
        //act
        CalculationResult divisionResult = calculator.Divide(numerator, denominator);
        
        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(negInfinity));
    }

}