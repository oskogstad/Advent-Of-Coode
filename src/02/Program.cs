var encryptedStrategyGuide = File.ReadAllLines("./encrypted_strategy_guide").ToList();

const int Rock = 1;
const int Paper = 2;
const int Scissors = 3;

const int Win = 6;
const int Draw = 3;
const int Loss = 0;

int GetScorePartOne(string game) => game switch
{
   "A X" => Draw + Rock, 
   "A Y" => Win + Paper, 
   "A Z" => Loss + Scissors, 
   
   "B X" => Loss + Rock, 
   "B Y" => Draw + Paper, 
   "B Z" => Win + Scissors, 
   
   "C X" => Win + Rock, 
   "C Y" => Loss + Paper, 
   "C Z" => Draw + Scissors, 
};

var scorePartOne = encryptedStrategyGuide.Sum(GetScorePartOne);
Console.WriteLine($"Score part one: {scorePartOne}");

int GetScorePartTwo(string game) => game switch
{
   "A X" => Loss + Scissors, 
   "A Y" => Draw + Rock, 
   "A Z" => Win + Paper, 
   
   "B X" => Loss + Rock, 
   "B Y" => Draw + Paper, 
   "B Z" => Win + Scissors, 
   
   "C X" => Loss + Paper, 
   "C Y" => Draw + Scissors, 
   "C Z" => Win + Rock, 
};

var scorePartTwo = encryptedStrategyGuide.Sum(GetScorePartTwo);
Console.WriteLine($"Score part two: {scorePartTwo}");