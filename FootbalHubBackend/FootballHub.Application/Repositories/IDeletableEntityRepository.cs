namespace FootballHub.Application.Repositories
{
    using FootballHub.Domain.Models;

    public interface IDeletableEntityRepository<TEntity> : IRepository<TEntity>
       where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
