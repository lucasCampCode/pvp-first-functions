using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player 
    {
        private string _name;
        private int _health;
        private int _damage;
        public Player()
        {
            _health = 100;
            _damage = 10;
        }
        public Player(string name,int healthVal,int damageVal)
        {
            _name = name;
            _health = healthVal;
            _damage = damageVal;
        }
        
        public void EquipItem(Item weapon)
        {
            _damage += weapon.statBoost;

        }
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }
        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public void Attack(Player enemy)
        {
            enemy.TakeDamage(_damage);
        }
        private void TakeDamage(int damageVal)
        {
            if (GetIsAlive())
            {
                _health -= damageVal;
            }
        }
    }
}
