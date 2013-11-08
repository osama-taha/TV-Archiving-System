using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;

namespace TvArchiving.DAL.Repositories
{
    public class VideoFileRepository : Repository<VideoFile>, IVideoFileRepository
    {
        public VideoFileRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
    }
}
