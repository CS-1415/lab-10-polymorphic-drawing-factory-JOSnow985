using Lab09;

// List of instances of available factories, currently empty without concrete factories
List<IGraphic2DFactory> availableShapeTypes = [new RectangleFactory(), new CircleFactory()];

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
            AddGraphic();
            break;
        case '3':   // Remove Graphic
            RemoveGraphic();
            break;
        case '4':   // Exit
            Console.Clear();
            Console.WriteLine("Bye!");
            return;
        default:
            break;
    }
}


// --- Methods ---
void DisplayDrawing()
{
    Console.Clear();
    AbstractGraphic2D.Display(builtShapes);
    Console.ReadKey();
}

// Displays a list of available factories for the user to choose from,
// takes a user input and adds a new shape from that factory to the drawing.
void AddGraphic()
{
    Console.Clear();
    Console.WriteLine("Which shape do you want to add?");
    int i = 0;
    foreach (IGraphic2DFactory factory in availableShapeTypes)
    {
        Console.WriteLine($"[{i}] {factory.Name}");
        i++;
    }
    // Collect user index
    bool indexIsValid = false;
    while (!indexIsValid)
    {
        string userInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            if (Int32.TryParse(userInput.Trim(), out int selectedIndex))
            {
                if (selectedIndex >= 0 && selectedIndex < availableShapeTypes.Count)
                {
                    indexIsValid = true;
                    IGraphic2D newShape = availableShapeTypes[selectedIndex].Create();
                    builtShapes.Add(newShape);
                }
            }
        }
    }
}

// Displays the number of shapes in the drawing, user specifies an index to remove
void RemoveGraphic()
{
    Console.Clear();
    Console.WriteLine("What is the index of the shape you want to remove?");
    Console.WriteLine($"There are currently {builtShapes.Count} shapes in the drawing.");
    // Collect user index
    bool indexIsValid = false;
    while (!indexIsValid)
    {
        string userInput = Console.ReadLine()!;
        if (!string.IsNullOrWhiteSpace(userInput))
        {
            if (Int32.TryParse(userInput.Trim(), out int selectedIndex))
            {
                if (selectedIndex >= 0 && selectedIndex < builtShapes.Count)
                {
                    indexIsValid = true;
                    builtShapes.RemoveAt(selectedIndex);
                }
            }
        }
    }
}