using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistent {
    public interface IOrderRepository : IAsyncRepository<Order> {
        Task<IEnumerable<Order>> GetOrderByUserName(string username);
    }
}
