using BL;
using DAL;
using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class StoreConsoleApp
    {
        private readonly ItemMenu _itemMenu;
        private readonly CustomerMenu _customerMenu;
        private readonly OrderMenu _orderMenu;

        public StoreConsoleApp()
        {
            var itemBL = new BusinessLayer<Item>();
            var customerBL = new BusinessLayer<Customer>();
            var orderBL = new BusinessLayer<Order>();

            _itemMenu = new ItemMenu(itemBL);
            _customerMenu = new CustomerMenu(customerBL);
            _orderMenu = new OrderMenu(orderBL , customerBL , itemBL);
        }
        public async Task RunAsync()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("STORE MANAGEMENT SYSTEM");
                Console.WriteLine("========================================");
                Console.WriteLine("""
                1) Items
                2) Customers
                3) Orders
                0) Exit
                """);
                Console.WriteLine("-----------------------------------------");
                int choice = ConsoleInput.ReadInt("Choose: ", 0, 3);
                try
                {
                    switch (choice)
                    {
                        case 1:
                            await _itemMenu.ShowAsync();
                            break;
                        case 2:
                            await _customerMenu.ShowAsync();
                            break;
                        case 3:
                           await _orderMenu.ShowAsync();
                            break;
                        case 0:
                            return;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    ConsoleInput.Pause();
                }
            }
        }
    }
}
