using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    internal class Chest
    {
        public string Name { get; set; }
        public Dictionary<ItemType, int> TypeChances { get; set; } // шансы выпадения типа
        public Dictionary<ItemType, Dictionary<string, Item>> Items { get; set; }

        private Random rnd = new Random();

        public Chest(string name)
        {
            Name = name;
            TypeChances = new Dictionary<ItemType, int>();
            Items = new Dictionary<ItemType, Dictionary<string, Item>>();
        }

        // Добавление шансов выпадения типа
        public void AddTypeChance(ItemType type, int chance)
        {
            TypeChances[type] = chance;
        }

        // Добавление списка предметов
        public void AddItems(ItemType type, Dictionary<string, Item> items)
        {
            Items[type] = items;
        }

        // Получение случайного предмета
        public Item Open()
        {
            // 1. Выбираем тип по шансам
            int total = 0;
            foreach (var chance in TypeChances.Values) total += chance;
            int roll = rnd.Next(total);

            ItemType selectedType = ItemType.Weapon; // по умолчанию
            int cumulative = 0;
            foreach (var kvp in TypeChances)
            {
                cumulative += kvp.Value;
                if (roll < cumulative)
                {
                    selectedType = kvp.Key;
                    break;
                }
            }

            // 2. Выбираем случайный предмет из выбранного типа
            var itemsOfType = Items[selectedType];
            int itemIndex = rnd.Next(itemsOfType.Count);
            string key = new List<string>(itemsOfType.Keys)[itemIndex];
            Item selectedItem = itemsOfType[key];

            // 3. Для расходников случайная величина
            if (selectedItem.Type == ItemType.Consumable)
            {
                int qty = rnd.Next(selectedItem.Quantity.Min, selectedItem.Quantity.Max + 1);
                selectedItem = new Item(selectedItem.Name, selectedItem.Type, selectedItem.Description, 0, qty, qty);
            }

            return selectedItem;
        }
    }
}
