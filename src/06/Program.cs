var signal = new Span<char>(File.ReadAllText("./signal").ToCharArray());

const int markerSizePartOne = 4;
const int markerSizePartTwo = 14;

bool SpanContainsUniqueCharacters(Span<char> span)
{
   var checkedCharacters = new HashSet<char>();
   foreach (var character in span)
   {
      if (checkedCharacters.Contains(character))
         return false;
      
      checkedCharacters.Add(character);
   }

   return true;
}

int GetMarkerIndex(Span<char> signal, int markerSize)
{
   var index = 0;
   var markerFound = false;
   
   while (!markerFound)
   {
      var currentSpan = signal.Slice(index, markerSize);

      if (SpanContainsUniqueCharacters(currentSpan))
      {
         markerFound = true;
         continue;
      }

      index++;
   }

   return index;
}

var partOne = GetMarkerIndex(signal, markerSizePartOne) + markerSizePartOne;
Console.WriteLine($"06 Part one: {partOne}");

var partTwo = GetMarkerIndex(signal, markerSizePartTwo) + markerSizePartTwo;
Console.WriteLine($"06 Part two: {partTwo}");