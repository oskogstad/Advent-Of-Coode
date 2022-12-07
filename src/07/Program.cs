var consoleLog = System.IO.File.ReadAllLines("./console_log");

var fileSystem = new Dictionary<string, Folder>();
var currentPath = "";

foreach (var line in consoleLog)
{
    var split = line.Split(' ');

    if (split[0] is "$")
    {
        // command
        var command = split[1];
        if (command is "cd")
        {
            // change current path
            var pathArgument = split[2];
            if (pathArgument is "..")
            {
                currentPath = currentPath.Remove(currentPath.LastIndexOf('/'));
                if (currentPath is "")
                    currentPath = "/";
            }
            else if (pathArgument is "/")
                currentPath = "/";
            else
            {
                currentPath = $"{currentPath}/{pathArgument}";
                if (currentPath.StartsWith("//"))
                    currentPath = currentPath[1..];
            }
            TryAddFolderToFileSystem(currentPath);
        }
    }
    else if (split[0] is "dir")
    {
        var folderPath = $"{currentPath}/{split[1]}";
        if (folderPath.StartsWith("//"))
            folderPath = folderPath[1..];
        fileSystem[currentPath].Folders.Add(folderPath);
        TryAddFolderToFileSystem(folderPath);
    }
    else
    {
        fileSystem.TryGetValue(currentPath, out var folder);
        folder!.TotalFileSize += int.Parse(split[0]);
    }
}

var folderSizes = fileSystem
    .Select(kvp => GetTotalFileSize(kvp.Value)).ToList();
    
var sumOfFoldersUpToOneHundredK = folderSizes
    .Where(folderSize => folderSize <= 100000)
    .Sum();

Console.WriteLine($"07  Part one: {sumOfFoldersUpToOneHundredK}");

void TryAddFolderToFileSystem(string path) => 
    fileSystem?.TryAdd(path, new Folder(new List<string>()));

int GetTotalFileSize(Folder folder) =>
    folder.TotalFileSize + folder.Folders.Sum(path => GetTotalFileSize(fileSystem[path]));

record Folder(List<string> Folders)
{
    public int TotalFileSize { get; set; }
}