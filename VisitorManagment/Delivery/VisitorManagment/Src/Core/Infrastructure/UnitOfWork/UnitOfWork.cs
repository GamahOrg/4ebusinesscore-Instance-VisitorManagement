
namespace _4EPlatForm.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBContext _dbContext;
        private IDbContextTransaction _transaction;
        IServiceProvider _serviceProvider;
        //public Guid _loggedInUserId;
        public UnitOfWork(DBContext dbContext, IServiceProvider serviceProvider, IHttpContextAccessor _httpContextAccessor)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            _loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_httpContextAccessor);
            repoistories = new Hashtable();
        }
        Hashtable repoistories;
        public IGRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity<Guid>
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_dbContext);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGRepository<TEntity>;


        }

        public Guid _loggedInUserId { get; }


        IGroupRepository group = null;
        IVisitorRepository visitor = null;
        IPermissionRepository permission = null;
        IVisitorPermissionStepsRepository visitorPermissionsteps = null;
        ICancelRequestReposatiry cancelRequest = null;
        IViolationReposatiry violation = null;
        IStepsAttachmentRepository stepsAttachment = null;



        public ICancelRequestReposatiry CancelRequest
        {
            get
            {
                return cancelRequest ?? _serviceProvider.GetService<ICancelRequestReposatiry>();
            }
        }
        public IViolationReposatiry Violation
        {
            get
            {
                return violation ?? _serviceProvider.GetService<IViolationReposatiry>();
            }
        }
        public IGroupRepository Group
        {
            get
            {
                return group ?? _serviceProvider.GetService<IGroupRepository>();
            }
        }
        public IVisitorRepository Visitor
        {
            get
            {
                return visitor ?? _serviceProvider.GetService<IVisitorRepository>();
            }
        }
        public IPermissionRepository Permission
        {
            get
            {
                return permission ?? _serviceProvider.GetService<IPermissionRepository>();
            }
        }
        public IVisitorPermissionStepsRepository VisitorPermissionSteps
        {
            get
            {
                return visitorPermissionsteps ?? _serviceProvider.GetService<IVisitorPermissionStepsRepository>();
            }
        }
        public IStepsAttachmentRepository StepsAttachment
        {
            get
            {
                return stepsAttachment ?? _serviceProvider.GetService<IStepsAttachmentRepository>();
            }
        }



        #region Transaction
        public void BeginTransaction() => _transaction = _dbContext.Database.BeginTransaction();
        public async Task BeginTransactionAsync() => _transaction = await _dbContext.Database.BeginTransactionAsync();
        public void Commit() => _transaction.Commit();
        public async Task CommitAsync() => await _transaction.CommitAsync();
        public void Rollback() => _transaction?.Rollback();
        public async Task RollbackAsync() => await _transaction.RollbackAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext.Dispose();
        }
        public async Task DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
        #endregion


        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                var entries = _dbContext.ChangeTracker.Entries()
                    .Where(e => (e.Entity is BaseEntity<Guid>) && (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((BaseEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((BaseEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;
                        if (entityEntry.Entity is _4EPlatform.Domain.Models.Permission.Permission)
                        {
                            entityEntry.Property("PermissionCode").IsModified = false;

                        }
                        if (entityEntry.Entity is _4EPlatform.Domain.Models.Visitor.Visitor)
                        {
                            entityEntry.Property("VisitorCode").IsModified = false;

                        }
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((BaseEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }

                }
                if (_dbContext.Database.CurrentTransaction == null)
                    BeginTransaction();
                _dbContext.SaveChanges();
                //Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;

            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {

                var entries = _dbContext.ChangeTracker.Entries()
.Where(e => (e.Entity is BaseEntity<Guid>) && (
     e.State == EntityState.Added
     || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((BaseEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        //((BaseEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;


                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((BaseEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }
                }
                if (_dbContext.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                //Commit();
            }
            catch (Exception ex)
            {
                await RollbackAsync();

            }

        }
        #endregion


    }
}
