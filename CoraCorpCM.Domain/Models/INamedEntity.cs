namespace CoraCorpCM.Domain.Models
{
    public interface INamedEntity : IEntity
    {
        string Name { get; set; }
    }
}
