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

var groupPrioritySum = 0;
const int groupSize = 3;
for (var i = 0; i < rucksacks.Length / groupSize; ++i)
{
    var group = rucksacks.Skip(groupSize * i).Take(groupSize).ToList();
    var commonItem = group[0].Intersect(group[1]).Intersect(group[2]).Single();
    
    var priorityScore = char.IsLower(commonItem)
        ? LowerCaseBase(commonItem)
        : UppercaseScore(commonItem);

    groupPrioritySum += priorityScore;
}

Console.WriteLine($"Group priority sum: {groupPrioritySum}");