using Domains;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace StoreWindows
{
    public static class MainClass
    {
        public static DAL.StorageType storageType = DAL.StorageType.JsonFile; // Set storage type here

        // Business layers
        public static BusinessLayer<Item> itemBL = new BusinessLayer<Item>(storageType);
        public static BusinessLayer<Customer> customerBL = new BusinessLayer<Customer>(storageType);
        public static BusinessLayer<Order> orderBL = new BusinessLayer<Order>(storageType);
        public static OrderReportsService reportBl = new OrderReportsService(orderBL);

    }
}
