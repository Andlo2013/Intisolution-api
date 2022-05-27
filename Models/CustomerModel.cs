using IntiSolutionApi.Entities;
using IntiSolutionApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Models
{
    public class CustomerModel : ICustomerModel
    {
        _DbContext context;

        public CustomerModel(_DbContext context)
        {
            this.context = context;
        }   

        public async Task<IEnumerable<customer>> Get()
        {
            var result = await context.Customers.ToListAsync();
            return result;
        }

        public async Task<customer> GetByID(int customerId)
        {
            var result = await context.Customers
                    .FirstOrDefaultAsync(c=>c.Id==customerId);
            return result;
            
        }

        public async Task<bool> Save(customer customer)
        {
            var rowDB=await GetByID(customer.Id);
            if (rowDB == null)
                context.Customers.Add(customer);
            else
            {
                rowDB.FirstName = customer.FirstName;
                rowDB.LastName = customer.LastName;
                rowDB.UserId = customer.UserId;
                rowDB.Identification = customer.Identification;
                rowDB.Email = customer.Email;
                context.Entry(customer).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return true;
        }

        
    }
}
