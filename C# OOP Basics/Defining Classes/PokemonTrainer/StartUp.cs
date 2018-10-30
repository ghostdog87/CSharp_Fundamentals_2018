using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();

            while (input != "Tournament")
            {
                string[] currentInput = input.Split();
                string trainerName = currentInput[0];
                string pokemonName = currentInput[1];
                string elements = currentInput[2];
                int health = int.Parse(currentInput[3]);

                Pokemon pokemon = new Pokemon(pokemonName,elements,health);
                Trainer currentTrainer = new Trainer(trainerName);


                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(currentTrainer);
                    currentTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = trainers.FirstOrDefault(x => x.Name == trainerName);
                    trainer.Pokemons.Add(pokemon);
                }

                input = Console.ReadLine();

            }
            string element = Console.ReadLine();

            while (element != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Pokemons = trainer.Pokemons.Where(x => x.Health > 0).ToList();
                    }
                }
                element = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }
    }
}
