using ASCOPC.Domain.Contracts;

namespace ASCOPC.Shared
{
    public class OperationResult : IResult
    {
        public OperationResult()
        {
            _errors = new List<string>();
        }

        private List<string> _errors;

        public IEnumerable<string> Errors { get => _errors; set => AddErrors(value); }

        public bool IsSuccess => _errors.Count == 0;

        public OperationResult AddErrors(IEnumerable<string> exceptions)
        {
            _errors.AddRange(exceptions);
            return this;
        }

        public static new OperationResultBuilder CreateBuilder() => new();
    }
    public class OperationResultBuilder
    {
        private ICollection<string> _errors;
        protected OperationResult OperationResult { get; set; }

        public OperationResultBuilder()
        {
            OperationResult = new OperationResult();
            _errors = new List<string>();
        }

        public virtual IResult BuildResult()
        {
            OperationResult.AddErrors(_errors);
            return OperationResult;
        }

        public virtual OperationResultBuilder AppendError(string message)
        {
            _errors.Add(message);
            return this;
        }

        public virtual OperationResultBuilder AppendErrors(IEnumerable<string> messages)
        {
            foreach (var message in messages)
                _errors.Add(message);

            return this; 
        }
    }
}
