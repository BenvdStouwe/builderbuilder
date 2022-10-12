namespace BuilderBuilder.Compilers;

public class RecordCompiler : Compiler
{
    protected override void Compile()
    {
        AddLine("namespace TestHelpers;");
        AddEmptyLine();
        AddLine($"public record {BuilderEntity.Name}Builder");
        OpenBlock();
        foreach (var field in BuilderEntity.Fields)
        {
            AddLine($"public {field.Type} {field.Name} {{ private get; init; }}");
        }

        AddEmptyLine();
        AddLine($"public {BuilderEntity.Name} Build() => new()");
        OpenBlock();
        foreach (var field in BuilderEntity.Fields)
        {
            AddLine($"{field.Name} = {field.Name},");
        }

        CloseBlocks(1, ";");
        CloseBlock();
    }
}