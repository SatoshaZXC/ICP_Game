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
        public string Name { get; set; }            // Назва предмета в стилі дарк-фентезі
        public ItemType Type { get; set; }          // Тип предмета
        public string Description { get; set; }     // Короткий опис
        public int Stat { get; set; }               // Шкода для зброї, бонус для артефактів
        public (int Min, int Max) Quantity { get; set; } // Для витратних матеріалів, діапазон випадання


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
