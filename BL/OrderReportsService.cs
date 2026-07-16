using BL.Exceptions;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderReportsService
    {
        private readonly BusinessLayer<Order> _orderBl;
        public OrderReportsService(BusinessLayer<Order> bl)
        {
            _orderBl = bl;
        }

        public async Task<TotalSalesSummary> GetTotalSalesSummary()
        {
            try
            {
                var orders = await _orderBl.GetAll();
                return new TotalSalesSummary
                {
                    TotalOrders = orders.Count,
                    TotalRevenue = orders.Sum(o => o.Price * o.Quantity)
                };
            }
            catch (BusinessException ex)
            {
                throw;
            }
        }

        public async Task<List<SalesByCustomer>> SalesByCustomerAsync()
        {
            try
            {
                var orders = await _orderBl.GetAll();
                return orders
                    .GroupBy(o => new { o.CustomerId, o.CustomerName })
                    .Select(g => new SalesByCustomer
                    {
                        CustomerId = g.Key.CustomerId,
                        CustomerName = g.Key.CustomerName,
                        OrdersCount = g.Count(),
                        TotalRevenue = g.Sum(x => x.Price * x.Quantity)
                    })
                    .OrderByDescending(c => c.TotalRevenue)
                    .ToList();
            }
            catch (BusinessException ex) { throw; }
        }

        public async Task<List<SalesByItem>> SalesByItemAsync() 
        {
            try
            {
                var orders = await _orderBl.GetAll();
                return orders
                    .GroupBy(o => new { o.ItemId, o.ItemName })
                    .Select(h => new SalesByItem
                    {
                        ItemId = h.Key.ItemId,
                        ItemName = h.Key.ItemName,
                        TotalQuantity = h.Sum(z => z.Quantity),
                        TotalRevenue = h.Sum(x => x.Price * x.Quantity)
                    })
                    .OrderByDescending(a => a.TotalRevenue)
                    .ToList();
            }
            catch (BusinessException ex) { throw; }
        }

        public async Task<List<SalesByCustomer>> TopCustomersAsync(int top)
        {
            var report = await SalesByCustomerAsync();
            return report.Take(top).ToList();
        }

        public async Task<List<SalesByItem>> TopItemsAsync(int top)
        {
            var report = await SalesByItemAsync();
            return report.Take(top).ToList();
        }
    }
}
