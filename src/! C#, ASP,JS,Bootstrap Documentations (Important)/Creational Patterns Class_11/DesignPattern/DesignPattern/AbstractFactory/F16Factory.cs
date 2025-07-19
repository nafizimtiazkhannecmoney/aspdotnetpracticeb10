using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    internal class F16Factory : FighterJetFactory
    {
        public override FighterJet GetJet()
        {
            return new F16();
        }

        public override Weapon GetWeapon()
        {
            return new F16Weapon();
        }
    }
}
