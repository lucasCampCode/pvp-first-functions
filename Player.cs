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
        private Item _currentWeapon;
        private Item _empty;

        public Player()
        {
            _health = 100;
            _damage = 10;
            _inventory = new Item[3];
            _empty.statBoost = 0;
            _empty.name = "empty";
        }

        public Player(string name,int healthVal,int damageVal,int inventorySize)
        {
            _name = name;
            _health = healthVal;
            _damage = damageVal;
            _empty.name = "empty";
            _empty.statBoost = 0;
            _inventory = new Item[inventorySize];
        }
        public Item[] GetInventory()
        {
            return _inventory;
        }
        public bool contains(int index)
        {
            if(index > 0 && index < _inventory.Length)
            {
                return true;
            }
            return false;
        }
        
        public void EquipItem(int itemIndex)
        {
            if(contains(itemIndex))
            {
                _currentWeapon = _inventory[itemIndex];
            }
            else
            {
                Console.WriteLine("invalid");
            }
                
        }
        public void AddItemToInv(Item item, int index)
        {
            _inventory[index] = item;
        }
        public void UnequipItem()
        {
            _currentWeapon = _empty;
        }
        public void RemoveItem(int index)
        {
            _inventory[index] = _empty;
        }
        public void MoveItem(int from,int to) 
        {
            _inventory[to] = _inventory[from];
            RemoveItem( from);
        }

        public string GetName()
        {
            return _name;
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("health: " + _health);
            Console.WriteLine("Damage: " + (_damage + _currentWeapon.statBoost));
        }
        public bool GetIsAlive()
        {
            return _health > 0;
        }
        public void Attack(Player enemy)
        {
            int totalDamage = _damage + _currentWeapon.statBoost;
            enemy.TakeDamage(totalDamage);
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
