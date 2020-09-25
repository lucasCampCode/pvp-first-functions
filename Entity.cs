using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Entity
    {
        private string _name;
        private float _health;
        protected float _damage;

        public Entity()
        {
            _name = "stranger";
            _health = 100;
            _damage = 10;
        }
        public Entity(string nameVal,float healthVal,float damageVal)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
        }
        public virtual void Attack(Entity enemy)
        {
            enemy.TakeDamage(_damage);
        }
        public virtual void TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if (IsAlive() == false)
            {
                _health = 0;
            }
        }
        public bool IsAlive()
        {
            return _health > 0;
        }
        public string GetName()
        {
            return _name;
        }
        public virtual void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("health: " + _health);
        }
    }
}
