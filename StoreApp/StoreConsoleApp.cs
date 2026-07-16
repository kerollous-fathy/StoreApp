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
        private readonly ReportsMenu _reportMenu;

        public StoreConsoleApp()
        {

            DAL.StorageType storageType = DAL.StorageType.JsonFile;
            var itemBL = new BusinessLayer<Item>(storageType);
            var customerBL = new BusinessLayer<Customer>(storageType);
            var orderBL = new BusinessLayer<Order>(storageType);
            var reportBl = new OrderReportsService(orderBL);

            _itemMenu = new ItemMenu(itemBL);
            _customerMenu = new CustomerMenu(customerBL);
            _orderMenu = new OrderMenu(orderBL , customerBL , itemBL);
            _reportMenu = new ReportsMenu(reportBl);
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
                4) Reports
                0) Exit
                """);
                Console.WriteLine("-----------------------------------------");
                int choice = ConsoleInput.ReadInt("Choose: ", 0, 4);
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
                        case 4:
                            await _reportMenu.ShowAsync();
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
