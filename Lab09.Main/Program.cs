using Lab09;

// List of instances of available factories, currently empty without concrete factories
List<IGraphic2DFactory> availableShapeTypes = [];

// List of shapes constituting the drawing
List<IGraphic2D> builtShapes = [];

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to a drawing program that will allow the user (that's you!) to draw or modify an existing drawing!\nMain Menu:");
    Console.WriteLine("");
    Console.WriteLine("[1] Display Drawing\n[2] Add Graphic\n[3] Remove Graphic\n[4] Exit");
    switch (Console.ReadKey(true).KeyChar)
    {
        case '1':   // Display Drawing
            DisplayDrawing();
            break;
        case '2':   // Add Graphic
            break;
        case '3':   // Remove Graphic
            break;
        case '4':   // Exit
            return;
        default:
            break;
    }
}

void DisplayDrawing()
{
    Console.Clear();
    AbstractGraphic2D.Display(builtShapes);
    Console.ReadLine();
}