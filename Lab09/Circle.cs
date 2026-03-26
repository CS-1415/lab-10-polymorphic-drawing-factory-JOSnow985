namespace Lab09;

public class Circle : AbstractGraphic2D
{
    public override decimal LowerBoundX => CenterX - Radius;
    public override decimal UpperBoundX => CenterX + Radius;
    public override decimal LowerBoundY => CenterY - Radius;
    public override decimal UpperBoundY => CenterY + Radius;
    public decimal CenterX {get; private set;} = 1;
    public decimal CenterY {get; private set;} = 1;
    public decimal Radius {get; private set;} = 1;
    public Circle(decimal center_x, decimal center_y, decimal radius)
    {
        CenterX = center_x;
        CenterY = center_y;
        Radius = radius;
    }

    public override bool ContainsPoint(decimal x, decimal y)
    {
        decimal deltaX = x - CenterX;
        decimal deltaY = y - CenterY;
        decimal distanceToCenterSquared = (deltaX * deltaX) + (deltaY * deltaY);
        decimal squaredRadius = Radius * Radius;
        return distanceToCenterSquared <= squaredRadius;
    }
}

public class CircleFactory : IGraphic2DFactory
{
    public string Name => "Circle";

    public IGraphic2D Create()
    {
        List<decimal> values = [];

        for (int x = 0; x < 3; x++)
        {
            bool inputAccepted = false;
            while (!inputAccepted)
            {
                Console.Write("Please enter a decimal value for the ");
                // Print an instruction based on the value we're asking for
                switch (x)
                {
                    case 0:
                        Console.WriteLine("X coordinate of the center of the new circle, it must be 0 or greater.");
                        break;
                    case 1:
                        Console.WriteLine("Y coordinate of the center of the new circle, it must be 0 or greater.");
                        break;
                    case 2:
                        Console.WriteLine("Radius of the new circle, it must be greater than 0.");
                        break;
                }

                // Check if we get valid decimal and if it matches the conditions for the value we need
                if(Decimal.TryParse(Console.ReadLine()?.Trim(), out decimal userInput))
                {
                    if (x < 2)  // Left and Top need values 0 or greater
                    {
                        if (userInput >= 0)
                        {
                            inputAccepted = true;
                            values.Add(userInput);
                        }
                    }
                    else        // Width and Height need values greater than 0
                    {
                        if (userInput > 0)
                        {
                            inputAccepted = true;
                            values.Add(userInput);
                        }
                    }
                    
                }
            }
        }

        return new Circle(values[0], values[1], values[2]) { DisplayChar = ' ', BackgroundColor = ConsoleColor.Blue, ForegroundColor = ConsoleColor.Black };
    }
}