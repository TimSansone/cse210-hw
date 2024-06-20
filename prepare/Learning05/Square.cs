// Derived class Square
public class Square : Shape
{
    public double Side { get; set; }

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double ComputeArea()
    {
        return Side * Side;
    }

    public override string GetShape()
    {
        return "Square";
    }

    public override string GetColor()
    {
        return Color;
    }
}
