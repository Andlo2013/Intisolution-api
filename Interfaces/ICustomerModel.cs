using IntiSolutionApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Interfaces
{
    /// <summary>
    /// Interface wich must implement the modelClas for manage Orders
    /// </summary>
    public interface ICustomerModel
    {
        /// <summary>
        /// List all clients
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<customer>> Get();

        /// <summary>
        /// List a specific client
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<customer> GetByID(int customerId);


        Task<bool> Save(customer user);

    }
}
