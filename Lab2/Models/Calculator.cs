public class Calculator
{
    public double? X { get; set; }
    public double? Y { get; set; }
    public string Operator { get; set; }
    public bool DivideByZero { get; private set; } = false;

    public bool IsValid()
    {
        return X.HasValue && Y.HasValue && !string.IsNullOrEmpty(Operator);
    }

    public string GetOperatorSymbol()
    {
        return Operator switch
        {
            "add" => "+",
            "sub" => "-",
            "mul" => "*",
            "div" => "/",
            _ => ""
        };
    }

    public double Calculate()
    {
        if (Operator == "div" && Y == 0)
        {
            DivideByZero = true;
            return double.NaN;
        }

        return Operator switch
        {
            "add" => X.Value + Y.Value,
            "sub" => X.Value - Y.Value,
            "mul" => X.Value * Y.Value,
            "div" => X.Value / Y.Value,
            _ => double.NaN,
        };
    }
}