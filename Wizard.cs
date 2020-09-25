using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Wizard : Entity
    {
        private float _mana;

        public Wizard() : base()
        {
            _mana = 100;
        }
        public Wizard(string nameVal, float healthVal, float damageVal, float manaVal)
            : base(nameVal, healthVal, damageVal)
        {
            _mana = manaVal;
        }

        public override void Attack(Entity enemy)
        {

            if (_mana >= 4)
            {
                float totalDamage =  _damage + _mana * 0.25f;
                _mana -= _mana * 0.25f;
                enemy.TakeDamage(totalDamage);
                return;
            }
            base.Attack(enemy);
        }
    }
}
