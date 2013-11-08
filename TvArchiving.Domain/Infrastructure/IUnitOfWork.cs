namespace TvArchiving.Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
