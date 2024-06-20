using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.Clear();
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the list
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 3, 6));
        shapes.Add(new Circle("Green", 5));

        // Iterate through the list and display the shape type, color, and areas
        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape Type: {shape.GetShape()}, Color: {shape.GetColor()}, Area: {shape.ComputeArea():F2}");
        }
    }
}
