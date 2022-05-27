using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Models
{
    public class ProductModel : IProductModel
    {

        private _DbContext context;

        public ProductModel(_DbContext context)
        {
            this.context = context;
        }   

        public async Task<IEnumerable<Product>> Get()
        {
            var result = await context.Products.ToListAsync();
            return result;
        }

        public async Task<Product> GetByID(int productId)
        {
            var result = await context.Products
                    .FirstOrDefaultAsync(c => c.Id == productId);
            return result;
        }

        public async Task<bool> Save(Product product)
        {
            var rowDB = await GetByID(product.Id);
            if (rowDB == null)
                context.Products.Add(product);
            else
            {
                rowDB.Code = product.Code;
                rowDB.Name = product.Name;
                rowDB.Price = product.Price;
                context.Entry(rowDB).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
