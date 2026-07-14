using BL;
using BL.Exceptions;
using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class OrderMenu
    {
        private BusinessLayer<Order> _orderBl;
        private BusinessLayer<Customer> _customerBl;
        private BusinessLayer<Item> _itemBl;

        public OrderMenu(BusinessLayer<Order> orderBl,
            BusinessLayer<Customer> customerBl,
            BusinessLayer<Item> itemBl
            )
        {
            _orderBl = orderBl;
            _customerBl = customerBl;
            _itemBl = itemBl;
        }
        public async Task ShowAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========== ORDERS MENU ==========");
                Console.WriteLine("1) Create Order");
                Console.WriteLine("2) List Orders");
                Console.WriteLine("3) Find Order By Id");
                Console.WriteLine("4) Update Order");
                Console.WriteLine("5) Delete Order");
                Console.WriteLine("0) Back");
                Console.WriteLine("--------------------------------");

                int choice = ConsoleInput.ReadInt("Choose: ", 0, 5);

                try
                {
                    switch (choice)
                    {
                        case 1: await CreateAsync(); break;
                        case 2: await ListAsync(); break;
                        case 3: await FindAsync(); break;
                        case 4: await UpdateAsync(); break;
                        case 5: await DeleteAsync(); break;
                        case 0: return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ConsoleInput.Pause();
                }
            }
        }

        private async Task CreateAsync() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- CREATE ORDER -----");

                var order = new Order
                {
                    Id = ConsoleInput.ReadInt("Order Id: ", 1),
                    OrderDate = DateTime.Now
                };

                await FillCustomerAndItemAsync(order);

                order.Quantity = ConsoleInput.ReadInt("Quantity: ", 1);

                await _orderBl.Add(order);

                Console.WriteLine("Order created successfully.");
                ConsoleInput.Pause();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine("business logic problem");
                ConsoleInput.Pause();
            }
        }
        private async Task ListAsync() 
        {
            try
            {
                var orders = await _orderBl.GetAll();
                Console.WriteLine("----- Orders List -----");
                if (orders.Count == 0)
                    Console.WriteLine("Not Orders Found");
                foreach (var order in orders)
                {
                    Console.WriteLine($"""
                    Id: {order.Id} | Date: {order.OrderDate}
                    Customer: {order.CustomerName} | Item: {order.ItemName}
                    Price: {order.Price} | Qty: {order.Quantity}
                    Total: {order.Price * order.Quantity}
                    """);
                    ConsoleInput.Pause();
                }
            }
            catch (BusinessException ex)
            {
                Console.WriteLine("business logic problem");
                ConsoleInput.Pause();
            }
        }
        private async Task FindAsync() 
        {
            try
            {
                Console.Clear();
                int id = ConsoleInput.ReadInt("Enter Order Id: ", 1);
                var order = await _orderBl.GetById(id);

                if (order == null || order.Id == 0)
                {
                    Console.WriteLine("Order not found.");
                }
                else
                {
                    Console.WriteLine("----- ORDER DETAILS -----");
                    Console.WriteLine($"Order Id      : {order.Id}");
                    Console.WriteLine($"Order Date    : {order.OrderDate}");
                    Console.WriteLine($"Customer      : {order.CustomerName}");
                    Console.WriteLine($"Item          : {order.ItemName}");
                    Console.WriteLine($"Price         : {order.Price}");
                    Console.WriteLine($"Quantity      : {order.Quantity}");
                    Console.WriteLine($"Total         : {order.Price * order.Quantity}");
                }

                ConsoleInput.Pause();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine("business logic problem");
                ConsoleInput.Pause();
            }
        }
        private async Task UpdateAsync() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----- UPDATE ORDER -----");

                int id = ConsoleInput.ReadInt("Enter Order Id: ", 1);
                var existing = await _orderBl.GetById(id);

                if (existing == null || existing.Id == 0)
                {
                    Console.WriteLine("Order not found.");
                    ConsoleInput.Pause();
                    return;
                }

                existing.OrderDate = DateTime.Now;

                await FillCustomerAndItemAsync(existing);

                existing.Quantity = ConsoleInput.ReadInt(
                    $"Quantity ({existing.Quantity}): ", 1);

                await _orderBl.Update(existing);

                Console.WriteLine("Order updated successfully.");
                ConsoleInput.Pause();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine("business logic problem");
                ConsoleInput.Pause();
            }
        }
        private async Task DeleteAsync() 
        {
            try
            {
                Console.Clear();
                int id = ConsoleInput.ReadInt("Enter Order Id to delete: ", 1);
                await _orderBl.Delete(id);

                Console.WriteLine("Order deleted successfully.");
                ConsoleInput.Pause();
            }
            catch (BusinessException ex)
            {
                Console.WriteLine("business logic problem");
                ConsoleInput.Pause();
            }
        }

        private async Task FillCustomerAndItemAsync(Order order)
        {
            // Customers
            var customers = await _customerBl.GetAll();
            Console.WriteLine("\nCustomers:");
            foreach (var c in customers)
                Console.WriteLine($"Id: {c.Id} | {c.CustomerName}");

            order.CustomerId = ConsoleInput.ReadInt(
                $"Customer Id ({order.CustomerId}): ", 1);

            var customer = customers.First(c => c.Id == order.CustomerId);
            order.CustomerName = customer.CustomerName;

            // Items
            var items = await _itemBl.GetAll();
            Console.WriteLine("\nItems:");
            foreach (var i in items)
                Console.WriteLine($"Id: {i.Id} | {i.Name} | Price: {i.Price}");

            order.ItemId = ConsoleInput.ReadInt(
                $"Item Id ({order.ItemId}): ", 1);

            var item = items.First(i => i.Id == order.ItemId);
            order.ItemName = item.Name;
            order.Price = item.Price;
        }

    }
}
