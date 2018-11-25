using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam_Storage_Master.Core
{
    public class Engine
    {
        public void Run()
        {
            StorageMaster storageMaster = new StorageMaster();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] currentInput = input.Split();
                string type;

                try
                {
                    //•	AddProduct {type} {price}
                    if (currentInput[0] == "AddProduct")
                    {
                        type = currentInput[1];
                        double price = double.Parse(currentInput[2]);
                        string result = storageMaster.AddProduct(type, price);
                        Console.WriteLine(result);
                    }
                    //•	RegisterStorage {type} {name}
                    if (currentInput[0] == "RegisterStorage")
                    {
                        type = currentInput[1];
                        string name = currentInput[2];
                        string result = storageMaster.RegisterStorage(type, name);
                        Console.WriteLine(result);
                    }
                    //•	SelectVehicle {storageName} {garageSlot}

                    if (currentInput[0] == "SelectVehicle")
                    {
                        string storageName = currentInput[1];
                        int garageSlot = int.Parse(currentInput[2]);
                        string result = storageMaster.SelectVehicle(storageName, garageSlot);
                        Console.WriteLine(result);
                    }
                    //•	LoadVehicle {productName1} {productName2} {productNameN}
                    if (currentInput[0] == "LoadVehicle")
                    {
                        IEnumerable<string> productNames = currentInput.Skip(1);
                        string result = storageMaster.LoadVehicle(productNames);
                        Console.WriteLine(result);
                    }
                    //•	SendVehicleTo {sourceName} {sourceGarageSlot} {destinationName}
                    if (currentInput[0] == "SendVehicleTo")
                    {
                        string sourceName = currentInput[1];
                        int sourceGarageSlot = int.Parse(currentInput[2]);
                        string destinationName = currentInput[3];
                        string result = storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                        Console.WriteLine(result);
                    }
                    //•	UnloadVehicle {storageName} {garageSlot}
                    if (currentInput[0] == "UnloadVehicle")
                    {
                        string storageName = currentInput[1];
                        int garageSlot = int.Parse(currentInput[2]);
                        string result = storageMaster.UnloadVehicle(storageName, garageSlot);
                        Console.WriteLine(result);
                    }
                    //•	GetStorageStatus {storageName}
                    if (currentInput[0] == "GetStorageStatus")
                    {
                        string storageName = currentInput[1];
                        string result = storageMaster.GetStorageStatus(storageName);
                        Console.WriteLine(result);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(storageMaster.GetSummary());
            
        }
    }
}
