using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    enum ItemType
    {
        Weapon,
        MagicalWeapon,
        Consumable,
        Artifact
    }

    class Item
    {
        public string Name { get; set; }            // Название предмета в дарк-фентези стиле
        public ItemType Type { get; set; }          // Тип предмета
        public string Description { get; set; }     // Краткое описание
        public int Stat { get; set; }               // Урон для оружия, бонус для артефактов
        public (int Min, int Max) Quantity { get; set; } // Для расходников, диапазон выпадения

   
        public Item(string name, ItemType type, string description, int stat = 0, int minQty = 1, int maxQty = 1)
        {
            Name = name;
            Type = type;
            Description = description;
            Stat = stat;
            Quantity = (minQty, maxQty);
        }

        public override string ToString()
        {
            if (Type == ItemType.Consumable)
                return $"{Name} ({Quantity.Max}) — {Description}";
            else
                return $"{Name} (Стат: {Stat}) — {Description}";
                //return $"{Name} (Шкода: {Stat}) — {Description}";
        }
    }
}
