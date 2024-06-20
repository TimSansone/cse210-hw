// Derived class Rectangle
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(string color, double width, double height) : base(color)
    {
        Width = width;
        Height = height;
    }

    public override double ComputeArea()
    {
        return Width * Height;
    }

    public override string GetShape()
    {
        return "Rectangle";
    }

    public override string GetColor()
    {
        return Color;
    }
}
