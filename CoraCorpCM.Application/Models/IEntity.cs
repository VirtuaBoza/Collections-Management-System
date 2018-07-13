namespace CoraCorpCM.Application.Models
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
