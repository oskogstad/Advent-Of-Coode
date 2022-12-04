using System.Text.RegularExpressions;

var sectionAssignmentsInput = File.ReadAllLines("./section_assignments");

var sectionAssignments = sectionAssignmentsInput
    .Select(sectionAssignment =>
        Regex.Split(sectionAssignment, @"\D+")
            .Select(int.Parse)
            .ToList())
    .ToList();

bool HasTotalOverLap(int minA, int maxA, int minB, int maxB) =>
    (minA >= minB && maxA <= maxB) || (minA <= minB && maxA >= maxB);

var numberOfTotalOverlaps = sectionAssignments.Count(section => 
    HasTotalOverLap(section[0], section[1], section[2], section[3]));
Console.WriteLine($"Number of total overlaps: {numberOfTotalOverlaps}");

bool HasPartialOverLap(int minA, int maxA, int minB, int maxB) => !(maxA < minB || minA > maxB);

var numberOfOverlaps = sectionAssignments.Count(section => 
    HasPartialOverLap(section[0], section[1], section[2], section[3]));
Console.WriteLine($"Number of overlaps: {numberOfOverlaps}");