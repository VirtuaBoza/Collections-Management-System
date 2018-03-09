namespace CoraCorpCM.Domain.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        Museum  Museum { get; set; }
    }
}
