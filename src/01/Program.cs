var input = File.ReadAllLines("./calories_input");

var caloriesPerElf = new List<int>();
var calorieCountCurrentElf = 0;

foreach (var line in input)
{
    if (string.IsNullOrWhiteSpace(line))
    {
       caloriesPerElf.Add(calorieCountCurrentElf);
       calorieCountCurrentElf = 0;
       continue;
    }

    var num = int.Parse(line);
    calorieCountCurrentElf += num;
}

Console.WriteLine(caloriesPerElf.OrderDescending().First());