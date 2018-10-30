using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        //model, fuel amount, fuel consumption for 1 kilometer and  traveled distance

        private string model;
        private decimal fuelAmount;
        private decimal fuelConsumptionFor1km;
        private int distanceTraveled;

        public Car(string model, decimal fuelAmount, decimal fuelConsumptionFor1km)
        {
            this.DistanceTraveled = 0;
            this.FuelConsumptionFor1km = fuelConsumptionFor1km;
            this.FuelAmount = fuelAmount;
            this.Model = model;
        }

        public int DistanceTraveled
        {
            get { return distanceTraveled; }
            set { distanceTraveled = value; }
        }

        public decimal FuelConsumptionFor1km
        {
            get { return fuelConsumptionFor1km; }
            set { fuelConsumptionFor1km = value; }
        }

        public decimal FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public bool IsEnoughFuel(int amountOfKm)
        {
            decimal usedFuel = amountOfKm * this.FuelConsumptionFor1km;

            if (usedFuel > this.FuelAmount)
            {
                return false;
            }
            this.DistanceTraveled += amountOfKm;
            this.FuelAmount -= usedFuel;
            return true;
        }
    }
}
