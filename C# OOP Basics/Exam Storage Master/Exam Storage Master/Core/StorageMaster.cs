using Exam_Storage_Master.Factory;
using Exam_Storage_Master.Models;
using Exam_Storage_Master.Models.Products;
using Exam_Storage_Master.Models.Storages;
using Exam_Storage_Master.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam_Storage_Master.Core
{
    public class StorageMaster
    {
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private StorageFactory storageFactory;
        private Dictionary<string,Stack<Product>> products;
        private List<Storage> storages;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            productFactory = new ProductFactory();
            vehicleFactory = new VehicleFactory();
            storageFactory = new StorageFactory();
            products = new Dictionary<string, Stack<Product>>();
            storages = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            if (!this.products.ContainsKey(type))
            {
                this.products.Add(type, new Stack<Product>());
            }

            this.products[type].Push(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            this.storages.Add(storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage currentStorage = storages.Find(x => x.Name == storageName);

            currentVehicle = currentStorage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (var productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.products.ContainsKey(productName))
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                if (!this.products[productName].Any())
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                Product currentProduct = this.products[productName].Pop();

                currentVehicle.LoadProduct(currentProduct);

                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storages.Any(x => x.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!storages.Any(x => x.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = storages.Find(x => x.Name == sourceName);

            Storage destinationStorage = storages.Find(x => x.Name == destinationName);

            string vehicleType = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage getStorage = storages.Find(x => x.Name == storageName);
            Vehicle getVehicle = getStorage.GetVehicle(garageSlot);
            int getVehicleTrunk = getVehicle.Trunk.Count;
            var unloadedProductsCount = getStorage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{getVehicleTrunk} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage getStorage = storages.Find(x => x.Name == storageName);
            var sortedStorage = getStorage.Products
                .GroupBy(x => x.GetType().Name)
                .OrderByDescending(x => x.Count())
                .ThenBy(x => x.GetType().Name);
            double sumOfProductsWeight = getStorage.Products.Sum(x => x.Weight);
            string productList = string.Empty;

            if (sortedStorage.Count() > 0)
            {
                foreach (var item in sortedStorage)
                {
                    string currentItem = $"{item.Key} ({item.Count()})";
                    productList += currentItem + ", ";
                }
                productList = productList.Substring(0, productList.Length - 2);
            }
            Func<Vehicle, string> replacer = x => x == null ? "empty" : x.GetType().Name;
            List<string> garage = getStorage.Garage.Select(replacer).ToList();

            string result = $"Stock ({sumOfProductsWeight}/{getStorage.Capacity}): [{productList}]\n";
            result += $"Garage: [{string.Join("|", garage)}]";

            return result;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var storage in storages.OrderByDescending(x => x.Products.Sum(y => y.Price)))
            {
                double result = storage.Products.Sum(x => x.Price);

                sb.Append($"{storage.Name}:\nStorage worth: ${result:f2}\n");
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
                      
            return sb.ToString();
        }

    }
}
