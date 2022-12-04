using System.Text.RegularExpressions;

var sectionAssignments = File.ReadAllLines("./section_assignments");

var numberOfTotalOverlaps = sectionAssignments
    .Select(sectionAssignment => 
        Regex.Split(sectionAssignment, @"\D+")
            .Select(int.Parse)
            .ToList())
    .Count(sections => 
        (sections[0] >= sections[2] && sections[1] <= sections[3]) || 
        (sections[0] <= sections[2] && sections[1] >= sections[3]));

Console.WriteLine($"Number of total overlaps: {numberOfTotalOverlaps}");