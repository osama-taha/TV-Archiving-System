namespace TvArchiving.Domain.Infrastructure
{

    public  class DatabaseFactory:Disposable , IDatabaseFactory 
    {
        private TvArchivingDbContext _dataContext;
        public TvArchivingDbContext Get()
        {
            return _dataContext ?? (_dataContext = new TvArchivingDbContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
            }
        }
    }
}
