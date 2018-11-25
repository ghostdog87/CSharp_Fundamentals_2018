using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double DefaultBaseHealth = 50;
        private const double DefaultBaseArmor = 25;
        private const double DefaultAbilityPoints = 40;       
        private static Bag DefaultBag = new Backpack();
        private const double DefaultRestHealMultiplier = 0.5;

        public Cleric(string name, Faction faction) 
            : base(name, DefaultBaseHealth, DefaultBaseArmor, DefaultAbilityPoints, DefaultBag, faction)
        {
        }

        public override double RestHealMultiplier => DefaultRestHealMultiplier;

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
