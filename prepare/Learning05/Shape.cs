// Base class Shape
public abstract class Shape
{
    public string Color { get; set; }

    public Shape(string color)
    {
        Color = color;
    }

    // Abstract method to compute area
    public abstract double ComputeArea();

    // Abstract method to get the shape type
    public abstract string GetShape();

    // Abstract method to get the color of the shape
    public abstract string GetColor();
}