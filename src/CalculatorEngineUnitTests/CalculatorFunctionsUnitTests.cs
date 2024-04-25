using CalculatorEngine;
namespace CalculatorEngineUnitTests;


public class Tests
{
    private readonly CalculatorFunctions _calculator = new CalculatorFunctions();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Divide_TwoPositiveWholeNumbers_ReturnsCorrectAnswer()
    {
        //preq-UNIT-TEST-5
        
        //arrange
        double numerator = 25.0d;
        double denominator = 5.0d;

        //act
        CalculationResult divisionResult = _calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_NegativeDivisionWithWholeNumbers_ReturnsCorrectAnswer()
    {
        //preq-UNIT-TEST-5
        
        //arrange
        double numerator = -25.0d;
        double denominator = 5.0d;

        //act
        CalculationResult divisionResult = _calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_PositiveFloatingPointDivision_ReturnsCorrectAnswer()
    {
        //preq-UNIT-TEST-5
        
        //arrange
        double numerator = 5.74d;
        double denominator = 1.3d;

        //act
        CalculationResult divisionResult = _calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_DivisionByZero_ReturnsPositiveInfinity()
    {
        //preq-UNIT-TEST-6
        
        //arrange
        double numerator = 10.0d;
        double denominator = 0.0d;

        //act
        CalculationResult divisionResult = _calculator.Divide(numerator, denominator);

        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(numerator/denominator));
    }

    [Test]
    public void Divide_NegativeDivisionByZero_ReturnsNegativeInfinity()
    {
        //preq-UNIT-TEST-6
        //arrange
        double numerator = -5.0d;
        double denominator = 0.0d;
        double negInfinity = Double.NegativeInfinity;
        
        //act
        CalculationResult divisionResult = _calculator.Divide(numerator, denominator);
        
        //assert
        Assert.That(divisionResult.GetResult(), Is.EqualTo(negInfinity));
    }

    [Test]
    public void Add_TwoValidNumbers_ReturnsAnswer()
    {
        //preq-UNIT-TEST-2
        
        //arrange
        double firstNumber = 3.75d;
        double secondNumber = 5.25d;
        
        //act
        CalculationResult additionResult = _calculator.Add(firstNumber, secondNumber);
        
        //assert
        Assert.That(additionResult.GetResult(), Is.EqualTo(firstNumber + secondNumber));
    }

    [Test]
    public void Add_ValidNumberAndNaN_ReturnsNaN()
    {
        //preq-UNIT-TEST-2
        
        //arrange
        double firstNumber = 1.55;
        double secondNumber = Double.NaN;
        
        //act
        CalculationResult additionResult = _calculator.Add(firstNumber, secondNumber);
        
        //assert
        Assert.That(additionResult.GetResult(), Is.EqualTo(firstNumber + secondNumber));
    }

    [Test]
    public void Add_ValidNumberAndInfinity_ReturnsInfinity()
    {
        //preq-UNIT-TEST-2
        
        //arrange
        double firstNumber = 2.2222;
        double secondNumber = Double.PositiveInfinity;
        
        //act
        CalculationResult additionResult = _calculator.Add(firstNumber, secondNumber);
        
        //assert
        Assert.That(additionResult.GetResult(), Is.EqualTo(firstNumber + secondNumber));
    }
    
    [Test]
    public void Add_PosAndNegInfinity_ReturnsNaN()
    {
        //preq-UNIT-TEST-2
        
        //arrange
        double firstNumber = Double.NegativeInfinity;
        double secondNumber = Double.PositiveInfinity;
        
        //act
        CalculationResult additionResult = _calculator.Add(firstNumber, secondNumber);
        
        //assert
        Assert.That(additionResult.GetResult(), Is.EqualTo(Double.NaN));
    }

    [Test]
    public void Subtract_TwoValidNumbers_ReturnsAnswer()
    {
        //arrange
        double firstNumber = 5.83;
        double secondNumber = 9.22;
        
        //act
        CalculationResult subtractionResult = _calculator.Subtract(firstNumber, secondNumber);
        
        //assert
        Assert.That(subtractionResult.GetResult(), Is.EqualTo(firstNumber - secondNumber));
    }

    [Test]
    public void Subtract_ValidNumberAndInfinity_ReturnsInfinity()
    {
        //preq-UNIT-TEST-3
        
        //arrange
        double firstNumber = 4.8991;
        double secondNumber = Double.PositiveInfinity;
        double expectedAnswer = Double.NegativeInfinity;
        
        //act
        CalculationResult subtractionResult = _calculator.Subtract(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
            {
                Assert.That(subtractionResult.GetResult(), Is.EqualTo(expectedAnswer));
                Assert.That(subtractionResult.GetIsSuccess(), Is.EqualTo(false));
                Assert.That(subtractionResult.GetError(), Is.EqualTo("Answer is undefined."));
            }
        );
    }

    [Test]
    public void Subtract_ValidNumberAndNaN_ReturnsNan()
    {
        //preq-UNIT-TEST-3
        
        //arrange
        double firstNumber = 5.82;
        double secondNumber = Double.NaN;
        
        //act
        CalculationResult subtractionResult = _calculator.Subtract(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(subtractionResult.GetResult(), Is.EqualTo(firstNumber - secondNumber));
            Assert.That(subtractionResult.GetIsSuccess, Is.EqualTo(false));
            Assert.That(subtractionResult.GetError(), Is.EqualTo("Answer is undefined."));
        });
    }

    [Test]
    public void Multiply_TwoValidNumbers_ReturnsAnswer()
    {
        //preq-UNIT-TEST-4
        
        //arrange
        double firstNumber = 5.44;
        double secondNumber = 2.56;
        
        //act
        CalculationResult multiplyResult = _calculator.Multiply(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(multiplyResult.GetResult(), Is.EqualTo(firstNumber * secondNumber));
            Assert.That(multiplyResult.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(multiplyResult.GetError(), Is.EqualTo("None"));
            Assert.That(multiplyResult.GetExpression(), Is.EqualTo((firstNumber + " * " + secondNumber + " = " + multiplyResult.GetResult())));
        });
    }

    [Test]
    public void Multiply_ValidNumberAndInfinity_ReturnsInfinity()
    {
        //preq-UNIT-TEST-4
        
        //arrange
        double firstTestNumber = 4.50;
        double secondTestNumber = 8.1;
        double posInfinity = Double.PositiveInfinity;
        Double negInfinity = Double.NegativeInfinity;
        
        //act
        CalculationResult firstMultiplyResult = _calculator.Multiply(firstTestNumber, posInfinity);
        CalculationResult secondMultiplyResult = _calculator.Multiply(secondTestNumber, negInfinity);
        
        //assert
        Assert.Multiple(() =>
        {
            //Assertions for test scenario with posInfinity
            Assert.That(firstMultiplyResult.GetResult(), Is.EqualTo(Double.PositiveInfinity));
            Assert.That(firstMultiplyResult.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(firstMultiplyResult.GetError(), Is.EqualTo("Answer is undefined."));
            Assert.That(firstMultiplyResult.GetExpression(), Is.EqualTo(firstTestNumber + " * " + posInfinity + " = " + firstMultiplyResult.GetResult()));
            
            //Assertions for test scenario with negInfinity
            Assert.That(secondMultiplyResult.GetResult(), Is.EqualTo(Double.NegativeInfinity));
            Assert.That(secondMultiplyResult.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(secondMultiplyResult.GetError(), Is.EqualTo("Answer is undefined."));
            Assert.That(secondMultiplyResult.GetExpression(), Is.EqualTo(secondTestNumber + " * " + negInfinity + " = " + secondMultiplyResult.GetResult()));
        });
    }

    [Test]
    public void Equals_TwoEqualNumbers_ReturnsOne()
    {
        //preq-UNIT-TEST-7
        
        //arrange
        double firstNumber = 5.12345678910;
        double secondNumber = 5.12345678109;
        
        //act
        CalculationResult result = _calculator.Equals(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(1));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(firstNumber + " == " + secondNumber + " = " + result.GetResult()));
        });
    }

    [Test]
    public void Equals_TwoNotEqualNumbers_ReturnsZero()
    {
        //preq-UNIT-TEST-7
        
        //arrange
        double firstNumber = 1.12345678910;
        double secondNumber = 1.12345687910;
        
        //act
        CalculationResult result = _calculator.Equals(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(0));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(firstNumber + " == " + secondNumber + " = " + result.GetResult()));
        });
    }

    [Test]
    public void Equals_InvalidNumber_ReturnsZeroAndError()
    {
        //preq-UNIT-TEST-7
        
        //arrange
        double firstNumber = Double.NaN;
        double secondNumber = 14.5656737;
        
        //act
        CalculationResult result = _calculator.Equals(firstNumber, secondNumber);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(0));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Cannot evaluate equality for these entries."));
        });
    }

    [Test]
    public void RaiseToPower_TwoValidNumbers_ReturnsAnswer()
    {
        //preq-UNIT-TEST-8
        
        //arrange
        double baseNumber = 5.0;
        double exponent = 2.0;
        
        //act
        CalculationResult result = _calculator.RaiseToPower(baseNumber, exponent);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(25.0d));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(baseNumber + " ^ " + exponent + " = " + result.GetResult()));
        });
    }

    [Test]
    public void RaiseToPower_InvalidNumber_ReturnsError()
    {
        //preq-UNIT-TEST-8
        
        //arrange
        double firstBaseNumber = Double.NaN;
        double secondBaseNumber = Double.NegativeInfinity;
        double thirdBaseNumber = 5.0d;
        double firstExponent = 3.0d;
        double secondExponent = 2.0d;
        double thirdExponent = Double.NaN;
        
        //act
        CalculationResult firstResult = _calculator.RaiseToPower(firstBaseNumber, firstExponent);
        CalculationResult secondResult = _calculator.RaiseToPower(secondBaseNumber, secondExponent);
        CalculationResult thirdResult = _calculator.RaiseToPower(thirdBaseNumber, thirdExponent);
        
        //assert
        Assert.Multiple(() =>
        {
            //first test scenario
            Assert.That(firstResult.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(firstResult.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(firstResult.GetError(), Is.EqualTo("Answer is undefined."));
            
            //second test scenario
            Assert.That(secondResult.GetResult(), Is.EqualTo(Double.PositiveInfinity));
            Assert.That(secondResult.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(secondResult.GetError(), Is.EqualTo("Answer is undefined."));
            
            //third test scenario
            Assert.That(thirdResult.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(thirdResult.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(thirdResult.GetError(), Is.EqualTo("Answer is undefined."));
        });
    }

    [Test]
    public void LogOfNumber_TwoValidNumbers_ReturnsAnswer()
    {
        //preq-UNIT-TEST-9
        
        //arrange
        double baseNumber = 8.0d;
        double newBase = 2.0d;
        double expectedAnswer = Math.Log(baseNumber, newBase);
        
        //act
        CalculationResult result = _calculator.LogOfNumber(baseNumber, newBase);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(expectedAnswer));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(baseNumber + " log " + newBase + " = " + result.GetResult()));
        });
    }

    [Test]
    public void LogOfNumber_InvalidBaseNumber_ReturnsError()
    {
        //preq-UNIT-TEST-10
        
        //arrange
        double baseNumber = 0.0d;
        double newBase = 2.0d;
        
        //act
        CalculationResult result = _calculator.LogOfNumber(baseNumber, newBase);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.NegativeInfinity));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(result.GetExpression(), Is.EqualTo(baseNumber + " log " + newBase + " = " + result.GetResult()));
        });
    }
    
    [Test]
    public void LogOfNumber_InvalidNewBaseNumber_ReturnsError()
    {
        //preq-UNIT-TEST-11
        
        //arrange
        double baseNumber = 8.0d;
        double newBase = 0.0d;
        
        //act
        CalculationResult result = _calculator.LogOfNumber(baseNumber, newBase);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(result.GetExpression(), Is.EqualTo(baseNumber + " log " + newBase + " = " + result.GetResult()));
        });
    }

    [Test]
    public void RootOfNumber_TwoValidNumbers_ReturnsAnswer()
    {
        //preq-UNIT-TEST-12
        
        //arrange
        double radicand = 25.0d;
        double radical = 2.0d;
        
        //act
        CalculationResult result = _calculator.RootOfNumber(radicand, radical);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(5.0d));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(radicand + " ^ 1 / " + radical + " = " + result.GetResult()));
        });
    }

    [Test]
    public void RootOfNumber_OneInvalidNumber_ReturnsError()
    {
        //preq-UNIT-TEST-13
        
        //arrange
        double radicand = 25.0d;
        double radical = 0.0d;
        
        //act
        CalculationResult result = _calculator.RootOfNumber(radicand, radical);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.PositiveInfinity));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Root undefined"));
        });
    }

    [Test]
    public void Factorial_ValidNumber_ReturnsAnswer()
    {
        //preq-UNIT-TEST-14
        
        //arrange
        double factorial = 5.1d;
        int roundedFactorial = (int)Math.Round(factorial);
        
        //act
        CalculationResult result = _calculator.Factorial(factorial);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(120.0d));
            Assert.That(result.GetIsSuccess(), Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo(roundedFactorial + "! = " + result.GetResult()));
        });
    }

    [Test]
    public void Factorial_InvalidNegativeNumber_ReturnsError()
    {
        //preq-UNIT-TEST-14
        
        //arrange
        double factorial = -5.0d;
        
        //act
        CalculationResult result = _calculator.Factorial(factorial);
        
        //assert
        Assert.That(result.GetResult(), Is.EqualTo(0));
        Assert.That(result.GetIsSuccess, Is.EqualTo(false));
        Assert.That(result.GetError(), Is.EqualTo("Factorials of negative numbers are undefined."));
    }
    
    [Test]
    public void Factorial_Convention_ReturnsOne()
    {
        //preq-UNIT-TEST-15
        
        //arrange
        double factorial = 0.0d;
        int roundedFactorial = (int)Math.Round(factorial);
        
        //act
        CalculationResult result = _calculator.Factorial(factorial);
        
        //assert
        Assert.That(result.GetResult(), Is.EqualTo(1.0d));
        Assert.That(result.GetIsSuccess, Is.EqualTo(true));
        Assert.That(result.GetExpression(), Is.EqualTo(roundedFactorial + "! = " + result.GetResult()));
    }

    [Test]
    public void Sine_ValidNumber_ReturnsAnswer()
    {
        //preq-UNIT-TEST-16
        
        //arrange
        double angle = 90.0d;
        
        //act
        CalculationResult result = _calculator.Sine(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Math.Sin(angle)));
            Assert.That(result.GetIsSuccess, Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo("sin(" + angle + ") = " + result.GetResult()));
        });
    }

    [Test]
    public void Sine_InvalidNumber_ReturnsError()
    {
        //preq-UNIT-TEST-16
        
        //arrange
        double angle = Double.NaN;
        
        //act
        CalculationResult result = _calculator.Sine(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(result.GetIsSuccess, Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Angle is not a number."));
        });
    }

    [Test]
    public void Cosine_ValidAngle_ReturnsAnswer()
    {
        //preq-UNIT-TEST-17
        
        //arrange
        double angle = 450.0d;
        
        //act
        CalculationResult result = _calculator.Cosine(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Math.Cos(angle)));
            Assert.That(result.GetIsSuccess, Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo("cos(" + angle + ") = " + result.GetResult()));
        });
    }

    [Test]
    public void Cosine_InvalidAngle_ReturnsError()
    {
        //preq-UNIT-TEST-17
        
        //arrange
        double angle = Double.NaN;
        
        //act
        CalculationResult result = _calculator.Cosine(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(result.GetIsSuccess, Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Angle is not a number."));
        });
    }
    
    [Test]
    public void Tangent_ValidAngle_ReturnsAnswer()
    {
        //preq-UNIT-TEST-18
        
        //arrange
        double angle = 450.0d;
        
        //act
        CalculationResult result = _calculator.Tangent(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Math.Tan(angle)));
            Assert.That(result.GetIsSuccess, Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo("tan(" + angle + ") = " + result.GetResult()));
        });
    }

    [Test]
    public void Tangent_InvalidAngle_ReturnsError()
    {
        //preq-UNIT-TEST-18
        
        //arrange
        double angle = Double.NaN;
        
        //act
        CalculationResult result = _calculator.Tangent(angle);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.NaN));
            Assert.That(result.GetIsSuccess, Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Angle is not a number."));
        });
    }

    [Test]
    public void Reciprocal_ValidNumber_ReturnsAnswer()
    {
        //preq-UNIT-TEST-19
        
        //arrange
        double number = 5.0d;
        
        //act
        CalculationResult result = _calculator.Reciprocal(number);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo((1.0d/number)));
            Assert.That(result.GetIsSuccess, Is.EqualTo(true));
            Assert.That(result.GetExpression(), Is.EqualTo("Reciprocal of " + number + " = " + result.GetResult()));
        });
    }
    
    [Test]
    public void Reciprocal_invalidNumber_ReturnsAnswer()
    {
        //preq-UNIT-TEST-20
        
        //arrange
        double number = 0.0d;
        
        //act
        CalculationResult result = _calculator.Reciprocal(number);
        
        //assert
        Assert.Multiple(() =>
        {
            Assert.That(result.GetResult(), Is.EqualTo(Double.PositiveInfinity));
            Assert.That(result.GetIsSuccess, Is.EqualTo(false));
            Assert.That(result.GetError(), Is.EqualTo("Reciprocal is undefined."));
        });
    }
}