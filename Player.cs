using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player : Entity
    {
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _empty;

        public Player() : base()
        {
            _inventory = new Item[3];
            _empty.statBoost = 0;
            _empty.name = "empty";
        }

        public Player(string name,int healthVal,int damageVal,int inventorySize) : base(name, healthVal, damageVal)
        {
            _empty.name = "empty";
            _empty.statBoost = 0;
            _inventory = new Item[inventorySize];
        }

        public override void Attack(Entity enemy)
        {
            if (_currentWeapon.name != "empty")
            {
                float totalDamage = _damage + _currentWeapon.statBoost;
                enemy.TakeDamage(totalDamage);
            }
            else
            {
                base.Attack(enemy);
            }
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
            RemoveItem(from);
        }
        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine("Damage: " + (_damage + _currentWeapon.statBoost));
            Console.WriteLine();
        }
    }
}
