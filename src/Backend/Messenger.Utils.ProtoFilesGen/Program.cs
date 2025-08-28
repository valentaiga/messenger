using Messenger.Identity.App.Grpc.Contracts;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Meta;

// ===================== update only this part =====================

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
foreach (var (protoFileName, type) in interfaces)
{
    var output = generator.GetSchema(type);
    var filePath = Path.Combine(saveFolder, $"{protoFileName}.proto");
    await File.WriteAllTextAsync(filePath, output);
    Console.WriteLine($"Proto file: {protoFileName}.proto updated");
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
