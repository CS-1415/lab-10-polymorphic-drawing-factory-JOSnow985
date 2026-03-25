using Lab09;

Console.Clear();
Console.WriteLine("Welcome to a drawing program that will allow the user (that's you!) to draw or modify an existing drawing!");

// List of instances of available factories, currently empty without concrete factories
List<IGraphic2DFactory> availableShapeTypes = [];

// List of shapes constituting the drawing
List<IGraphic2D> builtShapes = [];