using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public abstract class Character
    {

        private const double DefaultRestHealMultiplier = 0.2;

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
            isAlive = true;
            restHealMultiplier = DefaultRestHealMultiplier;
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (hitPoints <= this.Armor)
            {
                this.Armor -= hitPoints;
            }
            else
            {
                double reminderHitPoints = hitPoints - this.Armor;
                this.Armor = 0;
                this.Health -= reminderHitPoints;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void Rest()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Bag.AddItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Bag.AddItem(item);
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
                else if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }              
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > this.BaseArmor)
                {
                    armor = this.BaseArmor;
                }
                else if (value < 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }               
            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
    
        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }
        
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        
        public virtual double RestHealMultiplier
        {
            get { return restHealMultiplier; }
            private set { restHealMultiplier = value; }
        }
    }
}
