﻿using DungeonsAndCodeWizards.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}
