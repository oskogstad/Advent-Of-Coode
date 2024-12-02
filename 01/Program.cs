var distanceLists = File.ReadAllLines("./distance_lists").ToList();

var leftList = distanceLists
    .Select(distance => int.Parse(distance.Split("   ")[0]))
    .OrderBy(x => x)
    .ToList();

var rightList = distanceLists
    .Select(distance => int.Parse(distance.Split("   ")[1]))
    .OrderBy(x => x)
    .ToList();

var sum = leftList
    .Zip(rightList, (left, right)
        => Math.Abs(left - right))
    .Sum();

Console.WriteLine($"Sum: {sum}");