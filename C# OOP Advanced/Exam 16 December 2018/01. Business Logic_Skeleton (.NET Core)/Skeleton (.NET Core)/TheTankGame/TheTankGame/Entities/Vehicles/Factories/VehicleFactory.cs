using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {

        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            IAssembler assembler = new VehicleAssembler();
            Type vType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == vehicleType);
            IVehicle vehicle = (IVehicle)Activator.CreateInstance(vType, model, weight, price, attack, defense, hitPoints, assembler);

            return vehicle;
        }
    }
}
