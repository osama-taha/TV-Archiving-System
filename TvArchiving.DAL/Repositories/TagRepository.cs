using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;

namespace TvArchiving.DAL.Repositories
{
    public class TagRepository: Repository<Tag>,ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
    }
}
