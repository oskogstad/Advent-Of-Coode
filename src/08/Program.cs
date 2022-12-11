var forestInput = File.ReadAllLines("./forest");

var height = forestInput.Length;
var width = forestInput[0].Length;

var forest = new int[height * width];
var visibleTres = new HashSet<int>();

for (var y = 0; y < forestInput.Length; y++)
{
    var line = forestInput[y];
    for (var x = 0; x < line.Length; x++)
    {
        var index = x + y * width;
        var num = line[x] - '0';
        forest[index] = num;
    }
}

bool TreeIsOnEdge(int x, int y) =>
    x == 0 || y == 0 || x == width - 1 || y == height - 1;

void CheckTree(int x, int y, ref int maxHeight)
{
    var currentTreeIndex = x + y * height;
    var currentTreeHeight = forest[currentTreeIndex];

    if (TreeIsOnEdge(x, y))
    {
        visibleTres.Add(currentTreeIndex);
        maxHeight = currentTreeHeight;
        return;
    }

    if (currentTreeHeight <= maxHeight) 
        return;
    
    maxHeight = currentTreeHeight;
    visibleTres.Add(currentTreeIndex);
}

// top => down
for (var x = 0; x < width; ++x)
{
    var maxHeight = 0;
    for (var y = 0; y < height; ++y)
    {
        CheckTree(x, y, ref maxHeight);
    }
}

// bottom => up
for (var x = width - 1; x >= 0; --x)
{
    var maxHeight = 0;
    for (var y = height - 1; y >= 0; --y)
    {
        CheckTree(x, y, ref maxHeight);
    }
}

// left => right
for (var y = 0; y < height; ++y)
{
    var maxHeight = 0;
    for (var x = 0; x < width; ++x)
    {
        CheckTree(x, y, ref maxHeight);
    }
}

// right => left
for (var y = height - 1; y >= 0; --y)
{
    var maxHeight = 0;
    for (var x = width - 1; x >= 0; --x)
    {
        CheckTree(x, y, ref maxHeight);
    }
}

Console.WriteLine($"08 Part one: {visibleTres.Count}");