namespace Lab09;

public class Rectangle : AbstractGraphic2D
{
    public override decimal LowerBoundX => Left;
    public override decimal UpperBoundX => Left + Width;
    public override decimal LowerBoundY => Top;
    public override decimal UpperBoundY => Top + Height;
    public decimal Left {get; private set;} = 0;
    public decimal Top {get; private set;} = 0;
    public decimal Width {get; private set;} = 1;
    public decimal Height {get; private set;} = 1;
    
    public Rectangle(decimal left, decimal top, decimal width, decimal height)
    {
        Left = left;
        Top = top;
        Width = width;
        Height = height;
    }

    public override bool ContainsPoint(decimal x, decimal y) => LowerBoundX <= x && x <= UpperBoundX && LowerBoundY <= y && y <= UpperBoundY;
}

public class RectangleFactory : IGraphic2DFactory
{
    public string Name => "Rectangle";

    public IGraphic2D Create()
    {
        List<decimal> values = [];

        for (int x = 0; x < 4; x++)
        {
            bool inputAccepted = false;
            while (!inputAccepted)
            {
                Console.Write("Please enter a decimal value for the ");
                // Print an instruction based on the value we're asking for
                switch (x)
                {
                    case 0:
                        Console.WriteLine("Left boundary of the new rectangle, it must be 0 or greater.");
                        break;
                    case 1:
                        Console.WriteLine("Top boundary of the new rectangle, it must be 0 or greater.");
                        break;
                    case 2:
                        Console.WriteLine("Width of the new rectangle, it must be greater than 0.");
                        break;
                    case 3:
                        Console.WriteLine("Height of the new rectangle, it must be greater than 0.");
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

        return new Rectangle(values[0], values[1], values[2], values[3]) { DisplayChar = ' ', BackgroundColor = ConsoleColor.White, ForegroundColor = ConsoleColor.Black };
    }
}