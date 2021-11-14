namespace ASCOPC.Domain.Contracts
{
    public interface IResult
    {
        public IEnumerable<string> Errors { get; }
        public bool IsSuccess { get; } 
    }

    public interface IResult<out T> : IResult
    {
        T Value { get; }
    }
}
