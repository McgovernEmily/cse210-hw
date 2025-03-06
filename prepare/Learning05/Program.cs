using System;

class Program
{
    static void Main(string[] args)
    {
        // This is what will hold all the shapes to a list.
        List<Shape> shapes = new List<Shape>();

        // Where to get the square area.
        Square num = new Square("Blue", 5);
        shapes.Add(num);

        // Where to get the rectangle area.
        Rectangle num2 = new Rectangle("Chocolate", 5 , 5);
        shapes.Add(num2);

        // Where to get the circle area.
        Circle num3 = new Circle("Purple", 2);
        shapes.Add(num3);

        // Goes through all the shapes I added into the list and finds the color and shape.
        foreach (Shape i in shapes)
        {
            string color = i.GetColor();

            double area = i.GetArea();

            Console.WriteLine($"Color is {color}, area is {area}");
        }

    }
}