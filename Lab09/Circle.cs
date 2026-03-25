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