namespace CalculatorEngine;

public class CalculationResult
{
    private double Result { get; set; }
    private bool IsSuccess { get; set; }
    private string Expression { get; set; } = "None";
    private string Error { get; set; } = "None";

    public void SetResult(double result)
    {
        Result = result;
    }

    public double GetResult()
    {
        return Result;
    }

    public void SetIsSuccess(bool success)
    {
        IsSuccess = success;
    }

    public bool GetIsSuccess()
    {
        return IsSuccess;
    }

    public void SetTwoOperandExpression(string operation, double firstNumber, double secondNumber, double result)
    {
        var fullExpression = "" + firstNumber + " " + operation + " " + secondNumber + " =\n" + result;
        Expression = fullExpression;
    }

    public void SetSingleOperandExpression(string operation, double number, double result)
    {
        var fullExpression = operation + "(" + number + ") =\n" + result;
        Expression = fullExpression;
    }

    public void SetDirectExpression(string expression)
    {
        Expression = expression;
    }

    public string GetExpression()
    {
        return Expression;
    }

    public void SetError(string message)
    {
        Error = message;
    }

    public string GetError()
    {
        return Error;
    }
    /// <summary>
    /// This function simply checks if a result that is passed to it is NaN or Pos/Neg Infinity, and returns true if
    /// the result passed is NaN or Pos/Neg Infinity. Returns false otherwise.
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public bool IsNotValidNumber(double number)
    {
        if (Double.IsNaN(number) || Double.IsInfinity(number))
        {
            return true;
        }

        return false;
    }
    
    /// <summary>
    /// Checks if the result of the object this function is called on is a valid number. If the result is Infinity or NaN
    /// returns true, otherwise returns false.
    /// </summary>
    /// <returns></returns>
    public bool IsNotValidNumber()
    {
        if (Double.IsNaN(Result) || Double.IsInfinity(Result))
        {
            return true;
        }

        return false;
    }
}