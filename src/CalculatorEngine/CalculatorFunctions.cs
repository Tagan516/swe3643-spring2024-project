namespace CalculatorEngine;

public class CalculatorFunctions
{
    public CalculationResult Add(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-3
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber + secondNumber);
        finalResults.SetTwoOperandExpression("+", firstNumber, secondNumber, finalResults.GetResult());
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Subtract(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-4
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber - secondNumber);
        finalResults.SetTwoOperandExpression("-", firstNumber, secondNumber, finalResults.GetResult());
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Multiply(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-5
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber * secondNumber);
        finalResults.SetTwoOperandExpression("*", firstNumber, secondNumber, finalResults.GetResult());
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Divide(double numerator, double denominator)
    {
        //preq-ENGINE-7
        var finalResults = new CalculationResult();

        if (denominator == 0)
        {
            finalResults.SetError("Division by zero.");
            finalResults.SetIsSuccess(false);
            return finalResults;
        }
        
        finalResults.SetResult(numerator / denominator);
        finalResults.SetTwoOperandExpression("/", numerator, denominator, finalResults.GetResult());
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public int Equals(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-8
        double precision = 0.00000001;
        if (Math.Abs(firstNumber - secondNumber) < precision)
        {
            return 1;
        }

        return 0;
    }

    public CalculationResult RaiseToPower(double baseNumber, double exponent)
    {
        //preq-ENGINE-9
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Pow(baseNumber, exponent));
        finalResults.SetTwoOperandExpression("^", baseNumber, exponent, finalResults.GetResult());
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult LogOfNumber(double baseNumber, double newBase)
    {
        //preq-ENGINE-10
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Log(baseNumber, newBase));
        finalResults.SetTwoOperandExpression("log", baseNumber, newBase, finalResults.GetResult());
        if (Double.IsNaN(finalResults.GetResult()) || Double.IsInfinity(finalResults.GetResult()))
        {
            finalResults.SetError("Log cannot be defined.");
            finalResults.SetIsSuccess(false);
            return finalResults;
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }
    
    public CalculationResult RootOfNumber(double radicand, double radical)
    {
        //preq-ENGINE-11
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Pow(radicand, 1 / radical));
        finalResults.SetTwoOperandExpression("^ 1 /", radicand, radical, finalResults.GetResult());
        if (Double.IsNaN(finalResults.GetResult()) || Double.IsInfinity(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Root undefined");
            return finalResults;
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    private long CalculateFactorial(int a)
    {
        if (a == 0 || a == 1)
        {
            return 1;
        }

        return a * CalculateFactorial(a-1);
    }

    public CalculationResult Factorial(double a)
    {
        //preq-ENGINE-12
        var finalResults = new CalculationResult();
        if (a < 0)
        {
            finalResults.SetResult(0);
            finalResults.SetIsSuccess(false);
            finalResults.SetDirectExpression((a + "!"));
            finalResults.SetError("Factorials of negative numbers are undefined.");
            return finalResults;
        }
        int factorial = (int)Math.Round(a);
        finalResults.SetResult(CalculateFactorial(factorial));
        finalResults.SetIsSuccess(true);
        finalResults.SetDirectExpression((int)a + "!");

        return finalResults;
    }

    public CalculationResult Sine(double a)
    {
        //preq-ENGINE-13
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Sin(a));
        finalResults.SetSingleOperandExpression("sin", a, finalResults.GetResult());
        if (Double.IsNaN(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Cosine(double a)
    {
        //preq-ENGINE-14
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Cos(a));
        finalResults.SetSingleOperandExpression("cos", a, finalResults.GetResult());
        if (Double.IsNaN(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Tangent(double a)
    {
        //preq-ENGINE-15
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Tan(a));
        finalResults.SetSingleOperandExpression("tan", a, finalResults.GetResult());
        if (Double.IsNaN(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Reciprocal(double a)
    {
        //preq-ENGINE-16
        var finalResults = new CalculationResult();
        finalResults.SetDirectExpression("Reciprocal of " + a);
        if (a == 0)
        {
            finalResults.SetResult(Double.NaN);
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Cannot divide by zero.");
            return finalResults;
        }
        
        finalResults.SetResult((1 / a));
        finalResults.SetIsSuccess(true);
        return finalResults;
    }
}