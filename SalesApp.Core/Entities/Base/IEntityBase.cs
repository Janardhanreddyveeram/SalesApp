namespace SalesApp.Core.Entities.Base
{
    public interface IEntityBase<TID>
    {
        TID Id { get; set; }
    }
}
