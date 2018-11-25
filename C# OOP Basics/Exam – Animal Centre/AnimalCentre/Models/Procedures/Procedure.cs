using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            procedureHistory = new List<IAnimal>();
        }

        public IReadOnlyCollection<IAnimal> ProcedureHistory
        {
            get { return procedureHistory.AsReadOnly(); }
        }

        public string History()
        {
            var sb = new StringBuilder();

            sb.Append($"{this.GetType().Name}\n");
            foreach (var animal in this.ProcedureHistory)
            {
                sb.Append($"    - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}\n");
            }
                
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);  
    }
}
