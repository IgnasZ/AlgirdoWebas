using Ardalis.Specification;
using Sula.Shipment.ApplicationCore.Entities;

namespace Sula.Shipment.ApplicationCore.Specifications
{
    public class CatalogFilterPaginatedSpecification : Specification<CatalogItem>
    {
        public CatalogFilterPaginatedSpecification(int skip, int take, int? brandId, int? typeId)
            : base()
        {
            Query
                .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
                (!typeId.HasValue || i.CatalogTypeId == typeId))
                .Paginate(skip, take);
        }
    }
}
