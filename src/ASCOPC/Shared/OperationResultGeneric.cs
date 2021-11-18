using ASCOPC.Domain.Contracts;

namespace ASCOPC.Shared
{
    public class OperationResult<T> : OperationResult, IResult<T>
        where T : class
    {
        public OperationResult(T value = null)
        {
            Value = value;
            CreateBuilder();
        }
        public T Value { get; private set; }

        public OperationResult<T> SetValue(T responseObj)
        {
            Value = responseObj;
            return this;
        }
        public static new OperationResultBuilder<T> CreateBuilder() => new();
        
    }
    public class OperationResultBuilder<T> : OperationResultBuilder 
        where T : class
    {
        public OperationResultBuilder()
        {
            OperationResult = new OperationResult<T>();
        }

        public override OperationResultBuilder<T> AppendError(string message) =>
            base.AppendError(message) as OperationResultBuilder<T>;

        public override OperationResultBuilder<T> AppendErrors(IEnumerable<string> message) =>
            base.AppendErrors(message) as OperationResultBuilder<T>;

        public override IResult<T> BuildResult() =>
            base.BuildResult() as OperationResult<T>;

        public OperationResultBuilder<T> SetValue(T value)
        {
            _ = (OperationResult as OperationResult<T>).SetValue(value);
            return this;
        }
    }
}
