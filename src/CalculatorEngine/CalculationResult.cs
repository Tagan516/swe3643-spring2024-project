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

    public bool GetSuccess()
    {
        return IsSuccess;
    }

    public void SetTwoOperandExpression(string operation, double firstNumber, double secondNumber, double result)
    {
        var fullExpression = "" + firstNumber + " " + operation + " " + secondNumber + " = " + result;
        Expression = fullExpression;
    }

    public void SetSingleOperandExpression(string operation, double number, double result)
    {
        var fullExpression = operation + "(" + number + ") = " + result;
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
}