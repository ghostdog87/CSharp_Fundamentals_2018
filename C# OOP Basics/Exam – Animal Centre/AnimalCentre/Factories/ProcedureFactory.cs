using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories
{
    public class ProcedureFactory
    {
        public IProcedure CreateProcedure(string procedureType)
        {
            switch (procedureType)
            {
                case "Chip":
                    return new Chip();
                case "DentalCare":
                    return new DentalCare();
                case "Fitness":
                    return new Fitness();
                case "NailTrim":
                    return new NailTrim();
                case "Play":
                    return new Play();
                case "Vaccinate":
                    return new Vaccinate();
                default:
                    throw new InvalidOperationException("Invalid procedure type!");
            }
        }
    }
}
