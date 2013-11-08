namespace TvArchiving.Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private TvArchivingDbContext _dataContext;
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }
        protected TvArchivingDbContext DataContext { get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); } }
      
        public void Commit()
        {
            DataContext.Commit();
        }
    }

}
