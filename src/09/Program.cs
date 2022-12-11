var ropeMoves = File.ReadAllLines("./rope_moves");

var head = (X: 0, Y: 0);
var tail = (X: 0, Y: 0);

var positionsVisitedByTail = new HashSet<(int X, int Y)>();

var maxX = 0;
var minX = 0;
var maxY = 0;
var minY = 0;

void UpdateGridSize()
{
    if (head.X > maxX)
        maxX = head.X;

    else if (head.X < minX)
        minX = head.X;

    if (head.Y > maxY)
        maxY = head.Y;

    else if (head.Y < minY)
        minY = head.Y;
}

string GetDirectionEmoji(char direction) => direction switch
{
    'D' => "⬇️",
    'U' => "⬆️",
    'L' => "⬅️",
    'R' => "➡️",
    _ => "🏁"
};

int MoveHead(char direction) => direction switch
{
    'L' => head.X--,
    'R' => head.X++,
    'D' => head.Y--,
    'U' => head.Y++
};


void MoveTail()
{
    var diffX = head.X - tail.X;
    var diffY = head.Y - tail.Y;
    
    var absX = Math.Abs(diffX);
    var absY = Math.Abs(diffY);

    if (absX > 1 || absY > 1)
    {
        tail.Y += Math.Sign(diffY);
        tail.X += Math.Sign(diffX);
    }
}

char GetCharacterToPrint(int x, int y)
{
    var character = '•';

    // Origo
    if (y.Equals(0) && x.Equals(0))
        character = 'o';

    // Tail
    if (tail.Y.Equals(y) && tail.X.Equals(x))
        character = 'T';

    // Head
    if (head.Y.Equals(y) && head.X.Equals(x))
        character = 'H';

    return character;
}

void PrintGrid(char direction)
{
    UpdateGridSize();
    Console.WriteLine($"Head at X: {head.X}, Y: {head.Y}");
    Console.WriteLine($"Tail at X: {tail.X}, Y: {tail.Y}");
    Console.WriteLine($"Direction: {GetDirectionEmoji(direction)}");
    Console.WriteLine("=================================");
#if DEBUG
    Console.WriteLine("");

    for (var y = maxY; y >= minY; y--)
    {
        for (var x = minX; x <= maxX - minX; x++)
        {
            Console.Write(GetCharacterToPrint(x, y));
        }

        Console.WriteLine();
    }

    Console.WriteLine("");
    Console.WriteLine("=================================");
#endif

    Console.WriteLine("");
}

PrintGrid('_');

foreach (var ropeMove in ropeMoves)
{
    var direction = ropeMove[0];
    var length = int.Parse(ropeMove[2..]);

    for (var i = 0; i < length; i++)
    {
        MoveHead(direction);
        MoveTail();
        PrintGrid(direction);
        positionsVisitedByTail.Add((tail.X, tail.Y));
    }
}

Console.WriteLine($"09 Part one: {positionsVisitedByTail.Count}");