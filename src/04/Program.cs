using System.Text.RegularExpressions;

var sectionAssignmentsInput = File.ReadAllLines("./section_assignments");

var sectionAssignments = sectionAssignmentsInput
    .Select(sectionAssignment =>
        Regex.Split(sectionAssignment, @"\D+")
            .Select(int.Parse)
            .ToList())
    .ToList();

bool HasTotalOverLap(IReadOnlyList<int> sections) =>
    (sections[0] >= sections[2] && sections[1] <= sections[3]) ||
    (sections[0] <= sections[2] && sections[1] >= sections[3]);

var numberOfTotalOverlaps = sectionAssignments.Count(HasTotalOverLap);
Console.WriteLine($"Number of total overlaps: {numberOfTotalOverlaps}");

bool HasPartialOverLap(IReadOnlyList<int> sections) => 
    !(sections[1] < sections[2] || sections[0] > sections[3]);

var numberOfOverlaps = sectionAssignments.Count(HasPartialOverLap);
Console.WriteLine($"Number of overlaps: {numberOfOverlaps}");