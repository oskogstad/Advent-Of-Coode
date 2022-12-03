var rucksacks = File.ReadAllLines("./rucksacks");

var prioritySum = 0;

int UppercaseScore(char item) => item - 'A' + 27;
int LowerCaseBase(char item) => item - 'a' + 1;

foreach (var rucksack in rucksacks)
{
    var compartmentOne = rucksack[..(rucksack.Length/2)];
    var compartmentTwo = rucksack[(rucksack.Length/2)..];

    var commonItem = compartmentOne.Intersect(compartmentTwo).Single();

    var priorityScore = char.IsLower(commonItem)
        ? LowerCaseBase(commonItem)
        : UppercaseScore(commonItem);

    prioritySum += priorityScore;
}

Console.WriteLine($"Priority sum: {prioritySum}");