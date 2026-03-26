namespace Lab09;

// Interface for a factory that generates a particular type of shape
public interface IGraphic2DFactory
{
    // A string describing what type of shape this factory builds
    string Name { get; }

    // No parameters, returns an object of type IGraphic2D
    IGraphic2D Create();
}