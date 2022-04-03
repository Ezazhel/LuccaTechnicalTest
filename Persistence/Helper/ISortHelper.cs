using System.Linq;

namespace Lucca.Persistence.Helper
{
    public interface ISortHelper<TEntities>
    {
        IQueryable<TEntities> ApplySort(IQueryable<TEntities> entities, string orderByQueryString);
    }
}