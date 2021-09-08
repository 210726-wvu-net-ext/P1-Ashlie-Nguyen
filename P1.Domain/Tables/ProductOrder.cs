using System;
using System.Collections.Generic;

namespace P1.Domain
{
    public class ProductOrder
    {
//        private readonly IOrderRepository _orderrepository;
//        private readonly IProductRepository _productrepository;
        public ProductOrder(int number, int product, int order)
        {
            Number = number;
            Product = product;
            Order = order;
//            OrderNavigation = _orderrepository.Get(order);
//            ProductNavigation = _productrepository.Get(product);
        }
        public ProductOrder(int id, int number, int product, int order)
        {
            Id = id;
            Number = number;
            Product = product;
            Order = order;
//            OrderNavigation = _orderrepository.Get(order);
//            ProductNavigation = _productrepository.Get(product);
        }
        public int Id { get; }
        public int Number { get; }
        public int Product { get; }
        public int Order { get; }

        public virtual Order OrderNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
