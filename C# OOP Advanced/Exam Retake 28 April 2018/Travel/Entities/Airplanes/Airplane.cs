using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;


        protected Airplane(int seats, int baggageCompartments)
        {
            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;
        }

        public int Seats { get; private set; }

        public int BaggageCompartments { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();

        public bool IsOverbooked => this.passengers.Count > this.Seats;
      
        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger removedPassenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return removedPassenger;
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            List<IBag> removedBags = this.baggageCompartment.Where(x => x.Owner.Username == passenger.Username).ToList();
            this.baggageCompartment.RemoveAll(x => x.Owner.Username == passenger.Username);
            return removedBags;
        }

        public void LoadBag(IBag bag)
        {
            if (this.baggageCompartment.Count > this.BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }
            this.baggageCompartment.Add(bag);
        }
    }
}
