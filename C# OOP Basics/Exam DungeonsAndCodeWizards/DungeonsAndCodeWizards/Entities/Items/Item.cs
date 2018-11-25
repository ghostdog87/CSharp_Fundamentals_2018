using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public abstract class Item
    {
        private int weight;

        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public abstract void AffectCharacter(Character character);

    }
}
