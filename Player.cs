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
        private Item[] _inventory;

        public Player()
        {
            _health = 100;
            _damage = 10;
            _inventory = new Item[5];
        }

        public Player(string name,int healthVal,int damageVal,int inventorySize)
        {
            _name = name;
            _health = healthVal;
            _damage = damageVal;
            _inventory = new Item[inventorySize];
        }
        
        public void EquipItem(int itemIndex)
        {
            _damage += _inventory[itemIndex].statBoost;
        }
        public void AddItemToInv(Item item, int index)
        {
            _inventory[index] = item;
        }

        public string GetName()
        {
            return _name;
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
