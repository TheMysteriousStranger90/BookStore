using System.Collections.Generic;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Filters
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Order> orders, int? order, string name)
        {
            orders.Insert(0, new Order { OrderNumber = "All", Id = 0 });
            Orders = new SelectList(orders, "Id", "Name", order);
            SelectedOrder = order;
            SelectedName = name;
        }
        public SelectList Orders { get; private set; }
        public int? SelectedOrder { get; private set; }
        public string SelectedName { get; private set; }
    }
}