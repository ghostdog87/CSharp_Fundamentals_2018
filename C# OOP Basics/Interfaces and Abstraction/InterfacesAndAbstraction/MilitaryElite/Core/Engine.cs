using MilitaryEliteV1_2.Contracts;
using MilitaryEliteV1_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryEliteV1_2.EnumM;
using MilitaryEliteV1_2.Core;

namespace MilitaryEliteV1_2.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;
        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public void Run()
        {
            
            string input = Console.ReadLine();
            
            while (input != "End")
            {
                string[] inputArgs = input.Split();
                //Private <id> <firstName> <lastName> <salary>”
                //LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                //Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>
                //Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>” 
                //Spy <id> <firstName> <lastName> <codeNumber>
                string type = inputArgs[0];
                int id = int.Parse(inputArgs[1]);
                string fisrtName = inputArgs[2];
                string lastName = inputArgs[3];
                //
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetPrivateSoldiers(id, fisrtName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetLieutenantGeneral(id, fisrtName, lastName, salary, inputArgs);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetEngineer(id, fisrtName, lastName, salary, inputArgs);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(inputArgs[4]);
                    soldier = GetCommando(id, fisrtName, lastName, salary, inputArgs);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(inputArgs[4]);
                    soldier = GetSpy(id, fisrtName, lastName, codeNumber);
                }
                if (soldier !=null)
                {
                    this.soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }
        }

        private ISoldier GetSpy(int id, string fisrtName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, fisrtName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string fisrtName, string lastName, decimal salary, string[] inputArgs)
        {
            string corpsAsStr = inputArgs[5];

            if (!Enum.TryParse(corpsAsStr, out Corps corps))
            {
                return null;
            }
            ICommando commando = new Commando(id, fisrtName, lastName, salary, corps);

            for (int i = 6; i < inputArgs.Length; i+=2)
            {
                string codeName = inputArgs[i];
                string stateAsStr = (inputArgs[i + 1]);

                if (!Enum.TryParse(stateAsStr, out State state))
                {
                    continue;
                }
                IMission mission = new Mission(codeName, state);
                commando.Missions.Add(mission);

            }
            return commando;
        }

        private ISoldier GetEngineer(int id, string fisrtName, string lastName, decimal salary, string[] inputArgs)
        {
            string corpsAsStr = inputArgs[5];
          
            if (!Enum.TryParse(corpsAsStr, out Corps corps))
            {
                return null;
            }
            IEngineer engineer = new Engineer(id, fisrtName, lastName, salary, corps);

            for (int i = 6; i < inputArgs.Length; i+=2)
            {
                string repairs = inputArgs[i];
                int hours = int.Parse(inputArgs[i + 1]);
                IRepair repair = new Repair(repairs, hours);
                engineer.Repairs.Add(repair);
            }
            return engineer;

        }

        private ISoldier GetLieutenantGeneral(int id, string fisrtName, string lastName, decimal salary, string[] inputArgs)
        {

            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, fisrtName, lastName, salary);

            for (int i = 5; i < inputArgs.Length; i++)
            {
                int privateId = int.Parse(inputArgs[i]);
                IPrivate privateSoldiers = (IPrivate)this.soldiers.FirstOrDefault(x => x.Id == privateId);

                lieutenantGeneral.Privates.Add(privateSoldiers);


            }
            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldiers(int id, string fisrtName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, fisrtName, lastName, salary);
            return privateSoldier;
        }
    }
}
