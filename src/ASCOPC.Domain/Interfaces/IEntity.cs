namespace ASCOPC.Domain.Interfaces
{
    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
}
