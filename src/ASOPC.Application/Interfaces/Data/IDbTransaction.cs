namespace ASOPC.Application.Interfaces.Data
{
    public interface IDbTransaction : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
    }
}
