using System.Text.RegularExpressions;

var cratesAndMoves = File.ReadAllLines("./crates_and_moves");

var crateLines = cratesAndMoves
    .TakeWhile(inputLine
        => !string.IsNullOrWhiteSpace(inputLine))
    .Reverse()
    .ToArray();

var moveList = cratesAndMoves[(crateLines.Length + 1)..];

var numberOfContainerStacks = Regex
    .Split(crateLines.First().Trim(), @"\D+")
    .Length;

var containerStacks = Enumerable
    .Range(0, numberOfContainerStacks)
    .Select(_ => new Stack<char>())
    .ToList();

foreach (var crateLine in crateLines[1..])
{
    for (var i = 0; i < numberOfContainerStacks; ++i)
    {
        var containerCharacter = crateLine.Substring(i * 4, 3)[1];
        if(char.IsWhiteSpace(containerCharacter))
            continue;
        containerStacks[i].Push(containerCharacter);
    }
}

foreach (var move in moveList)
{
    var moveNumbers = Regex
        .Split(move, @"\D+")
        .Where(s => !string.IsNullOrWhiteSpace(s))
        .Select(int.Parse)
        .ToArray();
    
    var howMany = moveNumbers.First();
    var sourceIndex = moveNumbers[1] - 1;
    var targetIndex = moveNumbers.Last() - 1;

    for (var i = 0; i < howMany; i++)
    {
        var item = containerStacks[sourceIndex].Pop();
        containerStacks[targetIndex].Push(item);
    }
}

foreach(var containerStack in containerStacks) {
    Console.Write(containerStack.Pop());
}