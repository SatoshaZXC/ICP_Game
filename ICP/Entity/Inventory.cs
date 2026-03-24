using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    class Inventory
    {
        // Хеш-таблица: ключ - название предмета, значение - сам предмет
        private Dictionary<string, Item> items;

        public Inventory()
        {
            items = new Dictionary<string, Item>();
        }

        // Добавляем предмет
        public void AddItem(Item item)
        {
            if (item.Type == ItemType.Consumable)
            {
                // Для расходников увеличиваем количество, если уже есть
                if (items.ContainsKey(item.Name))
                {
                    var existing = items[item.Name];
                    int totalQty = existing.Quantity.Min + item.Quantity.Min;
                    items[item.Name] = new Item(existing.Name, existing.Type, existing.Description, existing.Stat, totalQty, totalQty);
                }
                else
                {
                    items[item.Name] = item;
                }
            }
            else
            {
                // Для оружия и артефактов просто добавляем, уникально по имени
                if (!items.ContainsKey(item.Name))
                    items[item.Name] = item;
            }
        }

        // Удаляем предмет (например, расходник при использовании)
        public void RemoveItem(string itemName)
        {
            if (items.ContainsKey(itemName))
                items.Remove(itemName);
        }

        // Получить предмет по имени
        public Item GetItem(string itemName)
        {
            return items.ContainsKey(itemName) ? items[itemName] : null;
        }
        public List<Item> GetAllItems()
        {
            return new List<Item>(items.Values);
        }
        // Печать инвентаря
        public void PrintInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Інвентар порожній...");
                return;
            }

            Console.WriteLine("=== Твій Інвентар ===");
            int index = 1; // начинаем нумерацию с 1
            foreach (var kvp in items)
            {
                Item item = kvp.Value;
                Console.ForegroundColor = ConsoleColor.Yellow; // только имя предмета выделяем
                Console.Write($"{index}. {item.Name}");
                Console.ResetColor();

                if (item.Type == ItemType.Consumable)
                    Console.WriteLine($" ({item.Quantity.Min}) — {item.Description}");
                else
                    Console.WriteLine($" (Стат: {item.Stat}) — {item.Description}");

                index++;
            }
            Console.WriteLine("=====================");
        }
    }
}
