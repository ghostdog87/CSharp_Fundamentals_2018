using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string DefaultOwner = "Centre";
        private const bool DefaultIsAdopt = false;
        private const bool DefaultIsChipped = false;
        private const bool DefaultIsVaccinated = false;

        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = DefaultOwner;
            IsAdopt = DefaultIsAdopt;
            IsChipped = DefaultIsChipped;
            IsVaccinated = DefaultIsVaccinated;
        }

        public bool IsVaccinated
        {
            get { return isVaccinated; }
            set { isVaccinated = value; }
        }

        public bool IsChipped
        {
            get { return isChipped; }
            set { isChipped = value; }
        }

        public bool IsAdopt
        {
            get { return isAdopt; }
            set { isAdopt = value; }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public int ProcedureTime
        {
            get { return procedureTime; }
            set { procedureTime = value; }
        }

        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        //public abstract string ToString();
    }
}
