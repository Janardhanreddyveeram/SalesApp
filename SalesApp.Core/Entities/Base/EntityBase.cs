namespace SalesApp.Core.Entities.Base
{
    public class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId? Id { get; set ; }
    }
}
