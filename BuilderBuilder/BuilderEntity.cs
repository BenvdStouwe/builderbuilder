namespace BuilderBuilder;

public class BuilderEntity
{
    public bool Persistable { get; }

    public string Name { get; set; }

    public List<Field> Fields { get; }

    public BuilderEntity(bool persistable) {
        Persistable = persistable;
        Name = "";
        Fields = new List<Field>();
    }
}

public record struct Field(string Type, string Name, Field.InverseHandlingType InverseHandling = Field.InverseHandlingType.None)
{
    public enum InverseHandlingType { None, OneToOne, OneToMany, ManyToOne, ManyToMany }
}