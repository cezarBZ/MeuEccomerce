using MeuEccomerce.Domain.Core.Data;

namespace MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

public interface IProductRepository : IRepository<Product, Guid>{}
