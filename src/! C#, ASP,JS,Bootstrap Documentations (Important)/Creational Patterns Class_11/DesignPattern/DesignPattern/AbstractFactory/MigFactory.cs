using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.AbstractFactory
{
    internal class MigFactory : FighterJetFactory
    {
        public override FighterJet GetJet()
        {
            return new Mig();
        }

        public override Weapon GetWeapon()
        {
           return new MigWeapon();
        }
    }
}
