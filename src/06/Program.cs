var signal = new Span<char>(File.ReadAllText("./signal").ToCharArray());

var markerFound = false;

var index = 0;
const int markerSize = 4;

bool SpanContainsUniqueCharacters(Span<char> span)
{
   var checkedCharacters = new List<char>();
   foreach (var character in span)
   {
      if (checkedCharacters.Contains(character))
         return false;
      
      checkedCharacters.Add(character);
   }

   return true;
}

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

Console.WriteLine($"06 Part one: {index+4}");