using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;

namespace TvArchiving.DAL.Repositories
{
    public class ShotRepository: Repository<Shot>,IShotRepository
    {
        public ShotRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
    }
}
