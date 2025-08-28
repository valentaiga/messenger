using Messenger.Identity.App.Grpc.Contracts;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Meta;

// ===================== update only this part =====================
Console.WriteLine("ProtoFilesGen args: [" + string.Join(",", args) + "]");
var interfaces = new Dictionary<string, Type>
{
    { "Identity.App", typeof(IIdentityApp) }
};

// ====================== do not update below ======================

#region Core

var generator = new SchemaGenerator
{
    ProtoSyntax = ProtoSyntax.Proto3
};

var saveFolder = Path.Combine(FindSolutionDirectory(), "src", "Backend", "ProtoFiles");
foreach (var protoFileArg in args)
{
    var protoFileName = protoFileArg[2..];

    if (!interfaces.TryGetValue(protoFileName, out var type))
        throw new Exception("Project reference not found for proto file generation");

    var output = generator.GetSchema(type);
    var filePath = Path.Combine(saveFolder, $"{protoFileName}.proto");
    await File.WriteAllTextAsync(filePath, output);
    Console.WriteLine($"ProtoFilesGen: Proto file '{protoFileName}.proto' updated ({filePath})");
}

return;

static string FindSolutionDirectory()
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var directory = new DirectoryInfo(currentDirectory);

    while (directory != null)
    {
        var solutionFiles = directory.GetFiles("*.sln*");
        if (solutionFiles.Any(f => f.Extension == ".sln" || f.Extension == ".slnx"))
        {
            return directory.FullName;
        }
        directory = directory.Parent;
    }

    throw new FileNotFoundException("Solution file not found");
}

#endregion
