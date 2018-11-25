using AnimalCentre.Factories;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private AnimalFactory animalFactory;
        private ProcedureFactory procedureFactory;
        private Hotel hotel;
        private Dictionary<string, List<IAnimal>> procedures;
        private Dictionary<string, List<IAnimal>> owners = new Dictionary<string, List<IAnimal>>();

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory();
            this.procedureFactory = new ProcedureFactory();
            this.hotel = new Hotel();
            this.procedures = new Dictionary<string, List<IAnimal>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal animal = animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            hotel.Accommodate(animal);
            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure chip = procedureFactory.CreateProcedure("Chip");

            chip.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("Chip"))
            {
                procedures.Add("Chip", new List<IAnimal>());
            }
            procedures["Chip"].Add(currentAnimal);

            return $"{currentAnimal.Name} had chip procedure";
        }


        public string Vaccinate(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure vaccinate = procedureFactory.CreateProcedure("Vaccinate");

            vaccinate.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("Vaccinate"))
            {
                procedures.Add("Vaccinate", new List<IAnimal>());
            }
            procedures["Vaccinate"].Add(currentAnimal);

            return $"{currentAnimal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure fitness = procedureFactory.CreateProcedure("Fitness");

            fitness.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("Fitness"))
            {
                procedures.Add("Fitness", new List<IAnimal>());
            }
            procedures["Fitness"].Add(currentAnimal);

            return $"{currentAnimal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure play = procedureFactory.CreateProcedure("Play");

            play.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("Play"))
            {
                procedures.Add("Play", new List<IAnimal>());
            }
            procedures["Play"].Add(currentAnimal);

            return $"{currentAnimal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure dentalCare = procedureFactory.CreateProcedure("DentalCare");

            dentalCare.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("DentalCare"))
            {
                procedures.Add("DentalCare", new List<IAnimal>());
            }
            procedures["DentalCare"].Add(currentAnimal);

            return $"{currentAnimal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == name).Value;
            IProcedure nailTrim = procedureFactory.CreateProcedure("NailTrim");

            nailTrim.DoService(currentAnimal, procedureTime);

            if (!procedures.ContainsKey("NailTrim"))
            {
                procedures.Add("NailTrim", new List<IAnimal>());
            }
            procedures["NailTrim"].Add(currentAnimal);

            return $"{currentAnimal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!hotel.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal currentAnimal = hotel.Animals.First(x => x.Key == animalName).Value;

            hotel.Adopt(animalName, owner);
          
            if (!owners.ContainsKey(owner))
            {
                owners.Add(owner, new List<IAnimal>());
            }

            owners[owner].Add(currentAnimal);

            if (currentAnimal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            var sb = new StringBuilder();
            sb.Append($"{type}\n");

            if (procedures.ContainsKey(type))
            {
                var currentProcedure = procedures.First(x => x.Key == type).Value;
                foreach (var animal in currentProcedure)
                {
                    sb.Append($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}\n");
                }
            }
                       
            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            foreach (var owner in owners.OrderBy(x => x.Key))
            {
                sb.Append($"--Owner: {owner.Key}\n");
                List<string> sortedList = owner.Value
                                            .OrderBy(x => x.Name)
                                            .Select(x => x.Name)
                                            .ToList();

                sb.Append($"    - Adopted animals: {string.Join(" ", sortedList)}\n");
            }

            if (owners.Count > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.ToString();
        }
    }
}
