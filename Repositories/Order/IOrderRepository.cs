using System;
using Flower_Shop.Models;

namespace Flower_Shop.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();

        Order? GetById(int id);

        Order? GetByUId(string uid);

        void Add(Order order);

        void Update(Order order);

        void Delete(Order order);

        void Save();
    }
}

