using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    internal abstract class FighterJetFactory
    {
        public abstract Weapon GetWeapon();
        public abstract FighterJet GetJet();
    }
}
