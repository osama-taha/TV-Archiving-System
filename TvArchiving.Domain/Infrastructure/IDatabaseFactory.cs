using System;

namespace TvArchiving.Domain.Infrastructure
{
    public interface IDatabaseFactory:IDisposable
    {
        TvArchivingDbContext Get();
    }
}
