using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double DefaultBaseHealth = 100;
        private const double DefaultBaseArmor = 50;
        private const double DefaultAbilityPoints = 40;
        private static Bag DefaultBag = new Satchel();

        public Warrior(string name, Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, DefaultBag, faction)
        {
        }

        public void Attack(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
