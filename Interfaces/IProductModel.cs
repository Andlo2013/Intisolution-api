using IntiSolutionApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Interfaces
{
    public interface IProductModel
    {
        Task<IEnumerable<Product>> Get();

        Task<Product> GetByID(int productId);


        Task<bool> Save(Product product);

    }
}
