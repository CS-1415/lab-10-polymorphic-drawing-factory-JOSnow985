namespace Lab09;

// Represents a graphical element (i.e. a shape) that can be printed to the
// console.
public interface IGraphic2DFactory
{
    // A string describing what type of graphic will be built
    string Name { get; }

    // draws the graphic on the screen; return true if successful
    bool Display();

    // creates a new graphic object
    IGraphic2D Create();
}