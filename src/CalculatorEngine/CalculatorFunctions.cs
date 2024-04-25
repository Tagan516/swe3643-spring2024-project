namespace CalculatorEngine;

public class CalculatorFunctions
{
    public CalculationResult Add(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-3
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber + secondNumber);
        finalResults.SetTwoOperandExpression("+", firstNumber, secondNumber, finalResults.GetResult());
        
        if (finalResults.IsNotValidNumber(finalResults.GetResult()))
        {
            finalResults.SetError("Answer is undefined.");
            finalResults.SetIsSuccess(false);
            return finalResults;
        }
        
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Subtract(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-4
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber - secondNumber);
        finalResults.SetTwoOperandExpression("-", firstNumber, secondNumber, finalResults.GetResult());

        if (finalResults.IsNotValidNumber(finalResults.GetResult()))
        {
            finalResults.SetError("Answer is undefined.");
            finalResults.SetIsSuccess(false);
            return finalResults;
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Multiply(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-5
        var finalResults = new CalculationResult();
        finalResults.SetResult(firstNumber * secondNumber);
        finalResults.SetTwoOperandExpression("*", firstNumber, secondNumber, finalResults.GetResult());

        if (finalResults.IsNotValidNumber(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Answer is undefined.");
            return finalResults;
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Divide(double numerator, double denominator)
    {
        //preq-ENGINE-7
        var finalResults = new CalculationResult();
        finalResults.SetResult((numerator / denominator));
        finalResults.SetTwoOperandExpression("/", numerator, denominator, finalResults.GetResult());
        
        if (finalResults.IsNotValidNumber(finalResults.GetResult()))
        {
            finalResults.SetError("Answer is undefined.");
            finalResults.SetIsSuccess(false);
            return finalResults;
        }
        
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Equals(double firstNumber, double secondNumber)
    {
        //preq-ENGINE-8
        CalculationResult finalResult = new CalculationResult();
        if (finalResult.IsNotValidNumber(firstNumber) || finalResult.IsNotValidNumber(secondNumber))
        {
            finalResult.SetResult(0);
            finalResult.SetIsSuccess(false);
            finalResult.SetError("Cannot evaluate equality for these entries.");
            return finalResult;
        }
        
        double precision = 0.00000001;
        if (Math.Abs(firstNumber - secondNumber) < precision)
        {
            finalResult.SetResult(1);
            finalResult.SetIsSuccess(true);
            finalResult.SetTwoOperandExpression("==", firstNumber, secondNumber, finalResult.GetResult());
            return finalResult;
        }
        
        finalResult.SetResult(0);
        finalResult.SetIsSuccess(true);
        finalResult.SetTwoOperandExpression("==", firstNumber, secondNumber, finalResult.GetResult()); 
        return finalResult;
    }

    public CalculationResult RaiseToPower(double baseNumber, double exponent)
    {
        //preq-ENGINE-9
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Pow(baseNumber, exponent));
        finalResults.SetTwoOperandExpression("^", baseNumber, exponent, finalResults.GetResult());

        if (finalResults.IsNotValidNumber(finalResults.GetResult()))
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Answer is undefined.");
            return finalResults;
        }

        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult LogOfNumber(double baseNumber, double newBase)
    {
        //preq-ENGINE-10
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Log(baseNumber, newBase));
        finalResults.SetTwoOperandExpression("log", baseNumber, newBase, finalResults.GetResult());
        if (finalResults.IsNotValidNumber())
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
        if (finalResults.IsNotValidNumber())
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
            finalResults.SetDirectExpression((a + "! =\n Not a number"));
            finalResults.SetError("Factorials of negative numbers are undefined.");
            return finalResults;
        }
        int factorial = (int)Math.Round(a);
        finalResults.SetResult(CalculateFactorial(factorial));
        finalResults.SetIsSuccess(true);
        finalResults.SetDirectExpression((int)a + "! = " + finalResults.GetResult());

        return finalResults;
    }

    public CalculationResult Sine(double a)
    {
        //preq-ENGINE-13
        var finalResults = new CalculationResult();
        finalResults.SetResult(Math.Sin(a));
        finalResults.SetSingleOperandExpression("sin", a, finalResults.GetResult());
        if (finalResults.IsNotValidNumber())
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
            return finalResults;
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
        if (finalResults.IsNotValidNumber())
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
            return finalResults;
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
        if (finalResults.IsNotValidNumber())
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Angle is not a number.");
            return finalResults;
        }
        finalResults.SetIsSuccess(true);
        return finalResults;
    }

    public CalculationResult Reciprocal(double a)
    {
        //preq-ENGINE-16
        var finalResults = new CalculationResult();
        finalResults.SetResult((1.0d / a));
        finalResults.SetDirectExpression("Reciprocal of " + a + " =\n" + finalResults.GetResult());
        if (finalResults.IsNotValidNumber())
        {
            finalResults.SetIsSuccess(false);
            finalResults.SetError("Reciprocal is undefined.");
            return finalResults;
        }
        
        finalResults.SetIsSuccess(true);
        return finalResults;
    }
}