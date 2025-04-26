using Reloaded.Memory.Sigscan;

if (args.Length < 1)
{
    Console.WriteLine("Usage: FindSig \"<signature>\"");
    return;
}

var signature = args[0];

Console.WriteLine($"Scanning for sig: {signature}");

foreach (string file in Directory.EnumerateFiles(Environment.CurrentDirectory, "*.exe", SearchOption.AllDirectories))
{
    using var scanner = new Scanner(File.ReadAllBytes(file));
    var result = scanner.FindPattern(signature);
    if (result.Found)
        Console.WriteLine($"Found at offset 0x{result.Offset:X} in {file}");
}
