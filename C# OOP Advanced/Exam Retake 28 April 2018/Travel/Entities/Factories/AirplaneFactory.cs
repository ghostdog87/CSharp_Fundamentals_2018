namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Type airplaneType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);
            IAirplane airplane = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplane;

        }
	}
}