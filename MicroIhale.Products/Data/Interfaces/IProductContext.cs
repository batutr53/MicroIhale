using MicroIhale.Products.Entities;
using MongoDB.Driver;

namespace MicroIhale.Products.Data.Interfaces
{
    public interface IProductContext
    {
        IMongoCollection<Product> Products { get;  }
    }
}
