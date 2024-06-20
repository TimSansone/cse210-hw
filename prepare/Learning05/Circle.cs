// Derived class Circle
public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double ComputeArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override string GetShape()
    {
        return "Circle";
    }

    public override string GetColor()
    {
        return Color;
    }
}
