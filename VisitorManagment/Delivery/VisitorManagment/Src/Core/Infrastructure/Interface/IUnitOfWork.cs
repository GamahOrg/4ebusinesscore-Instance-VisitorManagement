

namespace _4EPlatForm.Infrastructure.Interface
{
    public interface IUnitOfWork
    {


        public Guid _loggedInUserId { get; }
        //INotificationRepository Notification { get; }
        IGRepository<TEntity> Repository<TEntity>() where TEntity : Domain.Models.BaseEntity<Guid>;
        public IVisitorRepository Visitor { get; }
        public IPermissionRepository Permission { get; }
        public IGroupRepository Group { get; }
        public ICancelRequestReposatiry CancelRequest { get; }

        public IViolationReposatiry Violation { get; }
        public IVisitorPermissionStepsRepository VisitorPermissionSteps { get; }
        public IStepsAttachmentRepository StepsAttachment { get; }
      

        #region Transaction
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        #endregion
        #region SaveChanges
        Task SaveChangesAsync();
        void SaveChanges();
        #endregion
    }
}
