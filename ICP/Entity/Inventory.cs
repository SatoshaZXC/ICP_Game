using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICP.Entity
{
    class Inventory
    {
        // Хеш-таблиця: ключ — назва предмета, значення — сам предмет
        private Dictionary<string, Item> items;

        public Inventory()
        {
            items = new Dictionary<string, Item>();
        }

        // Додаємо предмет
        public void AddItem(Item item)
        {
            if (item.Type == ItemType.Consumable)
            {
                // Для витратних матеріалів збільшуємо кількість, якщо вони вже є
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
                // Для зброї та артефактів просто додаємо, унікально за назвою
                if (!items.ContainsKey(item.Name))
                    items[item.Name] = item;
            }
        }

        // Видаляємо предмет (наприклад, витратний матеріал під час використання)
        public void RemoveItem(string itemName)
        {
            if (items.ContainsKey(itemName))
                items.Remove(itemName);
        }

        // Отримати предмет за назвою
        public Item GetItem(string itemName)
        {
            return items.ContainsKey(itemName) ? items[itemName] : null;
        }
        public List<Item> GetAllItems()
        {
            return new List<Item>(items.Values);
        }
        // Друк інвентарного списку
        public void PrintInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Інвентар порожній...");
                return;
            }

            Console.WriteLine("=== Твій Інвентар ===");
            int index = 1; // починаємо нумерацію з 1
            foreach (var kvp in items)
            {
                Item item = kvp.Value;
                Console.ForegroundColor = ConsoleColor.Yellow; // виділяємо лише назву предмета
                Console.Write($"{index}. {item.Name}");
                Console.ResetColor();

                if (item.Type == ItemType.Consumable)
                    Console.WriteLine($" ({item.Quantity.Min}) — {item.Description}");
                else
                    Console.WriteLine($" (Шкода: {item.Stat}) — {item.Description}");

                index++;
            }
            Console.WriteLine("=====================");
        }
    }
}
