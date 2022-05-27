using IntiSolutionApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IntiSolutionApi.Interfaces
{
    public interface IOrderModel
    {

        /// <summary>
        /// List all order without detail
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Order>> Get();

        /// <summary>
        /// Show all information of a specific order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<Order> GetByID(int orderId);

        /// <summary>
        /// Save a order. If the order existe update
        /// </summary>
        /// <param name="order">order to save</param>
        /// <returns></returns>
        Task<bool> Save(Order order);


    }
}
