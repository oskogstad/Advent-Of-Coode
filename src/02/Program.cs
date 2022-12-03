var encryptedStrategyGuide = File.ReadAllLines("./encrypted_strategy_guide").ToList();

const int Rock = 1;
const int Paper = 2;
const int Scissors = 3;

const int Win = 6;
const int Draw = 3;
const int Loss = 0;

int GetScore(string game) => game switch
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

var score = encryptedStrategyGuide.Sum(GetScore);
Console.WriteLine(score);

