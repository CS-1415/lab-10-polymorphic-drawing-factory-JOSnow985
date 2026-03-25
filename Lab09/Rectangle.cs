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